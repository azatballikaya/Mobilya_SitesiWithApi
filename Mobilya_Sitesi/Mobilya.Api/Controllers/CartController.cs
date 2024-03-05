using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mobilya.Business.Abstract;
using Mobilya.Business.DTOs.CartItemDTOs;

namespace Mobilya.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartService _cartService;
        private readonly ICartItemService _cartItemService;



        public CartController(ICartService cartService, ICartItemService cartItemService)
        {
            _cartService = cartService;
            _cartItemService = cartItemService;
        }

        [HttpPost("AddToCart")]
        public IActionResult AddToCart(CreateCartItemDTO createCartItemDTO)
        {
            _cartItemService.AddCartItemToCart(createCartItemDTO.CartId, createCartItemDTO.ProductId);
            return Ok();
        }
        [HttpGet("RemoveFromCart/{id}")]
        public IActionResult DeleteCartItemFromCart(int id)
        {
            _cartItemService.DeleteCartItem(id);
            return Ok();
        }
        [HttpGet("GetCartByUserId/{id}")]
        public IActionResult GetCart(int id)
        {
            var cart=_cartService.GetCartByUserId(id);
            return Ok(cart);
        }
        [HttpGet("ClearCartByUserId/{id}")]
        public IActionResult ClearCart(int id)
        {
            _cartItemService.ClearCart(id);
            return Ok();
        }
        [HttpPost("ChangeQuantity")]
        public IActionResult ChangeQuantity(int cartItemId,int quantity)
        {
           var response= _cartItemService.ChangeQuantity(cartItemId, quantity);
            return Ok(response);
        }
        
           
    }
}
