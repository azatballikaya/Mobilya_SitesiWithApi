﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mobilya.Business.DTOs.CartItemDTOs
{
    public class ChangeQuantityDTO
    {
        public int CartItemId { get; set; }
        public int Quantity { get; set; }
        public double CartItemPrice { get; set; }
        public double CartTotalPrice { get; set; }

    }
}
