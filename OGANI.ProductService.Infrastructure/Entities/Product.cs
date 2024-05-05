using System;
using System.Collections.Generic;

namespace OGANI.ProductService.Infrastructure.Entities;

public partial class Product
{
    public int ProductId { get; set; }

    public string ProuductName { get; set; } = null!;

    public decimal Price { get; set; }

    public int? Quantity { get; set; }

    public int CategoryId { get; set; }

    public virtual Category Category { get; set; } = null!;

    public virtual ICollection<ProductImage> ProductImages { get; set; } = new List<ProductImage>();

    public virtual ICollection<ProductReview> ProductReviews { get; set; } = new List<ProductReview>();
}
