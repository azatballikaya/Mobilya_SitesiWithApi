using Mobilya_Sitesi.Models;
namespace Mobilya_Sitesi.Models.ViewModels.Category
{
    public class CategoryViewModel
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

        public List<Mobilya_Sitesi.Models.Product> Products { get; set; }
    }
}
