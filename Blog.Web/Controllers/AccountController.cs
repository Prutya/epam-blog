using Blog.BusinessLogicLayer.DataTransferModel;
using Blog.BusinessLogicLayer.Infrastructure;
using Blog.BusinessLogicLayer.Interfaces;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Blog.Web.Controllers
{
    public class AccountController : Controller
    {
        private IUserService UserService
        {
            get
            {
                return HttpContext.GetOwinContext().GetUserManager<IUserService>();
            }
        }
        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        //private async Task SetInitialDataAsync()
        //{
        //    await UserService.SetInitialData(new UserDTO
        //    {
        //        Email = "user@example.com",
        //        UserName = "user@example.com",
        //        Password = "P@ssw0rd!",
        //        FirstName = "John",
        //        LastName = "Doe",
        //        Role = "Admin",
        //    }, new List<string> { "User", "Admin" });
        //}

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(ViewModels.Account.LoginViewModel model)
        {
            //await SetInitialDataAsync();
            if (ModelState.IsValid)
            {
                UserDTO userDto = new UserDTO { Email = model.Email, Password = model.Password };
                ClaimsIdentity claim = await UserService.Authenticate(userDto);
                if (claim == null)
                {
                    ModelState.AddModelError("", "Неверный логин или пароль.");
                }
                else
                {
                    AuthenticationManager.SignOut();
                    AuthenticationManager.SignIn(new AuthenticationProperties
                    {
                        IsPersistent = true
                    }, claim);
                    return RedirectToAction("Index", "Home");
                }
            }

            return View(model);
        }

        [HttpGet]
        public ActionResult Logout()
        {
            AuthenticationManager.SignOut();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(ViewModels.Account.RegisterViewModel model)
        {
            // await SetInitialDataAsync();
            if (ModelState.IsValid)
            {
                UserDTO userDto = new UserDTO
                {
                    Email = model.Email,
                    Password = model.Password,
                    PhoneNumber = model.PhoneNumber,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Role = "User"
                };
                OperationDetails operationDetails = await UserService.Create(userDto);
                if (operationDetails.Success)
                    return RedirectToAction("Index", "Home");
                else
                    ModelState.AddModelError(operationDetails.Property, operationDetails.Message);
            }
            return View(model);
        }


    }
}