using Mobilya.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mobilya.DataAccess.Abstract
{
    public interface ICategoryDal:IGenericDal<Category>
    {
        Category GetCategoryWithProducts(int id);
        List<Category> GetCategoriesWithProducts();
    }
}
