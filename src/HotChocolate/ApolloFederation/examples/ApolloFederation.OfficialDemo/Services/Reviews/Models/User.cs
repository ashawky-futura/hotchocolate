using System.Collections.Generic;
using HotChocolate;
using HotChocolate.ApolloFederation;
using Reviews.Data;

namespace Reviews.Models;

[ForeignServiceTypeExtension]
public class User
{
    [Key]
    [External]
    public string Id { get; set; } = default!;
    [External]
    public string Username { get; set; } = default!;

    public IEnumerable<Review> GetReviews([Service] ReviewRepository reviewRepository)
    {
        return reviewRepository.GetByUserId(Id);
    }
}
