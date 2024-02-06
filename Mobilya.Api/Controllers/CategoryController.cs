using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mobilya.Business.Abstract;
using Mobilya.Business.DTOs.CategoryDTOs;
using Mobilya.DataAccess.Abstract;

namespace Mobilya.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet("{id}")]
        public IActionResult GetCategory(int id)
        {
           var category= _categoryService.GetCategory(id);
            return Ok(category);
        }
        [HttpGet("GetCategoryWithProducts/{id}")]
        public IActionResult GetCategoryWithProducts(int id)
        {
            var category=_categoryService.GetCategoryWithProducts(id);
            return Ok(category);
        }
        [HttpGet]
        public IActionResult GetCategoryList()
        {
            var categoryList = _categoryService.GetCategories();
            return Ok(categoryList);
        }
        [HttpGet("GetAllCategoriesWithProducts")]
        public IActionResult GetAllCategoriesWithProducts()
        {
            var categoryList = _categoryService.GetCategoriesWithProducts();
            return Ok(categoryList);
        }
        [HttpPost("AddCategory")]
        public IActionResult AddCategory(CreateCategoryDTO createCategoryDTO)
        {
            _categoryService.AddCategory(createCategoryDTO);
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteCategory(int id)
        {
            _categoryService.DeleteCategory(id);
            return Ok();
        }
        [HttpPut]
        public IActionResult UpdateCategory(UpdateCategoryDTO updateCategoryDTO)
        {
            _categoryService.UpdateCategory(updateCategoryDTO);
            return Ok();
        }
    }
}
