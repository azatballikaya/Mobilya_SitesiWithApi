using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mobilya_Sitesi.Models;
using Mobilya_Sitesi.Models.ViewModels.Cart;
using Mobilya_Sitesi.Models.ViewModels.Product;
using Newtonsoft.Json;
using System.Security.Claims;

namespace Mobilya_Sitesi.Controllers
{
    public class UserController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public UserController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client=_httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:5198/api/Product/GetAllProductsWithCategories");
            var value = JsonConvert.DeserializeObject<List<ProductViewModel>>(await responseMessage.Content.ReadAsStringAsync());
            if (User.Identity.IsAuthenticated)
            {

                var userId = Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));
              
                 responseMessage = await client.GetAsync($"http://localhost:5198/api/Cart/GetCartByUserId/{userId}");
                if (responseMessage.IsSuccessStatusCode)
                {
                    var jsonData = await responseMessage.Content.ReadAsStringAsync();
                    var cart = JsonConvert.DeserializeObject<ResultCartViewModel>(jsonData);
                    var cartItemsCount = cart.CartItems.Count();
                    ViewBag.CartItemsCount = cartItemsCount;

                }
            }
            return View(value);
        }
        public async Task<IActionResult> Home(){
            if (User.Identity.IsAuthenticated)
            {

            var userId=Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));
          var client=  _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"http://localhost:5198/api/Cart/GetCartByUserId/{userId}");
            if(responseMessage.IsSuccessStatusCode)
            {
                var jsonData=await responseMessage.Content.ReadAsStringAsync();
                var cart=JsonConvert.DeserializeObject<ResultCartViewModel>(jsonData);
                var cartItemsCount=cart.CartItems.Count();
                ViewBag.CartItemsCount = cartItemsCount;

            }
            }
            return View();
        }
    }
}
