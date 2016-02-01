using Blog.DataAccessLayer.Interfaces;
using Blog.DataAccessLayer.Repositories;
using Ninject.Modules;
using System;

namespace Blog.BusinessLogicLayer.Infrastructure
{
    public class ServiceModule : NinjectModule
    {
        private string connectionString;

        public ServiceModule(string connection)
        {
            connectionString = connection;
        }

        public override void Load()
        {
            Bind<IBlogUnitOfWork>()
                .To<BlogUnitOfWork>()
                .WithConstructorArgument(connectionString);
        }
    }
}
