using Application.Features.Category.Commands.CreateCategory;
using Application.Features.Category.Commands.DeleteCategory;
using Application.Features.Category.Commands.UpdateCategory;
using Application.Features.Category.Queries.GetAllCategories;
using Application.Features.Category.Queries.GetCategoriesById;
using Application.Models.Category;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Authorize]
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
        public async Task<IActionResult> GetAllBlogPosts() 
        {
            var categories = await mediator.Send(new GetAllCategoriesQuery());
            return Ok(categories);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetBlogPosts([FromRoute] Guid id)
        {

            var command = new GetCategoriesByIdQuery()
            {
                Id = id
            };

            var getCategories = await mediator.Send(command);
            if (getCategories is null)
            {
                return NotFound();
            }

            return Ok(getCategories);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategoriey([FromBody] CreateCategoryRequestDto request)
        {

            var command = new CreateCategoryCommand()
            {
                Reqeust = request
            };

            var createCategories = await mediator.Send(command);

            return Ok(createCategories);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateCategoriey([FromRoute] Guid id, [FromBody] UpdateCategoryRequestDto request)
        {

            var command = new UpdateCategoryCommand()
            {
                Reqeust = request,
                Id = id
            };

            var updateCategories = await mediator.Send(command);
            if (updateCategories is null)
            {
                return NotFound();
            }

            return Ok(updateCategories);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteCategoriey([FromRoute] Guid id)
        {

            var command = new DeteteCategoryCommand()
            {
                Id = id,
            };

            var delCategories = await mediator.Send(command);
            if (delCategories is null)
            {
                return NotFound();
            }

            return Ok(delCategories);
        }
    }
}
