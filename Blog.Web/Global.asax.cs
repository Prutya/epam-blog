using AutoMapper;
using Blog.BusinessLogicLayer.DataTransferModel;
using System.Linq;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Blog.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            ConfigureMappings();
        }

        protected void ConfigureMappings()
        {
            BusinessLogicLayer.AppStart.AutoMapperConfig.RegisterMappings();

            Mapper.CreateMap<ArticleDTO, ViewModels.Article.IndexViewModel>().
                ForMember(dest =>
                    dest.PreviewText, opts =>
                        opts.MapFrom(src =>
                            src.Text == null ? null :
                            src.Text.Length > 200 ? src.Text.Substring(0, 200) + "..." :
                            src.Text));
            Mapper.CreateMap<ArticleDTO, ViewModels.Article.DeleteViewModel>().
                ForMember(dest =>
                    dest.PreviewText, opts =>
                        opts.MapFrom(src =>
                            src.Text == null ? null :
                            src.Text.Length > 200 ? src.Text.Substring(0, 200) + "..." :
                            src.Text));

            Mapper.CreateMap<TagDTO, ViewModels.Tag.IndexViewModel>();
        }
    }
}
