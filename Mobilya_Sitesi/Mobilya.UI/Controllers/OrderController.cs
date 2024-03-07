using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Mobilya_Sitesi.Models.ViewModels.Order;
using Newtonsoft.Json;
using System.Security.Claims;
using System.Text;

namespace Mobilya_Sitesi.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public OrderController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        [HttpGet]
        public async Task<IActionResult> OrderList()
        {
            var userId=Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var client=_httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"http://localhost:5198/api/Order/GetOrderByUserId/{userId}");
            if(responseMessage.IsSuccessStatusCode)
            {
                var jsonData=await responseMessage.Content.ReadAsStringAsync();
            var value = JsonConvert.DeserializeObject<List<ResultOrderViewModel>>(jsonData);
                return View(value);
            }
            return View();

        }
        [HttpPost]
        public async Task<IActionResult> CreateOrder(CreateOrderViewModel createOrderViewModel)
        {
            createOrderViewModel.UserId=Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var client=_httpClientFactory.CreateClient();
            var jsonData=JsonConvert.SerializeObject(createOrderViewModel);
            StringContent content = new StringContent(jsonData,Encoding.UTF8,"application/json");
            var responseMessage = await client.PostAsync("http://localhost:5198/api/Order/CreateOrder",content);
            if(responseMessage.IsSuccessStatusCode) {
                return RedirectToAction("Home", "User");
                
            }
            return RedirectToAction("GoToCart","Cart","false");
        }
    }
}
