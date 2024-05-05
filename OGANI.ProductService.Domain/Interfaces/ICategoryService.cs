using System;
using OGANI.ProductService.Domain.Models;

namespace OGANI.ProductService.Domain.Interfaces
{
	public interface ICategoryService
	{
        Task<Category?> CreateCategoryAsync(Category category);
        Task UpdateCategoryAsync(Category category);
        Task<bool> DeleteCategoryAsync(int categoryId);
        Task<IEnumerable<Category>> GetCategoriesAsync();

    }
}

