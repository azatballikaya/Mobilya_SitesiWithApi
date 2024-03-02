using Mobilya_Sitesi.Models.ViewModels.Product;

namespace Mobilya_Sitesi.Models.ViewModels.OrderDetail
{
    public class ResultOrderDetailViewModel
    {
        public int OrderDetailId { get; set; }
        
        
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public int Quantity { get; set; }
        public int ProductId { get; set; }
        public ProductViewModel Product { get; set; }
        public decimal Price { get; set; }
    }
}
