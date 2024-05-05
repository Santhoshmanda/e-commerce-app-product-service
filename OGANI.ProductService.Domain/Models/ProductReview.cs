using System.ComponentModel.DataAnnotations;

namespace OGANI.ProductService.Domain.Models;

public partial class ProductReview
{
    public int ReviewId { get; set; }

    [Required(ErrorMessage = "ReviewText is required")]
    [MaxLength(100, ErrorMessage = "ReviewText cannot exceed 100 characters")]
    public string ReviewText { get; set; } = null!;

    [Required(ErrorMessage = "Rating is required")]
    public int Rating { get; set; }

    public DateTime? ReviewDate { get; set; }

    [Required(ErrorMessage = "ProductId is required")]
    public int ProductId { get; set; }

    [Required(ErrorMessage = "UserId is required")]
    public int UserId { get; set; }

    //public virtual Product Product { get; set; } = null!;

    //public virtual UserProfile User { get; set; } = null!;
}
