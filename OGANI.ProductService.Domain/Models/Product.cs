using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OGANI.ProductService.Domain.Models;

public partial class Product
{
    public int ProductId { get; set; }
 
    [Required(ErrorMessage = "ProuductName is required")]
    [MaxLength(100, ErrorMessage = "ProuductName cannot exceed 100 characters")]
    public string ProuductName { get; set; } = null!;

    [Required(ErrorMessage = "Price is required")]
    public decimal Price { get; set; }

    [Required(ErrorMessage = "Quantity is required")]
    public int? Quantity { get; set; }

    [Required(ErrorMessage = "CategoryId is required")]
    public int CategoryId { get; set; }

    //public virtual Category Category { get; set; } = null!;

    public virtual ICollection<ProductImage> ProductImages { get; set; } = new List<ProductImage>();

    //public virtual ICollection<ProductReview> ProductReviews { get; set; } = new List<ProductReview>();
}
