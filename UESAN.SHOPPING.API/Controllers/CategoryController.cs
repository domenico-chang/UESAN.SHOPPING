using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UESAN.SHOPPING.CORE.Core.DTOs;
using UESAN.SHOPPING.CORE.Core.Entities;
using UESAN.SHOPPING.CORE.Core.Interfaces;

namespace UESAN.SHOPPING.API.Controllers
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
        [HttpGet]
        public async Task<IActionResult> GetCategories()
        {
            var categories = await _categoryService.GetCategories();
            return Ok(categories);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoryById(int id)
        {
            var category = await _categoryService.GetCategoryById(id);
            if (category == null)
            {
                return NotFound();
            }
            return Ok(category);
        }
        [HttpPost]
        public async Task<IActionResult> CreateCategory([FromBody] CategoryCreateDTO categoryCreateDTO)
        {
            if (categoryCreateDTO == null)
            {
                return BadRequest();
            }
            await _categoryService.CreateCategory(categoryCreateDTO);
            return Ok();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategory([FromBody] CategoryUpdateDTO categoryUpdateDTO)
        {
            if (categoryUpdateDTO == null)
            {
                return BadRequest();
            }
            var existingCategory = await _categoryService.GetCategoryById(categoryUpdateDTO.Id);
            if (existingCategory == null)
            {
                return NotFound();
            }
            await _categoryService.UpdateCategory(categoryUpdateDTO);
            return NoContent();
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteCategory([FromBody] CategoryDeleteDTO categoryDeleteDTO)
        {
            var existingCategory = await _categoryService.GetCategoryById(categoryDeleteDTO.Id);
            if (existingCategory == null)
            {
                return NotFound();
            }
            await _categoryService.DeleteCategory(categoryDeleteDTO);
            return NoContent();
        }
    }
}