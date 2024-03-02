﻿using Microsoft.AspNetCore.Http;
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
        [HttpGet("GetOrderByUserId/{id}")]
        public IActionResult GetOrderByUserId(int id)
        {
            var order=_orderService.GetOrderByUserId(id);
            return Ok(order);
        }
        [HttpPost("CreateOrder")]
        public IActionResult CreateOrder(CreateOrderDTO createOrderDTO)
        {
            _orderService.CreateOrder(createOrderDTO);
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteOrder(int id)
        {
            _orderService.DeleteOrder(id);
            return Ok();
        }
        
    }
}