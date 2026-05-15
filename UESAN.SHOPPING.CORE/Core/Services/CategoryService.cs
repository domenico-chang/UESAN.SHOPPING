using System;
using System.Collections.Generic;
using System.Text;
using UESAN.SHOPPING.CORE.Core.DTOs;
using UESAN.SHOPPING.CORE.Core.Entities;
using UESAN.SHOPPING.CORE.Core.Interfaces;

namespace UESAN.SHOPPING.CORE.Core.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public async Task<IEnumerable<CategoryListDTO>> GetCategories()
        {
            var categories = await _categoryRepository.GetCategories();
            var categoriesDTOs = new List<CategoryListDTO>();
            foreach (var category in categories)
            {
                categoriesDTOs.Add(new CategoryListDTO
                {
                    Id = category.Id,
                    Description = category.Description
                });
            }
            return categoriesDTOs;
        }
        public async Task<CategoryListDTO> GetCategoryById(int id)
        {
            var category = await _categoryRepository.GetCategoryById(id);
            if (category == null)
            {
                return null;
            }
            return new CategoryListDTO
            {
                Id = category.Id,
                Description = category.Description
            };
        }
        public async Task CreateCategory(CategoryCreateDTO categoryCreateDTO)
        {
            var category = new Category
            {
                Description = categoryCreateDTO.Description,
                IsActive = true
            };
            await _categoryRepository.CreateCategory(category);
        }
        public async Task UpdateCategory(CategoryUpdateDTO categoryUpdateDTO)
        {
            var existingCategory = await _categoryRepository.GetCategoryById(categoryUpdateDTO.Id);
            if (existingCategory != null)
            {
                existingCategory.Description = categoryUpdateDTO.Description;
                await _categoryRepository.UpdateCategory(existingCategory);
            }
        }
        public async Task DeleteCategory(CategoryDeleteDTO categoryDeleteDTO)
        {
            await _categoryRepository.DeleteCategory(categoryDeleteDTO.Id);
        }
    }
}
