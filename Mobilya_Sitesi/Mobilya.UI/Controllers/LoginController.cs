using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Mobilya_Sitesi.Models;
using Mobilya_Sitesi.Models.ViewModels.Admin;
using Newtonsoft.Json;
using System.Security.Claims;
using System.Text;

namespace Mobilya_Sitesi.Controllers
{
    public class LoginController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public LoginController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

       
        [HttpGet]
        
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(LoginAdminViewModel loginAdminViewModel)
        {
            var client=_httpClientFactory.CreateClient();
            var jsonData=JsonConvert.SerializeObject(loginAdminViewModel);
            StringContent content = new StringContent(jsonData,Encoding.UTF8,"application/json");
            var responseMessage = await client.PostAsync("http://localhost:5198/api/Admin/Login", content);


            if(responseMessage.IsSuccessStatusCode)
            {
                var result=await responseMessage.Content.ReadAsStringAsync();
                if (result != null) { 
                    var admin=JsonConvert.DeserializeObject<LoginAdminViewModel>(result);

                    var claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.Name,admin.UserName)

                };
                    var useridentity = new ClaimsIdentity(claims, "Login");
                    ClaimsPrincipal principal = new ClaimsPrincipal(useridentity);
                    await HttpContext.SignInAsync(principal);
                    return RedirectToAction("Index", "Home");


                }
            }
            return View(loginAdminViewModel);
          
        }
    }
}
