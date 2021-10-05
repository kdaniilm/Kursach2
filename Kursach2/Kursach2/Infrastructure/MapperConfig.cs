using AutoMapper;
using Domain.Entities;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kursach2.Infrastructure
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<ProductModel, Product>();
            CreateMap<Product, ProductModel>();

            CreateMap<CharactristicModel, Characteristic>();
            CreateMap<Characteristic, CharactristicModel>();

            CreateMap<CategoryModel, Category>();
            CreateMap<Category, CategoryModel>();

        }
    }
}
