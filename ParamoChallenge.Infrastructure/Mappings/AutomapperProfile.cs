using AutoMapper;
using ParamoChallenge.Core.DTOs;
using ParamoChallenge.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParamoChallenge.Infrastructure.Mappings
{
    public class AutomapperProfile:Profile
    {
        public AutomapperProfile()
        {
            CreateMap<Article,ArticleDto>();
            CreateMap<ArticleDto, Article>();
            CreateMap<Product,ProductDto>();
            CreateMap<ProductDto, Product>();
        }
    }
}
