using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mobilya.Business.DTOs.AdviceDTOs
{
    public class CreateAdviceDTO
    {
       
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Description { get; set; }
    }
}
