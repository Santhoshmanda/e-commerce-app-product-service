using System;
namespace OGANI.ProductService.Infrastructure.Entities
{
	public class UserProfile
	{
       
            public int UserId { get; set; }

            public string DisplayName { get; set; } = null!;

            public string FirstName { get; set; } = null!;

            public string LastName { get; set; } = null!;

            public string EmailId { get; set; } = null!;

            public string AdObjId { get; set; } = null!;

            public virtual ICollection<ProductReview> ProductReviews { get; set; } = new List<ProductReview>();

    }
}

