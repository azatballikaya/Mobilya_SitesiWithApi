using Mobilya.Business.DTOs.OrderDetailDTOs;
using Mobilya.Business.DTOs.UserDTOs;
using Mobilya.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Mobilya.Entity.Order;

namespace Mobilya.Business.DTOs.OrderDTOs
{
    public class UpdateOrderDTO
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string CardNumber { get; set; }
        public string ExpirationMonth { get; set; }
        public string ExpirationYear { get; set; }
        public string Cvv { get; set; }
        public string Adress { get; set; }
        public int UserId { get; set; }
       
       


    }
}
