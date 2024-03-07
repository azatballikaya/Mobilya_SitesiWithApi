using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mobilya.Business.Abstract;
using Mobilya.Business.DTOs.AdviceDTOs;

namespace Mobilya.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdviceController : ControllerBase
    {
        private readonly IAdviceService _adviceService;

        public AdviceController(IAdviceService adviceService)
        {
            _adviceService = adviceService;
        }
        [HttpGet]
        public IActionResult GetAllAdvices()
        {
            var advices= _adviceService.GetAllAdvices();
            return Ok(advices);
        }
        [HttpGet("{id}")]
        public IActionResult GetAdviceById(int id)
        {
            var advice= _adviceService.GetAdviceById(id);
            return Ok(advice);
        }
        [HttpPost]
        public IActionResult CreateAdvice(CreateAdviceDTO createAdviceDTO)
        {
            _adviceService.CreateAdvice(createAdviceDTO);
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteAdvice(int id) { 
        
            _adviceService.DeleteAdvice(id);
            return Ok();
        }

    }
}
