using Mobilya.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mobilya.DataAccess.Abstract
{
    public interface IProductDal:IGenericDal<Product>
    {
        public Product GetProductWithCategory(int id);
        public List<Product> GetProductsByCategoryId(int id);
        public List<Product> GetAllProductsWithCategories();

    }
}
