using Microsoft.AspNetCore.Mvc;
using Mobilya_Sitesi.Models.ViewModels.Product;
using Newtonsoft.Json;

namespace Mobilya_Sitesi.Areas.Admin.ViewComponents
{
	public class IndexProductViewComponent:ViewComponent
	{
		private readonly IHttpClientFactory _httpClientFactory;

        public IndexProductViewComponent(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync(int id=0)
		{
            var client = _httpClientFactory.CreateClient();
			HttpResponseMessage responseMessage;
            if (id== 0)
			{
                responseMessage = await client.GetAsync("http://localhost:5198/api/Product/GetAllProductsWithCategories");
            }
            else
            {
            responseMessage = await client.GetAsync($"http://localhost:5198/api/Product/GetProductsByCategoryId/{id}");
                
            }
			
			
			if(responseMessage.IsSuccessStatusCode)
			{
				var jsonData=await responseMessage.Content.ReadAsStringAsync();
				var values=JsonConvert.DeserializeObject<List<ListProductViewModel>> (jsonData);
				return View(values);
			}
			return View();
		}
	}
}
