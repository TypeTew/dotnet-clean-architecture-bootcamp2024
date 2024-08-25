using Domain.Entities;


namespace Application.Contracts.Persistence
{
    public interface IBlogImageRepository
    {
        Task<BlogImage> SaveImage(BlogImage blogImage);

    }
}
