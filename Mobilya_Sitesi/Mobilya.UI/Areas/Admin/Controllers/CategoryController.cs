using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Mobilya_Sitesi.Models;
using Mobilya_Sitesi.Models.ViewModels.Category;
using Newtonsoft.Json;
using System.Text;

namespace Mobilya_Sitesi.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles ="Superadmin , Admin")]
    public class CategoryController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public CategoryController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        
        [HttpGet]
        public IActionResult AddCategory()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddCategory(AddCategoryViewModel addCategoryViewModel)
        {
            if (addCategoryViewModel == null)
                return NotFound();
          var client=_httpClientFactory.CreateClient();
            var jsonData=JsonConvert.SerializeObject(addCategoryViewModel);
            StringContent content = new StringContent(jsonData,Encoding.UTF8,"application/json");
            var responseMessage = await client.PostAsync("http://localhost:5198/api/Category/AddCategory", content);
            if(responseMessage.IsSuccessStatusCode)
            {
              return RedirectToAction("CategoryList");

            }
            return View(addCategoryViewModel);
        }
        public async Task<IActionResult> CategoryList()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:5198/api/Category/GetAllCategoriesWithProducts");
            var categories = JsonConvert.DeserializeObject<List<CategoryViewModel>>(await responseMessage.Content.ReadAsStringAsync());
            return View(categories);
        }
        public async Task<IActionResult> CategoryDelete(int id)
        {
            var client = _httpClientFactory.CreateClient();
            await client.DeleteAsync($"http://localhost:5198/api/Category/{id}");
            return RedirectToAction("CategoryList");
        }
    }
}
