using Mobilya.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mobilya.Business.DTOs.CartDTOs
{
    public class UpdateCartDTO
    {
        public int CartId { get; set; }
       
        public int UserId { get; set; }
        public User User { get; set; }
        
    }
}
