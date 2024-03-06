using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Mobilya_Sitesi.Models;

using Mobilya_Sitesi.Models.ViewModels.User;
using Newtonsoft.Json;
using System.Security.Claims;
using System.Text;

namespace Mobilya_Sitesi.Controllers
{
    public class LoginController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;

        public LoginController(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
        }


        [HttpGet]
        
        public IActionResult Index(bool id=false)
        {
            ViewBag.Check = id ? true : false;
			if (User.Identity.IsAuthenticated)
			{
				return Redirect("/Admin/Home/Index");
			}
			return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(LoginUserViewModel loginUserViewModel)
        {
          
            var apiurl = _configuration.GetSection("ApiUrl").Get<string>();
            var client=_httpClientFactory.CreateClient();
            var jsonData=JsonConvert.SerializeObject(loginUserViewModel);
            StringContent content = new StringContent(jsonData,Encoding.UTF8,"application/json");
            var responseMessage = await client.PostAsync(apiurl+"/User/Login", content);


            if(responseMessage.IsSuccessStatusCode)
            {
                var result=await responseMessage.Content.ReadAsStringAsync();
                if (result != null) { 
                    var admin=JsonConvert.DeserializeObject<LoginUserViewModel>(result);
                    
                    var claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.NameIdentifier,admin.UserId.ToString()),
                    new Claim(ClaimTypes.Name,admin.UserName),
                    

                };
                    claims.AddRange(admin.RoleNames.Select(x => new Claim(ClaimTypes.Role, x)));
                   
                    var useridentity = new ClaimsIdentity(claims, "Login");
                    ClaimsPrincipal principal = new ClaimsPrincipal(useridentity);
                    await HttpContext.SignInAsync(principal);
                    if (admin.RoleNames.Contains("Customer"))
                    {
                        return RedirectToAction("Index", "Home");

                    }
                    return Redirect("~/Admin/User/Home");


                }
            }
            return View(loginUserViewModel);
          
        }
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
			return RedirectToAction("Home", "User");
		}
        [HttpGet]
        public async Task<IActionResult> Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterUserViewModel registerUserViewModel)
        {
            if (!ModelState.IsValid) {
           
            return View(registerUserViewModel);


			}
            else
            {
				registerUserViewModel.RoleIds.Add(6);
				var client = _httpClientFactory.CreateClient();
				var jsonData = JsonConvert.SerializeObject(registerUserViewModel);
				StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
				var responseMessage = await client.PostAsync("http://localhost:5198/api/User/AddUser", content);
				if (responseMessage.IsSuccessStatusCode)
				{
					return RedirectToAction("Index", true);
				}
				return View(registerUserViewModel);

			}

		}
    }
}
