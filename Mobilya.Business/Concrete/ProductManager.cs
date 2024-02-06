using AutoMapper;
using Mobilya.Business.Abstract;
using Mobilya.Business.DTOs.ProductDTOs;
using Mobilya.DataAccess.Abstract;
using Mobilya.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mobilya.Business.Concrete
{
    public class ProductManager:IProductService
    {
        private readonly IProductDal _productDal;
        private readonly IMapper _mapper;

        public ProductManager(IProductDal productDal, IMapper mapper)
        {
            _productDal = productDal;
            _mapper = mapper;
        }

        public void CreateProduct(CreateProductDTO createProductDTO)
        {
           var product=_mapper.Map<Product>(createProductDTO);
            _productDal.Insert(product);
        }

        public void DeleteProduct(int id)
        {
            var product=_productDal.Get(x=>x.ProductId==id);
            _productDal.Delete(product);
        }

        public List<GetProductWithCategoryDTO> GetAllProducts()
        {
            var productList= _productDal.GetAllProductsWithCategories();
            return _mapper.Map<List<GetProductWithCategoryDTO>>(productList);
        }

        public List<GetProductWithCategoryDTO> GetAllProductsWithCategories()
        {
            var productList= _productDal.GetAllProductsWithCategories();
            var result=_mapper.Map<List<GetProductWithCategoryDTO>>(productList);
            return result;
        }

        public Product GetProduct(int id)
        {
            return _productDal.GetById(id);
        }

        public Product GetProductWithCategory(int id)
        {
            return _productDal.GetProductWithCategory(id);
        }

        public List<Product> GetProductsByCategoryId(int id)
        {
            return _productDal.GetProductsByCategoryId(id);
        }

        public void UpdateProduct(UpdateProductDTO updateProductDTO)
        {
            var product=_mapper.Map<Product>(updateProductDTO);
            _productDal.Update(product);
        }
    }
}
