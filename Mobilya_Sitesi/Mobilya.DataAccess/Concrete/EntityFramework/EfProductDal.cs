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
    public class EfProductDal : GenericRepository<Product>,IProductDal
    {
        private readonly Context _context;
        public EfProductDal(Context context) : base(context)
        {
            _context = context;
        }

        public Product GetProductWithCategory(int id)
        {
          return  _context.Products.Where(p=>p.ProductId == id).Include(p => p.Category).SingleOrDefault();
        }

        public List<Product> GetProductsByCategoryId(int id)
        {
            return _context.Products.Include(x=>x.Category).Where(p => p.CategoryId == id).ToList();
           
        }
        public List<Product> GetAllProductsWithCategories()
        {
            return _context.Products.Include(p => p.Category).ToList();
        }
                
    //            Include(p=>p.Category).Select(p=>new Product
    //        {
    //               ProductId =p.ProductId,
    //    ProductName =p.ProductName,
    //      Price =p.Price,
    //     Description =p.Description,
    //      Image =p.Image,
    //   CategoryId =p.CategoryId,
    //      Category =p.Category
    //}).ToList();
    //    }

    }
}
