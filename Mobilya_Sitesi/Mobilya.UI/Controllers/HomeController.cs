using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Mobilya_Sitesi.Models;
using Mobilya_Sitesi.Models.ViewModels.Category;
using Mobilya_Sitesi.Models.ViewModels.Product;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Text;

namespace Mobilya_Sitesi.Controllers
{
    [Authorize]
   
    public class HomeController : Controller
    {
         private readonly IHttpClientFactory _httpClientFactory;

        public HomeController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        [NonAction]
        public async Task<List<CategoryViewModel>> GetCategories()
        {
            var client= _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:5198/api/Category");
            var result=JsonConvert.DeserializeObject<List<CategoryViewModel>>(await responseMessage.Content.ReadAsStringAsync());
            return result;

        }

        Context c = new Context();
        [HttpGet]
        public async Task<IActionResult> Index(int category=0)
        {
            HttpResponseMessage responseMessage;
            var client=_httpClientFactory.CreateClient();
            if (category == 0)
            {

                 responseMessage = await client.GetAsync("http://localhost:5198/api/Product/GetAllProducts");

            }
            else {
                 responseMessage = await client.GetAsync($"http://localhost:5198/api/Product/GetProductsByCategoryId/{category}");
            }
            
           
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ProductViewModel>>(jsonData);
                
                //List<string> categories =new List<string>();
                //string value = "";
                //foreach (var item in values)
                //{
                //    if (item.CategoryName != value)
                //    {
                //        categories.Add(item.CategoryName);
                //    }

                //    value = item.CategoryName;
                //}
                ViewBag.Categories = new SelectList(await GetCategories(), "CategoryId", "CategoryName");
                return View(values);

            }
            else
            {

                return View();
            }
            // ViewBag.Categories=new SelectList(c.Category.Include(x=>x.Products).Where(x=>x.Products.Any()).ToList(),"CategoryId","CategoryName");

            //if (category==0)
            //return View(c.Products.ToList());
            //var products=c.Products.Where(x=>x.CategoryId==category).ToList();
            //return View(products);
        }
        // [HttpPost]
        // public IActionResult Index(int category){
        //     var products=c.Products.Where(x=>x.CategoryId==category);
        //     return View(products);
        // }
        public async Task<IActionResult> AddProduct()
        {
            var client = _httpClientFactory.CreateClient();
            
         
            ViewBag.Categories = new SelectList(await GetCategories(), "CategoryId", "CategoryName");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddProduct(AddProductViewModel addProductViewModel)
        {
            var client=_httpClientFactory.CreateClient();
            var jsonData=JsonConvert.SerializeObject(addProductViewModel);
            StringContent stringContent = new StringContent(jsonData,Encoding.UTF8,"application/json");
            var responseMessage = await client.PostAsync("http://localhost:5198/api/Product", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");

            }
            return View(addProductViewModel);
        }
        [HttpGet] 
        public async Task<IActionResult> EditProduct(int id) {
            ViewBag.Categories = new SelectList(await GetCategories(), "CategoryId", "CategoryName");
            var client=_httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"http://localhost:5198/api/Product/GetProduct/{id}");
            var product = JsonConvert.DeserializeObject<EditProductViewModel>(await responseMessage.Content.ReadAsStringAsync());
            return View(product);
        }
        [HttpPost]
        public async Task<IActionResult> EditProduct(EditProductViewModel editProductViewModel,string ImageURL)
        {
            
            if (ImageURL!=null)
                editProductViewModel.Image = ImageURL;
           var client=_httpClientFactory.CreateClient();   
            var jsonData=JsonConvert.SerializeObject(editProductViewModel);
            StringContent content=new StringContent(jsonData,Encoding.UTF8,"application/json");

            var responseMessage = await client.PutAsync("http://localhost:5198/api/Product", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }


            return View(editProductViewModel);
        }
        public async Task<IActionResult> DeleteProduct(int? id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"http://localhost:5198/api/Product/GetProduct/{id}");
            var product = JsonConvert.DeserializeObject<ProductViewModel>(await responseMessage.Content.ReadAsStringAsync());
            return View(product);

            
        }
        [HttpPost]
        public async Task<IActionResult> DeleteProduct(int ProductId)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"http://localhost:5198/api/Product/{ProductId}");
           
            return RedirectToAction("Index");
           
        }
     
    }
}
