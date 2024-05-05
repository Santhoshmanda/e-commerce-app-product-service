using OGANI.ProductService.Domain.Interfaces;
using OGANI.ProductService.Domain.Models;

namespace OGANI.ProductService.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
		public CategoryService(ICategoryRepository categoryRepository)
		{
            this._categoryRepository = categoryRepository;
		}

        public async Task<Category?> CreateCategoryAsync(Category category)
        {
            return await _categoryRepository.CreateCategoryAsync(category);
        }

        public async Task<bool> DeleteCategoryAsync(int categoryId)
        {
            return await _categoryRepository.DeleteCategoryAsync(categoryId);
        }

        public async Task<IEnumerable<Category>> GetCategoriesAsync()
        {
            return await _categoryRepository.GetCategoriesAsync();
        }

        public async Task UpdateCategoryAsync(Category category)
        {
             await _categoryRepository.UpdateCategoryAsync(category);
        }
    }
}

