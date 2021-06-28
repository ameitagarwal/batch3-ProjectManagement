using AutoMapper;
using ProductManagement.Data.Entities;
using ProductManagement.WebAPI.Models;
using ProjectManagement.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement.WebApi
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Category, CategoryDto>()
                .ReverseMap();

            CreateMap<Product, ProductDto>().ReverseMap();

            CreateMap<AuthenticateRequest, User>().ReverseMap();

        }
    }
}
