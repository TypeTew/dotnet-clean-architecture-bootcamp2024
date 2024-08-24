using Application.Features.Category.Queries.GetAllCategories;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase 
    {
        private readonly IMediator mediator;

        public CategoryController(IMediator mediator) 
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBlogPost() 
        {
            var categories = await mediator.Send(new GetAllCategoriesQuery());
            return Ok(categories);
        }
    }
}
