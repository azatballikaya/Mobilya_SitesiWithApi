using Mobilya_Sitesi.Models.ViewModels.User;

namespace Mobilya_Sitesi.Models.ViewModels.Order
{
    public class CreateOrderViewModel
    {
        public string FullName { get; set; }
        public string CardNumber { get; set; }
        public string ExpirationMonth { get; set; }
        public string ExpirationYear { get; set; }
        public string Cvv { get; set; }
        public string Adress { get; set; }
        public int UserId { get; set; }
       
    }
}
