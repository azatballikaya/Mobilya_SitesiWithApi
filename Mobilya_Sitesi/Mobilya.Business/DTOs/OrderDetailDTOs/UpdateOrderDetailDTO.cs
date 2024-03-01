﻿using Mobilya.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mobilya.Business.DTOs.OrderDetailDTOs
{
    public class UpdateOrderDetailDTO
    {
        public int OrderDetailId { get; set; }
       
        public int Quantity { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public decimal Price { get; set; }
    }
}