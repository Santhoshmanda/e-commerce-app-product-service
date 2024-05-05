using System;
using System.Collections.Generic;

namespace OGANI.ProductService.Infrastructure.Entities;

public partial class ProductReview
{
    public int ReviewId { get; set; }

    public string ReviewText { get; set; } = null!;

    public int Rating { get; set; }

    public DateTime? ReviewDate { get; set; }

    public int ProductId { get; set; }

    public int UserId { get; set; }

    public virtual Product Product { get; set; } = null!;

    public virtual UserProfile User { get; set; } = null!;
}
