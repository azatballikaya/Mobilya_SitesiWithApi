using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Mobilya.Entity
{
    public class Product
    {
        public int ProductId { get; set; }
        public string? ProductName { get; set; }
        public double Price { get; set; }
        public string? Description { get; set; }
        public string? Image { get; set; }
        public int CategoryId { get; set; }
       
        public Category Category { get; set; }
    }
}
