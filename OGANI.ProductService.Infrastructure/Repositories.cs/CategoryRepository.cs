using System;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using OGANI.ProductService.Domain.Interfaces;
using OGANI.ProductService.Domain.Models;
using OGANI.ProductService.Infrastructure.Persistance;
using db_entities=OGANI.ProductService.Infrastructure.Entities;

namespace OGANI.ProductService.Infrastructure.Repositories
{
	public class CategoryRepository: ICategoryRepository
    {
        private readonly OganiDbContext _oganiDbContext;
        private readonly IMapper _mapper;
        public CategoryRepository(OganiDbContext oganiDbContext, IMapper Mapper)
		{
            _oganiDbContext = oganiDbContext;
            _mapper = Mapper;
		}

        public async Task<Category?> CreateCategoryAsync(Category category)
        {
            var categoryEntity = _mapper.Map<db_entities.Category>(category);
            _oganiDbContext.Categories.Add(categoryEntity);
            await _oganiDbContext.SaveChangesAsync();
            category.CategoryId = categoryEntity.CategoryId;
            return category;
        }

        public async Task<bool> DeleteCategoryAsync(int categoryId)
        {
            var category =  _oganiDbContext.Categories.Find(categoryId);
            if (category != null)
            {
                _oganiDbContext.Categories.Remove(category);
                await _oganiDbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<IEnumerable<Category>> GetCategoriesAsync()
        {
            return await _oganiDbContext.Categories
                .ProjectTo<Category>(_mapper.ConfigurationProvider)
                .AsNoTracking().ToListAsync();
        }

        public async Task UpdateCategoryAsync(Category category)
        {
            _oganiDbContext.Entry(category).State = EntityState.Modified;
            await _oganiDbContext.SaveChangesAsync();

        }
    }
}

