using Application.Models.BlogPosts;
using MediatR;


namespace Application.Features.BlogPosts.Commands.CreateBlogPost
{
    public class CreateBlogPostCommand : IRequest<BlogPostDto>
    {
        public CreateBlogPostRequestDto Reqeust { get; set; }

    }
}
