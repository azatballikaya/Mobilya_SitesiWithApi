using Mobilya.Business.DTOs.ProductDTOs;
using Mobilya.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mobilya.Business.Abstract
{
    public interface IProductService
    {
        Product GetProduct(int id);
        Product GetProductWithCategory(int id);
        List<GetProductWithCategoryDTO> GetAllProducts();
        List<GetProductWithCategoryDTO> GetAllProductsWithCategories();
        List<Product> GetProductsByCategoryId(int id);
        void CreateProduct(CreateProductDTO createProductDTO);
        void DeleteProduct(int id);
        void UpdateProduct(UpdateProductDTO updateProductDTO);

    }
}
