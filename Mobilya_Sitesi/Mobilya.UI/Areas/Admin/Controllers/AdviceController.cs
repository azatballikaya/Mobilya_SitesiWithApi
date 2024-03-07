using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Mobilya_Sitesi.Models.ViewModels.Advice;
using Newtonsoft.Json;

namespace Mobilya_Sitesi.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles ="Superadmin , Admin")]
    public class AdviceController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdviceController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client=_httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:5198/api/Advice");
            if(responseMessage.IsSuccessStatusCode)
            {
                var jsonData=await responseMessage.Content.ReadAsStringAsync();
                var values=JsonConvert.DeserializeObject<List<ResultAdviceViewModel>>(jsonData);
                return View(values);
            }
            return View();
        }
        public async Task<IActionResult> Delete(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"http://localhost:5198/api/Advice/{id}");
         
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Detail(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"http://localhost:5198/api/Advice/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var value= JsonConvert.DeserializeObject<ResultAdviceViewModel>(jsonData);
                return View(value);
            }
            return View();
        }
        
    }
}
