using Microsoft.AspNetCore.Http;


namespace Application.Models.BlogImage
{
    public class CreateBlogImageDto
    {
        public IFormFile File { get; set; }
        public string FileName { get; set; }
        public string Tittle { get; set; }
    }
}
