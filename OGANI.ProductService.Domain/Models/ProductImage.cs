using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OGANI.ProductService.Domain.Models;

public partial class ProductImage
{
    public int ImageId { get; set; }

    [Required(ErrorMessage = "ImageUrl is required")]
    [MaxLength(255, ErrorMessage = "ImageUrl cannot exceed 255 characters")]
    public string ImageUrl { get; set; } = null!;

    [Required(ErrorMessage = "ProductId is required")]
    public int ProductId { get; set; }

    //public virtual Product Product { get; set; } = null!;
}
