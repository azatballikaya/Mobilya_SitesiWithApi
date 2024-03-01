using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Mobilya_Sitesi.Models.ViewModels.Role;
using Newtonsoft.Json;
using System.Text;

namespace Mobilya_Sitesi.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Authorize(Roles ="Superadmin")]
	public class RoleController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;

        public RoleController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
		{
			var client=_httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("http://localhost:5198/api/Role");
			if(responseMessage.IsSuccessStatusCode)
			{
				var jsonData=await responseMessage.Content.ReadAsStringAsync();
				var values=JsonConvert.DeserializeObject<List<ResultRoleViewModel>>(jsonData);
				return View(values);
			}
			return View();
		}

		[HttpGet]
		public async Task<IActionResult> Edit(int id)
		{
			var client=_httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync($"http://localhost:5198/api/Role/{id}");
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData=await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<EditRoleViewModel>(jsonData);
				return View(values);
			}
			return RedirectToAction("Index");

		}
        [HttpPost]
        public async Task<IActionResult> Edit(EditRoleViewModel editRoleViewModel)
        {
            var client = _httpClientFactory.CreateClient();
			var jsonData=JsonConvert.SerializeObject(editRoleViewModel);
			StringContent content = new StringContent(jsonData,Encoding.UTF8,"application/json");
			var responseMessage = await client.PutAsync("http://localhost:5198/api/Role", content);
			if(responseMessage.IsSuccessStatusCode )
			{
				return RedirectToAction("Index");
			}
			return View(editRoleViewModel);

        }
		[HttpGet]
		public async Task<IActionResult> Delete(int id)
		{
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"http://localhost:5198/api/Role/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<DeleteRoleViewModel>(jsonData);
                return View(values);
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> DeleteRole(int id)
        {
            var client = _httpClientFactory.CreateClient();
           
            var responseMessage = await client.DeleteAsync($"http://localhost:5198/api/Role/{id}");

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");

        }
		[HttpGet]
		public async Task<IActionResult> AddRole()
		{
			return View();
		}
        [HttpPost]
        public async Task<IActionResult> AddRole(CreateRoleViewModel createRoleViewModel)
        {
			var client=_httpClientFactory.CreateClient();
			var jsonData=JsonConvert.SerializeObject(createRoleViewModel);
			StringContent content = new StringContent(jsonData,Encoding.UTF8,"application/json");
			var responseMessage = await client.PostAsync("http://localhost:5198/api/Role", content);
            if (responseMessage.IsSuccessStatusCode)
            {
				return RedirectToAction("Index");
            }
            return View(createRoleViewModel);
        }
    }
}
