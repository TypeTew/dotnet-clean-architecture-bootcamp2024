using Domain.Entities;


namespace Application.Contracts.Persistence
{
    public interface IBlogPostRepository
    {
        Task<BlogPost> CreateAsync(BlogPost blogPost);
    }
}
