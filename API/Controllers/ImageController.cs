using Application.Features.Category.Queries.GetAllCategories;
using Application.Features.Image.Commands.UploadImage;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        private readonly IMediator mediator;

        public ImageController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> UploadImage(
              [FromForm] IFormFile file
            , [FromForm] string fileName
            , [FromForm] string title)
        {

            await mediator.Send(new UploadImageCommand
            {
                FileName = fileName,
                File = file,
                Tittle = title
            });
            return Ok();
        }
    }
}
