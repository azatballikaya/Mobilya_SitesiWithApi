using Mobilya_Sitesi.Models.ViewModels.CartItem;
using Mobilya_Sitesi.Models.ViewModels.User;

namespace Mobilya_Sitesi.Models.ViewModels.Cart
{
    public class ResultCartViewModel
    {
        public int CartId { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public int UserId { get; set; }
        public ResultUserViewModel User { get; set; }
        public bool?  IsSucessed { get; set; }
        public List<ResultCartItemViewModel> CartItems { get; set; }

        public decimal TotalPrice()
        {
            return Convert.ToDecimal(CartItems.Sum(x => x.Product.Price* x.Quantity));
        }

    }
}
