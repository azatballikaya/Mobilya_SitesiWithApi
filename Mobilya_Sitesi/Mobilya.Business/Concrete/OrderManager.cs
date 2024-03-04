using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Mobilya.Business.Abstract;
using Mobilya.Business.DTOs.OrderDetailDTOs;
using Mobilya.Business.DTOs.OrderDTOs;
using Mobilya.DataAccess.Abstract;
using Mobilya.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mobilya.Business.Concrete
{
    public class OrderManager : IOrderService
    {
        private readonly IOrderDal _orderDal;
        private readonly IOrderDetailDal _orderDetailDal;
        private readonly ICartService _cartService;
        private readonly ICartItemService _cartItemService;
        private readonly IMapper _mapper;

        public OrderManager(IOrderDal orderDal, IOrderDetailDal orderDetailDal, IMapper mapper, ICartService cartService, ICartItemService cartItemService)
        {
            _orderDal = orderDal;
            _orderDetailDal = orderDetailDal;
            _mapper = mapper;
            _cartService = cartService;
            _cartItemService = cartItemService;
        }

        public void AddOrderDetailToOrder(int quantity,int productId)
        {

            _orderDetailDal.Insert(new OrderDetail
            {
                Quantity = quantity,
                ProductId = productId,
                Price = 0
            });
        }

        public void CreateOrder(CreateOrderDTO createOrderDTO)
        {
            var order = _orderDal.Insert(new Order
            {
                Cvv = createOrderDTO.Cvv,
                CardNumber = createOrderDTO.CardNumber,
                ExpirationMonth = createOrderDTO.ExpirationMonth,
                ExpirationYear = createOrderDTO.ExpirationYear,
                FullName = createOrderDTO.FullName,
                UserId = createOrderDTO.UserId,
            });
             var cart=   _cartService.GetCartByUserId(createOrderDTO.UserId);
            foreach (var cartItem in cart.CartItems)
            {
                _orderDetailDal.Insert(new OrderDetail
                {
                    Quantity = cartItem.Quantity,
                    ProductId = cartItem.ProductId,
                    CreatedDate = DateTime.Now,
                    OrderId=order.Id,
                    Price = Convert.ToDecimal(cartItem.Quantity * cartItem.Product.Price),

                });
            }
            _cartItemService.ClearCart(createOrderDTO.UserId);

        }
       
        public void DeleteOrder(int id)
        {
            var order=_orderDal.Get(x=>x.Id==id, x=>x.Include(y=>y.OrderDetails));
           
           
            _orderDal.Delete(order);
        }

        public List<ResultOrderDTO> GetAllOrders()
        {
            var orderList = _orderDal.GetAll(include:x=>x.Include(u=>u.User).Include(y=>y.OrderDetails).ThenInclude(k=>k.Product));
            var dtos=_mapper.Map<List<ResultOrderDTO>>(orderList);
            return dtos;
        }

        public List<ResultOrderDTO> GetOrderByUserId(int userId)
        {
            var orderList = _orderDal.GetAll(filter:x=>x.UserId==userId,include: x => x.Include(z => z.User).Include(y => y.OrderDetails).ThenInclude(k => k.Product));
            var dto = _mapper.Map<List<ResultOrderDTO>>(orderList);
            return dto;
        }
        public ResultOrderDTO GetOrderById(int id)
        {
            var order=_orderDal.Get(x=>x.Id==id,x=>x.Include(z=>z.OrderDetails));
            var dto=_mapper.Map<ResultOrderDTO>(order);
            return dto;
        }

        public void UpdateOrder(UpdateOrderDTO updateOrderDTO)
        {
           var order=_mapper.Map<Order>(updateOrderDTO); 
            _orderDal.Update(order);
        }
    }
}
