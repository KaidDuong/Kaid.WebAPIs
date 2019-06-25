using AutoMapper;
using Kaid.WebAPI.Model.Models;
using Kaid.WebAPI.Web.Models.ViewModels;

namespace Kaid.WebAPI.Web.Mappings
{
    public class AutoMapperConfiguration
    {
        public static void Configure()
        {
            Mapper.Initialize(config =>
            {
                //User
                config.CreateMap<ApplicationUser, ApplicationUserViewModel>();
                //Tag
                config.CreateMap<Tag, TagViewModel>();

                //Post
                config.CreateMap<Post, PostViewModel>();
                config.CreateMap<PostCategory, PostCategoryViewModel>();
                config.CreateMap<PostTag, PostTagViewModel>();
                //product
                config.CreateMap<Product, ProductViewModel>();
                config.CreateMap<ProductCategory, ProductCategoryViewModel>();
                config.CreateMap<ProductTag, ProductTagViewModel>();

                //footer
                config.CreateMap<Footer, FooterViewModel>();
            });
        }
    }
}