using Microsoft.EntityFrameworkCore;
using Mobilya.DataAccess.Abstract;
using Mobilya.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mobilya.DataAccess.Concrete.EntityFramework
{
    public class EfCategoryDal : GenericRepository<Category>,ICategoryDal
    {
        private readonly Context _context;
        public EfCategoryDal(Context context) : base(context)
        {
            _context = context;
        }

        public List<Category> GetCategoriesWithProducts()
        {
            return _context.Category.Include(c=>c.Products).ToList();
        }

        public Category GetCategoryWithProducts(int id)
        {
            return _context.Category.Where(c => c.CategoryId == id).Include(c => c.Products).FirstOrDefault();
        }
    }
}
