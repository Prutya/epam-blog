using Blog.BusinessLogicLayer.Interfaces;
using Blog.BusinessLogicLayer.Services;
using Blog.BusinessLogicLevel.Interfaces;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blog.Web.Util
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;

        public NinjectDependencyResolver(IKernel kernelParam)
        {
            kernel = kernelParam;
            AddBindings();
        }
        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }
        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }
        private void AddBindings()
        {
            kernel.Bind<IArticleService>().To<ArticleService>();
            kernel.Bind<IUserService>().To<UserService>();
            // kernel.Bind<IFeedbackService>().To<FeedbackService>();
            // kernel.Bind<ITagService>().To<TagService>();
        }
    }
}