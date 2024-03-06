using Microsoft.AspNetCore.Mvc;
using Mobilya_Sitesi.Models.ViewModels.Cart;
using Newtonsoft.Json;
using System.Security.Claims;
using System.Text;

namespace Mobilya_Sitesi.Controllers
{
    public class CartController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public CartController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        [NonAction]
        public async Task<ResultCartViewModel> GetCartByUserId()
        {
            var userId=Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var client=_httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"http://localhost:5198/api/Cart/GetCartByUserId/{userId}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData=await responseMessage.Content.ReadAsStringAsync();
                var value=JsonConvert.DeserializeObject<ResultCartViewModel>(jsonData);
                return value;
            }
            return null;
        } 
        
        public async Task<IActionResult> AddToCart(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var cart= await GetCartByUserId();
            var cartId = cart.CartId;
            
            AddToCartViewModel addToCartViewModel = new AddToCartViewModel()
            {
                ProductId = id,
                CartId=cartId,
            };
            
            var jsonData = JsonConvert.SerializeObject(addToCartViewModel);
            StringContent content = new StringContent(jsonData,Encoding.UTF8,"application/json");
            var responseMessage = await client.PostAsync("http://localhost:5198/api/Cart/AddToCart", content);
           
            return RedirectToAction("Index","User");
        }
        public async Task<IActionResult> GoToCart(bool? id=null)
        {
            ResultCartViewModel resultCartViewModel;
            resultCartViewModel =await GetCartByUserId();
            if (id == null)
            {
            
                resultCartViewModel.IsSucessed = null;
                return View(resultCartViewModel);
            }
           else if (id == true)
            {
                
                resultCartViewModel.IsSucessed= true;
            }
            else
            {
                resultCartViewModel.IsSucessed=false;
            }
            return View(resultCartViewModel);

        }
        [HttpPost]
        public async Task<JsonResult> ChangeQuantity(int cartItemId, int quantity)
        {
            ChangeQuantityViewModel changeQuantityViewModel = new ChangeQuantityViewModel()
            {
                CartItemId = cartItemId,
                Quantity = quantity
            };
            var client=_httpClientFactory.CreateClient();
            var jsonData= JsonConvert.SerializeObject(changeQuantityViewModel);
            StringContent content=new StringContent(jsonData,Encoding.UTF8,"application/json");
            var responseMessage = await client.PostAsync("http://localhost:5198/api/Cart/ChangeQuantity", content);
            if(responseMessage.IsSuccessStatusCode)
            {
                return Json(await responseMessage.Content.ReadAsStringAsync());
            }
            return Json(null);
        }
    }
}
