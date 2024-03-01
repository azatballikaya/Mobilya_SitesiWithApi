using Mobilya.Business.DTOs.OrderDetailDTOs;
using Mobilya.Business.DTOs.OrderDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mobilya.Business.Abstract
{
    public interface IOrderDetailService
    {
        void CreateOrderDetail(CreateOrderDetailDTO createOrderDetailDTO);
        void UpdateOrderDetail(UpdateOrderDetailDTO updateOrderDetailDTO);
        void DeleteOrderDetail(int id);
        ResultOrderDetailDTO GetOrderDetail(int id);
        List<ResultOrderDetailDTO> GetAllOrderDetails();
    }
}
