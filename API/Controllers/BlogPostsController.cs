using Application.Features.BlogPosts.Commands.CreateBlogPost;
using Application.Features.BlogPosts.Queries.GetAllBlogPosts;
using Application.Features.Category.Queries.GetAllCategories;
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


        [HttpGet]
        public async Task<IActionResult> GetAllBlogPosts()
        {
            var blogPosts = await mediator.Send(new GetAllBlogPostsQuery());
            return Ok(blogPosts);
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
