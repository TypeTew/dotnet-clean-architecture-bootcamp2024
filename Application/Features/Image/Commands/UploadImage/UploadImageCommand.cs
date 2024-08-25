using Application.Models.BlogImage;
using MediatR;
using Microsoft.AspNetCore.Http;


namespace Application.Features.Image.Commands.UploadImage
{
    public class UploadImageCommand : IRequest<BlogImageDto>
    {
        public IFormFile File;
        public string FileName { get; set; }
        public string Tittle { get; set; }
    }
}
