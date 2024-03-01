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
        private readonly IMapper _mapper;

        public OrderManager(IOrderDal orderDal, IOrderDetailDal orderDetailDal, IMapper mapper)
        {
            _orderDal = orderDal;
            _orderDetailDal = orderDetailDal;
            _mapper = mapper;
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
            var order=_mapper.Map<Order>(createOrderDTO);
            _orderDal.Insert(order);
        }

        public void DeleteOrder(int id)
        {
            var order=_orderDal.GetById(id);
            _orderDal.Delete(order);
        }

        public List<ResultOrderDTO> GetAllOrders()
        {
            var orderList = _orderDal.GetAll(include: x => x.Include(y => y.OrderDetails).Include(z => z.User));
            var dtos=_mapper.Map<List<ResultOrderDTO>>(orderList);
            return dtos;
        }

        public ResultOrderDTO GetOrderByUserId(int id)
        {
            var orderList = _orderDal.GetAll(include: x => x.Include(y => y.OrderDetails).Include(z => z.User));
            var dto = _mapper.Map<ResultOrderDTO>(orderList);
            return dto;
        }

        public void UpdateOrder(UpdateOrderDTO updateOrderDTO)
        {
           var order=_mapper.Map<Order>(updateOrderDTO); 
            _orderDal.Update(order);
        }
    }
}
