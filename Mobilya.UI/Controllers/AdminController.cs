using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Mobilya_Sitesi.Models;
using Mobilya_Sitesi.Models.ViewModels.Admin;
using Newtonsoft.Json;
using System.Text;

namespace Mobilya_Sitesi.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        [HttpGet]
        public IActionResult AddAdmin()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddAdmin(CreateAdminViewModel model)
        {
            if(ModelState.IsValid)
            {
                var client=_httpClientFactory.CreateClient();
                var jsonData=JsonConvert.SerializeObject(model);
                StringContent content = new StringContent(jsonData,Encoding.UTF8,"application/json");
                var responseMessage = await client.PostAsync("http://localhost:5198/api/Admin/AddAdmin",content);
                if(responseMessage.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index", "Home");
                }
                
                
            }
            return View(model);
        }

    }
}
