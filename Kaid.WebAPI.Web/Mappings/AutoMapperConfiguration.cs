

using AutoMapper;
using Kaid.WebAPI.Model.Models;
using Kaid.WebAPI.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Kaid.WebAPI.Web.Mappings
{
    public class AutoMapperConfiguration
    {
        
        public static void Configure( )
        {
            Mapper.Initialize(config =>
            {
                config.CreateMap<Post, PostViewModel>();
                config.CreateMap<PostCategory, PostCategoryViewModel>();
                config.CreateMap<Tag, TagViewModel>();
                
               });
        }
    }
}