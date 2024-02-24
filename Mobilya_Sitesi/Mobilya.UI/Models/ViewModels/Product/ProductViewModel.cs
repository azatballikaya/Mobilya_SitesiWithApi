namespace Mobilya_Sitesi.Models.ViewModels.Product
{
    public class ProductViewModel
    {
        public int ProductId { get; set; }
        public string? ProductName { get; set; }
        public double Price { get; set; }
        public string? Description { get; set; }
        public string? Image { get; set; }
        public int CategoryId { get; set; }
        public string  CategoryName { get; set;}
    }
}
