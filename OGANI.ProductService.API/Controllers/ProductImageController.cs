using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OGANI.ProductService.Application.Services;
using OGANI.ProductService.Domain.Interfaces;
using OGANI.ProductService.Domain.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OGANI.ProductService.API.Controllers
{
    [Route("api/[controller]")]
    public class ProductImageController : Controller
    {

        private readonly IProductImageService _productImageService;
        public ProductImageController(IProductImageService productImageService)
        {
            _productImageService = productImageService;
        }

       
        //Task<bool> DeleteImageAsync(int productImageId);


        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductImage>> GetImageByImageId(int id)
        {
            var products = await _productImageService.GetImageByImageId(id);
            if (products == null)
            {
                return NotFound();
            }

            return Ok(products);
        }

        [HttpGet("category/{id}")]
        public async Task<ActionResult<IEnumerable<ProductImage>>> GetImagesByProductIdAsync(int id)
        {
            var products = await _productImageService.GetImagesByProductIdAsync(id);
            if (products == null)
            {
                return NotFound();
            }

            return Ok(products);
        }

        [HttpPost]
        public async Task<ActionResult<ProductImage>> AddImageAsync([FromBody] ProductImage productImage)
        {
            var createdImage = await _productImageService.AddImageAsync(productImage);
            return CreatedAtAction(nameof(AddImageAsync), createdImage);
        }


        [HttpPut("{productImageId}")]
        public async Task<IActionResult> UpdateImageAsync(int productImageId, [FromBody] ProductImage productImage)
        {
            if (productImageId != productImage.ProductId)
            {
                return BadRequest("productImageId in the request body does not match the URL parameter.");
            }

            await _productImageService.UpdateImageAsync(productImage);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteImageAsync(int id)
        {
            var isSuccess = await _productImageService.DeleteImageAsync(id);
            if (!isSuccess)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}

