using UESAN.SHOPPING.CORE.Core.Entities;

namespace UESAN.SHOPPING.CORE.Core.Interfaces
{
    public interface ICategoryRepository
    {
        Task CreateCategory(Category category);
        Task DeleteCategory(int id);
        Task<IEnumerable<Category>> GetCategories();
        Task<Category> GetCategoryById(int id);
        Task UpdateCategory(Category category);
    }
}