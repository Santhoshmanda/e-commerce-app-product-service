using Microsoft.AspNetCore.Mvc;
using OGANI.ProductService.Application.Services;
using OGANI.ProductService.Domain.Interfaces;
using OGANI.ProductService.Domain.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OGANI.ProductService.API.Controllers
{
    [Route("api/[controller]")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }


        // GET: api/values
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> GetCategoriesAsync()
        {
            var categories = await _categoryService.GetCategoriesAsync();
            if (categories == null)
            {
                return NotFound();
            }

            return Ok(categories);
        }

        [HttpPost]
        public async Task<ActionResult<Category>> CreateCategoryAsync([FromBody] Category category)
        {
            var createdUserProfile = await _categoryService.CreateCategoryAsync(category);
            return CreatedAtAction(nameof(CreateCategoryAsync), createdUserProfile);
        }


        [HttpPut("{categoryId}")]
        public async Task<IActionResult> UpdateCategoryAsync(int categoryId, [FromBody] Category category)
        {
            if (categoryId != category.CategoryId)
            {
                return BadRequest("categoryId in the request body does not match the URL parameter.");
            }

            await _categoryService.UpdateCategoryAsync(category);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategoryAsync(int id)
        {
            var isSuccess = await _categoryService.DeleteCategoryAsync(id);
            if (!isSuccess)
            {
                return NotFound();
            }

            return NoContent();
        }




    }
}

