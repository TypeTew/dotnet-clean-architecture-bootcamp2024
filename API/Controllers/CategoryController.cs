using Application.Features.Category.Commands.CreateCategory;
using Application.Features.Category.Queries.GetAllCategories;
using Application.Models;
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

        [HttpPost]
        public async Task<IActionResult> CreateCategoriey([FromBody] CreateCategoryRequesrDto request)
        {

            var command = new CreateCategoryCommand()
            {
                Reqeust = request
            };

            var createCategories = await mediator.Send(command);

            return Ok(createCategories);
        }
    }
}
