using Mobilya.Business.DTOs.OrderDetailDTOs;
using Mobilya.Business.DTOs.OrderDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mobilya.Business.Abstract
{
    public interface IOrderService
    {
        void CreateOrder(CreateOrderDTO createOrderDTO);
        void UpdateOrder(UpdateOrderDTO updateOrderDTO);
        void DeleteOrder(int id);
        void AddOrderDetailToOrder(int quantity, int productId);
       
        ResultOrderDTO GetOrderByUserId(int id);
        List<ResultOrderDTO> GetAllOrders();
        
    }
}
