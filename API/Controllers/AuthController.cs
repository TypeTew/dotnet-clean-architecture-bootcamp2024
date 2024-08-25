using Application.Features.BlogPosts.Queries.GetAllBlogPosts;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator mediator;
        public AuthController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Register()
        {
            //var blogPosts = await mediator.Send(new GetAllBlogPostsQuery());
            return Ok();
        }
    }
}
