using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Mobilya.Business.Abstract;
using Mobilya.Business.DTOs.CartDTOs;
using Mobilya.Business.DTOs.CartItemDTOs;
using Mobilya.DataAccess.Abstract;
using Mobilya.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mobilya.Business.Concrete
{
    public class CartManager : ICartService
    {
        private readonly ICartDal _cartDal;
        private readonly ICartItemDal _cartItemDal;
        private readonly IMapper _mapper;

        public CartManager(ICartDal cartDal, ICartItemDal cartItemDal, IMapper mapper)
        {
            _cartDal = cartDal;
            _cartItemDal = cartItemDal;
            _mapper = mapper;
        }

        public ResultCartDTO GetCartByUserId(int userId)
        {
            var cart=_cartDal.Get(x=>x.UserId == userId,include:x=>x.Include(y=>y.User).Include(z=>z.CartItems));
            var dto=_mapper.Map<ResultCartDTO>(cart);
            return dto;
        }

        public void InitializeCart(int userId)
        {
            Cart cart=new Cart
            {
            UserId = userId
            };
            _cartDal.Insert(cart);
        }
    }
}
