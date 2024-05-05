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
	public class ProductRepository : IProductRepository
    {
        private readonly OganiDbContext _oganiDbContext;
        private readonly IMapper _mapper;

        public ProductRepository(OganiDbContext oganiDbContext, IMapper mapper)
		{
            this._oganiDbContext = oganiDbContext;
            this._mapper = mapper;

        }

        public  async Task<Product> CreateProductAsync(Product product)
        {
            var productEntity = this._mapper.Map<db_entities.Product>(product);
            _oganiDbContext.Products.Add(productEntity);
            await _oganiDbContext.SaveChangesAsync();
            product.ProductId = productEntity.ProductId;
            return product;

        }

        public async Task<bool> DeleteProductAsync(int productId)
        {
            var product = _oganiDbContext.Products.Find(productId);

            if (product != null)
            {
                _oganiDbContext.Products.Remove(product);
                await _oganiDbContext.SaveChangesAsync();
                return true;
            }
            return false;
            
        }

        public async Task UpdateProductAsync(Product product)
        {

            //todo
            _oganiDbContext.Entry(product).State = EntityState.Modified;
            await _oganiDbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            return await _oganiDbContext.Products
                 .Include(p=>p.ProductImages)
                 .ProjectTo<Product>(_mapper.ConfigurationProvider).AsNoTracking().ToListAsync();
               
        }

        public async Task<Product?> GetProductByIdAsync(int productId)
        {
            return await _oganiDbContext.Products
                  .Include(p=>p.ProductImages)
                  .ProjectTo<Product>(_mapper.ConfigurationProvider).FirstOrDefaultAsync(product=>product.ProductId==productId);
        }

        public async Task<IEnumerable<Product>> GetProductsByCategoryIdAsync(int categoryId)
        {
            return await _oganiDbContext.Products
                  .Include(p=>p.ProductImages)
                  .ProjectTo<Product>(_mapper.ConfigurationProvider).Where(product => product.CategoryId == categoryId).ToListAsync();
        }

      
    }
}

