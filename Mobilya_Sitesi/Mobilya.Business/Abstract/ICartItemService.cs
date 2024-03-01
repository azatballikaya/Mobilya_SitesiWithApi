using Mobilya.Business.DTOs.CartDTOs;
using Mobilya.Business.DTOs.CartItemDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mobilya.Business.Abstract
{
    public interface ICartItemService
    {

        void AddCartItemToCart(int cartId, int productId);
        void DeleteCartItem(int cartItemId);
        List<ResultCartItemDTO> GetAllCartItemsByUserId(int userId);
        void ClearCart(int userId);
        void ChangeQuantity(int cartItemId, int quantity);
        int ItemCountAsync(int cartId);


    }
}
