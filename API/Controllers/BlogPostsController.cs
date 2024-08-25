using Application.Features.BlogPosts.Commands.CreateBlogPost;
using Application.Models.BlogPosts;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogPostsController : ControllerBase
    {
        private readonly IMediator mediator;

        public BlogPostsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreatePosts([FromBody] CreateBlogPostRequestDto request)
        {
            var command = new CreateBlogPostCommand
            {
                Reqeust = request
            };
            var result = await mediator.Send(command);
            return Ok(result);
        }

    }
}
