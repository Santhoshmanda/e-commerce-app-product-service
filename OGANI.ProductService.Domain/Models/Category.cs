using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OGANI.ProductService.Domain.Models;

public partial class Category
{
    public int CategoryId { get; set; }

    [Required(ErrorMessage = "CategoryName is required")]
    [MaxLength(100, ErrorMessage = "CategoryName cannot exceed 100 characters")]
    public string CategoryName { get; set; } = null!;

    //public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
