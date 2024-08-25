using Application.Models.BlogPosts;
using MediatR;

namespace Application.Features.BlogPosts.Queries.GetCategoriesById
{
    public class GetBlogPostByIdQuery : IRequest<BlogPostDto>
    {
        public Guid Id { get; set; }
    }
}
