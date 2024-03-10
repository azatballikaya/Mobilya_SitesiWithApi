using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mobilya.Business.Abstract;
using Mobilya.Business.DTOs.OrderDTOs;

namespace Mobilya.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet("GetAllOrders")]
        public IActionResult GetAllOrders()
        {
            var orders = _orderService.GetAllOrders();
            return Ok(orders);
        }
        [HttpGet("GetOrderById/{id}")]
        public async Task<IActionResult> GetOrderById(int id)
        {
            var order=_orderService.GetOrderById(id);
            return Ok(order);
        }
        [HttpGet("GetOrderByUserId/{id}")]
        public IActionResult GetOrderByUserId(int id)
        {
            var order=_orderService.GetOrderByUserId(id);
            return Ok(order);
        }
        [HttpPost("CreateOrder")]
        public IActionResult CreateOrder(CreateOrderDTO createOrderDTO)
        {
           bool isSuccess= _orderService.CreateOrder(createOrderDTO);
            if (isSuccess)
            {

            return Ok();
            }
            return BadRequest();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteOrder(int id)
        {
            _orderService.DeleteOrder(id);
            return Ok();
        }
        
    }
}
