using AutoMapper;
using Mobilya.Business.DTOs.AdminDTOs;
using Mobilya.Business.DTOs.CategoryDTOs;
using Mobilya.Business.DTOs.ProductDTOs;
using Mobilya.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mobilya.Business.Mapping
{
    public class MappingDTOs:Profile
    {
        public MappingDTOs()
        {
            CreateMap<Admin,LoginAdminDTO>().ReverseMap();
            CreateMap<Admin,CreateAdminDTO>().ReverseMap();
            CreateMap<Admin,UpdateAdminDTO>().ReverseMap();

            CreateMap<Category, CreateCategoryDTO>().ReverseMap();
            CreateMap<Category, UpdateCategoryDTO>().ReverseMap();
            
            CreateMap<Product,CreateProductDTO>().ReverseMap();
            CreateMap<Product, UpdateProductDTO>().ReverseMap();
            CreateMap<Product,GetProductWithCategoryDTO>().ForMember(dest=>dest.CategoryName, opt=>opt.MapFrom(src=>src.Category.CategoryName));

            
        }
    }
}
