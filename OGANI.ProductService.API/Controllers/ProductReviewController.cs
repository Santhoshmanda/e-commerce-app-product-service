using Microsoft.AspNetCore.Mvc;
using OGANI.ProductService.Application.Services;
using OGANI.ProductService.Domain.Interfaces;
using OGANI.ProductService.Domain.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OGANI.ProductService.API.Controllers
{
    [Route("api/[controller]")]
    public class ProductReviewController : Controller
    {

        private readonly IProductReviewService _productReviewService;
        public ProductReviewController(IProductReviewService productReviewService)
        {
            _productReviewService = productReviewService;
        }

        [HttpGet("product/{productReviewId}")]
        public async Task<ActionResult<ProductReview>> GetReviewsByProductIdAsync(int productReviewId)
        {
            var products = await _productReviewService.GetReviewsByProductIdAsync(productReviewId);
            if (products == null)
            {
                return NotFound();
            }

            return Ok(products);
        }

        [HttpPost]
        public async Task<ActionResult<ProductReview>> CreateReviewAsync([FromBody] ProductReview productReview)
        {
            var createdUserProfile = await _productReviewService.CreateReviewAsync(productReview);
            return CreatedAtAction(nameof(CreateReviewAsync), createdUserProfile);
        }


        [HttpPut("{productReviewId}")]
        public async Task<IActionResult> UpdateReviewAsync(int productReviewId, [FromBody] ProductReview productReview)
        {
            if (productReviewId != productReview.ReviewId)
            {
                return BadRequest("productReviewId in the request body does not match the URL parameter.");
            }

            await _productReviewService.UpdateReviewAsync(productReview);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReviewAsync(int id)
        {
            var isSuccess = await _productReviewService.DeleteReviewAsync(id);
            if (!isSuccess)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}

