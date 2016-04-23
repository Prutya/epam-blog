using Blog.BusinessLogicLayer.Interfaces;
using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Ninject;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

[assembly: OwinStartup(typeof(Blog.Web.App_Start.Startup))]

namespace Blog.Web.App_Start
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.CreatePerOwinContext(GetArticlesService);
            app.CreatePerOwinContext(GetUserService);

            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login")
            });
        }

        private IArticleService GetArticlesService()
        {
            return DependencyResolver.Current.GetService<IArticleService>();
        }
        private IUserService GetUserService()
        {
            return DependencyResolver.Current.GetService <IUserService>();
        }
    }
}