using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mobilya.Business.Abstract;
using Mobilya.Business.DTOs.ProductDTOs;
using Newtonsoft.Json;
using System.Text.Json;

namespace Mobilya.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpGet("GetProduct/{id}")]
        public IActionResult GetProductById(int id)
        {
            var product=_productService.GetProduct(id);
            return Ok(product);
        }
        [HttpGet("GetProductWithCategory/{id}")]
        public IActionResult GetProductByIdWithCategory(int id)
        {
            var product = _productService.GetProductWithCategory(id);
            
            return Ok(product);
        }
        [HttpGet("GetProductsByCategoryId/{id}")]
        public IActionResult GetProductsByCategoryId(int id)
        {
            var product = _productService.GetProductsByCategoryId(id);
            return Ok(product);
        }
        [HttpGet("GetAllProducts")]
        public IActionResult GetAllProducts()
        {
            var productList=  _productService.GetAllProducts();
            return Ok(productList);
        }
        [HttpGet("GetAllProductsWithCategories")]
        public IActionResult GetAllProductsWithCategories()
        {
            var productList=_productService.GetAllProductsWithCategories();
            
            return Ok(productList);
        }
        [HttpPost]
        public IActionResult AddProduct(CreateProductDTO createProductDTO)
        {
            _productService.CreateProduct(createProductDTO);
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            _productService.DeleteProduct(id);
            return Ok();
        }
        [HttpPut]
        public IActionResult UpdateProduct(UpdateProductDTO updateProductDTO)
        {
            _productService.UpdateProduct(updateProductDTO);
            return Ok();
        }
    }
}
