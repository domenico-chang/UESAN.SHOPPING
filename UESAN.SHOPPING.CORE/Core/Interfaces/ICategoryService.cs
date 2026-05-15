using System;
using System.Collections.Generic;
using System.Text;
using UESAN.SHOPPING.CORE.Core.DTOs;

namespace UESAN.SHOPPING.CORE.Core.Interfaces
{
    public interface ICategoryService
    {
        Task CreateCategory(CategoryCreateDTO categoryCreateDTO);
        Task DeleteCategory(CategoryDeleteDTO categoryDeleteDTO);
        Task<IEnumerable<CategoryListDTO>> GetCategories();
        Task<CategoryListDTO> GetCategoryById(int id);
        Task UpdateCategory(CategoryUpdateDTO categoryUpdateDTO);
    }
}
