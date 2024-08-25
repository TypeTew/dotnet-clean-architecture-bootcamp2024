using Application.Models.BlogPosts;
using MediatR;


namespace Application.Features.BlogPosts.Queries.GetAllBlogPosts
{
    public class GetAllBlogPostsQuery : IRequest<List<BlogPostDto>>
    {

    }
}
