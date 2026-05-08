using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using UESAN.SHOPPING.CORE.Core.Entities;
using UESAN.SHOPPING.CORE.Core.Interfaces;
using UESAN.SHOPPING.CORE.Infrastructure.Data;

namespace UESAN.SHOPPING.CORE.Infrastructure.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly StoreDbContext _context;
        public CategoryRepository(StoreDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Category>> GetCategories()
        {
            return await _context.Category.Where(c => c.IsActive == true).ToListAsync();
        }
        public async Task<Category> GetCategoryById(int id)
        {
            return await _context.Category.Where(c => c.Id == id).FirstOrDefaultAsync();
        }
        //Create Category
        public async Task CreateCategory(Category category)
        {
            _context.Category.Add(category);
            await _context.SaveChangesAsync();
        }
        //Update Category
        public async Task UpdateCategory(Category category)
        {
            var existingCategory = await _context.Category.Where(c => c.Id == category.Id).FirstOrDefaultAsync();
            if (existingCategory != null)
            {
                existingCategory.Description = category.Description;
                await _context.SaveChangesAsync();
            }
        }
        //Delete Category
        public async Task DeleteCategory(int id)
        {
            var existingCategory = await _context.Category.Where(c => c.Id == id).FirstOrDefaultAsync();
            if (existingCategory != null)
            {
                existingCategory.IsActive = false;
                await _context.SaveChangesAsync();
            }
        }
    }
}
