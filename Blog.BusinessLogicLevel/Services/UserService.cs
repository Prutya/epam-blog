using Blog.BusinessLogicLayer.Interfaces;
using Blog.DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog.BusinessLogicLayer.DataTransferModel;
using Blog.BusinessLogicLayer.Infrastructure;
using System.Security.Claims;
using Blog.DataAccessLayer.Models;
using Microsoft.AspNet.Identity;

namespace Blog.BusinessLogicLayer.Services
{
    public class UserService : IUserService
    {
        private readonly IBlogUnitOfWork _uow;

        public UserService(IBlogUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<OperationDetails> Create(UserDTO userDto)
        {
            ApplicationUser user = await _uow.UserManager.FindByEmailAsync(userDto.Email);
            if (user == null)
            {
                user = new ApplicationUser { Email = userDto.Email, UserName = userDto.Email };
                await _uow.UserManager.CreateAsync(user, userDto.Password);
                // добавляем роль
                await _uow.UserManager.AddToRoleAsync(user.Id, userDto.Role);
                // создаем профиль клиента
                ClientProfile clientProfile = new ClientProfile
                {
                    Id = user.Id,
                    LastName = userDto.LastName,
                    FirstName = userDto.FirstName
                };
                _uow.ClientManager.Create(clientProfile);
                await _uow.SaveAsync();
                return new OperationDetails(true, "Registration was successful", "");
            }
            else
            {
                return new OperationDetails(false, "User with such email already exists", "Email");
            }
        }
        public async Task<ClaimsIdentity> Authenticate(UserDTO userDto)
        {
            ClaimsIdentity claim = null;
            // находим пользователя
            ApplicationUser user = await _uow.UserManager.FindAsync(userDto.Email, userDto.Password);
            // авторизуем его и возвращаем объект ClaimsIdentity
            if (user != null)
                claim = await _uow.UserManager.CreateIdentityAsync(user,
                                            DefaultAuthenticationTypes.ApplicationCookie);
            return claim;
        }
        // начальная инициализация бд
        //public async Task SetInitialData(UserDTO adminDto, List<string> roles)
        //{
        //    foreach (string roleName in roles)
        //    {
        //        var role = await _uow.RoleManager.FindByNameAsync(roleName);
        //        if (role == null)
        //        {
        //            role = new ApplicationRole { Name = roleName };
        //            await _uow.RoleManager.CreateAsync(role);
        //        }
        //    }
        //    await Create(adminDto);
        //}

        public void Dispose()
        {
            _uow.Dispose();
        }
    }
}
