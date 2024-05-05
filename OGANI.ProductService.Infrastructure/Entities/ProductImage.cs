using System;
using System.Collections.Generic;

namespace OGANI.ProductService.Infrastructure.Entities;

public partial class ProductImage
{
    public int ImageId { get; set; }

    public string ImageUrl { get; set; } = null!;

    public int ProductId { get; set; }

    public virtual Product Product { get; set; } = null!;
}
