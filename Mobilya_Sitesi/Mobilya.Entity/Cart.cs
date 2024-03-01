using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mobilya.Entity
{
    public class Cart
    {
        public int CartId { get; set; }
        public DateTime CreatedDate { get; set; }=DateTime.Now;
        public int UserId { get; set; }
        public User User { get; set; }
        public List<CartItem> CartItems { get; set; }
        public decimal TotalPrice()
        {
            return Convert.ToDecimal(CartItems.Sum(x => x.Quantity * x.Product.Price));
    }
    }
   
}

