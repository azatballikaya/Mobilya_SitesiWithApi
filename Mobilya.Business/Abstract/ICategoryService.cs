using Microsoft.Data.SqlClient.DataClassification;
using Mobilya.Business.DTOs.CategoryDTOs;
using Mobilya.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mobilya.Business.Abstract
{
    public interface ICategoryService
    {
        List<Category> GetCategories();
        List<Category> GetCategoriesWithProducts();
        Category GetCategory(int id);
        Category GetCategoryWithProducts(int id);
        void AddCategory(CreateCategoryDTO addCategoryDTO);
        void DeleteCategory(int id);
        void UpdateCategory(UpdateCategoryDTO category);
    }
}
