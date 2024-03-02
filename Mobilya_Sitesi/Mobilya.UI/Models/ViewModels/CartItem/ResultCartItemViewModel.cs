using Mobilya_Sitesi.Models.ViewModels.Product;

namespace Mobilya_Sitesi.Models.ViewModels.CartItem
{
    public class ResultCartItemViewModel
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public int Quantity { get; set; }
        public int ProductId { get; set; }
        public ProductViewModel? Product { get; set; }
        public int CartId { get; set; }
       

    }
}
