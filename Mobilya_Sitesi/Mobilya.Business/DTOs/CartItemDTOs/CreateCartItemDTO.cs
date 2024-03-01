﻿using Mobilya.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mobilya.Business.DTOs.CartItemDTOs
{
    public class CreateCartItemDTO
    {


        public int Quantity { get; set; }
        public int ProductId { get; set; }
        public Product? Product { get; set; }
        public int CartId { get; set; }
        public Cart? Cart { get; set; }

    }
}