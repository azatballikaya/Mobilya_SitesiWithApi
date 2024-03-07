using Microsoft.AspNetCore.Mvc;
using Mobilya_Sitesi.Models.ViewModels.Advice;
using Newtonsoft.Json;
using System.Text;

namespace Mobilya_Sitesi.Controllers
{
    public class AdviceController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdviceController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpPost]
        public async Task<bool> CreateAdvice(CreateAdviceViewModel createAdviceViewModel)
        {
            var client=_httpClientFactory.CreateClient();
            var jsonData=JsonConvert.SerializeObject(createAdviceViewModel);
            StringContent content = new StringContent(jsonData,Encoding.UTF8,"application/json");
            var responseMessage = await client.PostAsync("http://localhost:5198/api/Advice", content);
            if(responseMessage.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }
    }
}
