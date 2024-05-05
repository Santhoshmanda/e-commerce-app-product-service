using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OGANI.ProductService.Domain.Interfaces;
using OGANI.ProductService.Domain.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OGANI.ProductService.API.Controllers
{
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        private readonly IProductService _productSevrice;
        public ProductController(IProductService productSevrice)
        {
            _productSevrice = productSevrice;
        }

        // GET: api/values
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetAllProductsAsync()
        {
            var products = await _productSevrice.GetAllProductsAsync();
            if (products == null)
            {
                return NotFound();
            }

            return Ok(products);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async  Task<ActionResult<Product>> GetProductByIdAsync(int id)
        {
            var products = await _productSevrice.GetProductByIdAsync(id);
            if (products == null)
            {
                return NotFound();
            }

            return Ok(products);
        }

        [HttpGet("category/{id}")]
        public  async Task<ActionResult<IEnumerable<Product>>> GetProductsByCategoryIdAsync(int id)
        {
            var products = await _productSevrice.GetProductsByCategoryIdAsync(id);
            if (products == null)
            {
                return NotFound();
            }

            return Ok(products);
        }

        [HttpPost]
        public async Task<ActionResult<Product>> CreateProductAsync([FromBody] Product product)
        {
            var createdUserProfile = await _productSevrice.CreateProductAsync(product);
            return CreatedAtAction(nameof(CreateProductAsync), createdUserProfile);
        }


        [HttpPut("{productId}")]
        public async Task<IActionResult> UpdateUser(int productId, [FromBody] Product product)
        {
            if (productId != product.ProductId)
            {
                return BadRequest("Product Id in the request body does not match the URL parameter.");
            }

            await _productSevrice.UpdateProductAsync(product);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductAsync(int id)
        {
            var isSuccess = await _productSevrice.DeleteProductAsync(id);
            if (!isSuccess)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}

