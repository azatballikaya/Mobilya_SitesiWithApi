﻿using AutoMapper;
using Mobilya.Business.DTOs.AdviceDTOs;
using Mobilya.Business.DTOs.CartDTOs;
using Mobilya.Business.DTOs.CartItemDTOs;
using Mobilya.Business.DTOs.CategoryDTOs;
using Mobilya.Business.DTOs.OrderDetailDTOs;
using Mobilya.Business.DTOs.OrderDTOs;
using Mobilya.Business.DTOs.ProductDTOs;
using Mobilya.Business.DTOs.RoleDTOs;
using Mobilya.Business.DTOs.UserDTOs;
using Mobilya.Business.DTOs.UserRoleDTOs;
using Mobilya.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mobilya.Business.Mapping
{
    public class MappingDTOs: Profile
    {
        public MappingDTOs()
        {
            CreateMap<User, LoginUserDTO>().ReverseMap();
            CreateMap<User, CreateUserDTO>().ReverseMap();
            CreateMap<User, UpdateUserDTO>().ReverseMap();

            CreateMap<Category, CreateCategoryDTO>().ReverseMap();
            CreateMap<Category, UpdateCategoryDTO>().ReverseMap();

            CreateMap<Product, CreateProductDTO>().ReverseMap();
            CreateMap<Product, UpdateProductDTO>().ReverseMap();
            CreateMap<Product, GetProductWithCategoryDTO>().ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.CategoryName));

            CreateMap<Role, CreateRoleDTO>().ReverseMap();
            CreateMap<Role, UpdateRoleDTO>().ReverseMap();
            CreateMap<Role, ResultRoleDTO>().ReverseMap();

            CreateMap<UserRole,CreateUserRoleDTO>().ReverseMap();


            CreateMap<User,CreateUserDTO>().ReverseMap();
            CreateMap<User,LoginUserDTO>().ReverseMap();
            
            CreateMap<User,UpdateUserDTO>().ReverseMap();
            CreateMap<User,ResultUserWithRoleNameDTO>().ForMember(dest=>dest.RoleNames, opt=>opt.MapFrom(src=>src.UserRoles.Select(x=>x.Role.RoleName))).ReverseMap();
            CreateMap<User,ResultUserDTO>().ForMember(dest=>dest.Roles, opt=>opt.MapFrom(src=>src.UserRoles.Select(x=>x.Role))).ReverseMap();

            CreateMap<Cart,ResultCartDTO>().ReverseMap();
            CreateMap<Cart,UpdateCartDTO>().ReverseMap();
            CreateMap<Cart,CreateCartDTO>().ReverseMap();

            CreateMap<CartItem, ResultCartItemDTO>().ReverseMap();
            CreateMap<CartItem, UpdateCartItemDTO>().ReverseMap();
            CreateMap<CartItem, CreateCartItemDTO>().ReverseMap();

            CreateMap<Order, ResultOrderDTO>().ReverseMap();
            CreateMap<Order, UpdateOrderDTO>().ReverseMap();
            CreateMap<Order, CreateOrderDTO>().ReverseMap();

            CreateMap<OrderDetail, ResultOrderDetailDTO>().ReverseMap();
            CreateMap<OrderDetail, UpdateOrderDetailDTO>().ReverseMap();
            CreateMap<OrderDetail, CreateOrderDetailDTO>().ReverseMap();

            CreateMap<Advice,ResultAdviceDTO>().ReverseMap();
            CreateMap<Advice,CreateAdviceDTO>().ReverseMap();



        }
    }
}
