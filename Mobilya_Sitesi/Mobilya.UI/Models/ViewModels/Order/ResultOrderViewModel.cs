using Mobilya_Sitesi.Models.ViewModels.User;
using Mobilya_Sitesi.Models.ViewModels.OrderDetail;

namespace Mobilya_Sitesi.Models.ViewModels.Order
{
    public class ResultOrderViewModel
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string CardNumber { get; set; }
        public string ExpirationMonth { get; set; }
        public string ExpirationYear { get; set; }
        public string Cvv { get; set; }
        public string Adress { get; set; }
        public int UserId { get; set; }

        public ResultUserViewModel User { get; set; }
        public List<ResultOrderDetailViewModel> OrderDetails { get; set; }
    }
}
