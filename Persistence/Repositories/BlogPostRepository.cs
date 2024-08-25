using Application.Contracts.Persistence;
using Domain.Entities;
using Persistence.DatabaseContext;

namespace Persistence.Repositories
{
    public class BlogPostRepository : IBlogPostRepository
    {
        protected readonly ApplicationDbContext dbContext;

        public BlogPostRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<BlogPost> CreateAsync(BlogPost blogPost)
        {
            dbContext.BlogPosts.Add(blogPost);
            await dbContext.SaveChangesAsync();
            return blogPost;
        }
    }
}
