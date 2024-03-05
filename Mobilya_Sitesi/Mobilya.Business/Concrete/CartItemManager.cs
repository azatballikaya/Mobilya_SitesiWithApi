using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Mobilya.Business.Abstract;
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
    public class CartItemManager : ICartItemService
    {
        private readonly ICartItemDal _cartItemDal;
        private readonly ICartDal _cartDal;
        private readonly IMapper _mapper;

        public CartItemManager(ICartItemDal cartItemDal, IMapper mapper, ICartDal cartDal)
        {
            _cartItemDal = cartItemDal;
            _mapper = mapper;
            _cartDal = cartDal;
        }

        public void AddCartItemToCart(int cartId, int productId)
        {
           var cartItem=_cartItemDal.Get(x=>x.ProductId == productId && x.CartId==cartId);
            if(cartItem == null)
            {
            _cartItemDal.Insert(new CartItem { ProductId = productId,CartId = cartId , Quantity=1});

            }
            cartItem.Quantity =cartItem.Quantity+ 1;
            _cartItemDal.Update(cartItem);
        }

        public ChangeQuantityDTO ChangeQuantity(int cartItemId, int quantity)
        {
            var cartItem=_cartItemDal.GetById(cartItemId);
            cartItem.Quantity = quantity;
            _cartItemDal.Update(cartItem);
            cartItem=_cartItemDal.Get(x=>x.Id==cartItemId,x=>x.Include(y=>y.Product));
            var cart = _cartDal.Get(x => x.CartId == cartItem.CartId, x => x.Include(y => y.CartItems).ThenInclude(z => z.Product));
            ChangeQuantityDTO changeQuantityDTO = new ChangeQuantityDTO
            {
                CartItemPrice = cartItem.Quantity * cartItem.Product.Price,
                CartTotalPrice = Convert.ToDouble(cart.TotalPrice())

            };
            return changeQuantityDTO ;
        }

        public void ClearCart(int userId)
        {
          var cartItems=_cartItemDal.GetAll(x=>x.Cart.User.UserId == userId,x=>x.Include(y=>y.Cart).ThenInclude(z=>z.User));
            foreach (var item in cartItems)
            {
                _cartItemDal.Delete(item);
            }
        }

        public void DeleteCartItem(int cartItemId)
        {
            var cartItem=_cartItemDal.Get(x=>x.Id == cartItemId);
            _cartItemDal.Delete(cartItem);
        }

        public List<ResultCartItemDTO> GetAllCartItemsByUserId(int userId)
        {
            var cartItems=_cartItemDal.GetAll(x=>x.Cart.UserId == userId,include:x=>x.Include(y=>y.Cart));
            var dtos=_mapper.Map<List<ResultCartItemDTO>>(cartItems);
            return dtos;
        }

        public int ItemCountAsync(int cartId)
        {
           return (_cartItemDal.GetAll(x=>x.CartId==cartId)).Count;
        }
    }
}
