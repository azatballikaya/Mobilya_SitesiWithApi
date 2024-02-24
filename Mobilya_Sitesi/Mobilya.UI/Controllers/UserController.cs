using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mobilya_Sitesi.Models;
using Mobilya_Sitesi.Models.ViewModels.Product;
using Newtonsoft.Json;

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
            return View(value);
        }
        public IActionResult Home(){
            return View();
        }
    }
}
