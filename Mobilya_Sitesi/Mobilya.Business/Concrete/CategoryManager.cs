using AutoMapper;
using Mobilya.Business.Abstract;
using Mobilya.Business.DTOs.CategoryDTOs;
using Mobilya.DataAccess.Abstract;
using Mobilya.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mobilya.Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private readonly ICategoryDal _categoryDal;
        private readonly IMapper _mapper;

        public CategoryManager(ICategoryDal categoryDal, IMapper mapper)
        {
            _categoryDal = categoryDal;
            _mapper = mapper;
        }

       

        public void AddCategory(CreateCategoryDTO createCategoryDTO)
        {
            var category = _mapper.Map<Category>(createCategoryDTO);
            _categoryDal.Insert(category);
        }

        public void DeleteCategory(int id)
        {
            var category = _categoryDal.GetById(id);
            _categoryDal.Delete(category);
        }

        public List<Category> GetCategories()
        {
            return _categoryDal.GetAll();
        }

        public List<Category> GetCategoriesWithProducts()
        {
            return _categoryDal.GetCategoriesWithProducts();
        }

        public Category GetCategory(int id)
        {
            return _categoryDal.GetById(id);
        }

        public Category GetCategoryWithProducts(int id)
        {
            return _categoryDal.GetCategoryWithProducts(id);
        }

        public void UpdateCategory(UpdateCategoryDTO updateCategoryDTO)
        {
            var category = _mapper.Map<Category>(updateCategoryDTO);
            _categoryDal.Update(category);
        }

        
    }
}
