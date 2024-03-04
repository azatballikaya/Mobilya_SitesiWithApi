using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Mobilya_Sitesi.Models.ViewModels.Order;
using Newtonsoft.Json;

namespace Mobilya_Sitesi.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles ="Superadmin , Admin")]
    public class OrderController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public OrderController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index(bool? id=true)
        {
            if(id !=false) {
                ViewBag.Check = null;
            
            }
            else
            {
                ViewBag.Check = "Sipariş başarıyla silindi...";
            }
            var client=_httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:5198/api/Order/GetAllOrders");
            if(responseMessage.IsSuccessStatusCode)
            {
                var jsonData=await responseMessage.Content.ReadAsStringAsync();
                var values=JsonConvert.DeserializeObject<List<ResultOrderViewModel>> (jsonData);
                
                return View(values);
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"http://localhost:5198/api/Order/GetOrderById/{id}");
            if(responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var value= JsonConvert.DeserializeObject<ResultOrderViewModel>(jsonData);
                return View(value);
            }
            return NotFound();
        }
        public async Task<IActionResult> Delete (int id) { 
        
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"http://localhost:5198/api/Order/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index",false);
            }
            return NotFound();

        }
    }
}
