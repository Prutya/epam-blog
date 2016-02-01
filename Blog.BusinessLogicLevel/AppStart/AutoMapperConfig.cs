using AutoMapper;
using Blog.BusinessLogicLayer.DataTransferModel;
using Blog.DataAccessLayer.Models;

namespace Blog.BusinessLogicLayer.AppStart
{
    public class AutoMapperConfig
    {
        public static void RegisterMappings()
        {
            // ARTICLES
            Mapper.CreateMap<Article, ArticleDTO>()
                .ForMember(dest =>
                    dest.AuthorId, opts =>
                        opts.MapFrom(src =>
                            src.ClientProfileId))
                 .ForMember(dest =>
                    dest.AuthorName, opts =>
                        opts.MapFrom(src =>
                            src.ClientProfile.ShortName));

            // FEEDBACKS

            // TAGS

            // USERS

        }
    }
}
