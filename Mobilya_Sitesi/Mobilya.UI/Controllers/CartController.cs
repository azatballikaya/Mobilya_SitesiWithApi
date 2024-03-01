using Microsoft.AspNetCore.Mvc;
using Mobilya_Sitesi.Models.ViewModels.Cart;

namespace Mobilya_Sitesi.Controllers
{
    public class CartController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public CartController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        
        public async IActionResult AddToCart(int id)
        {
            var client = _httpClientFactory.CreateClient();
            AddToCartViewModel addToCartViewModel= new AddToCartViewModel()
            {
                ProductId = id,
                UserId=User.Identity.getuser
            }
            var responseMessage=await client.GetAsync($"http://localhost:5198/api/")
            return View();
        }
    }
}
