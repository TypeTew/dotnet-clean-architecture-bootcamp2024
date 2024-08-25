using Application.Contracts.Persistence;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
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


        public async Task<List<BlogPost>> GetAllBlogPosts()
        {
            return await dbContext.BlogPosts.AsNoTracking().Include(i => i.Categories).ToListAsync();

        }

        public async Task<BlogPost> GetByIdAsync(Guid id)
        {
            return await dbContext.BlogPosts.Include(i => i.Categories).FirstOrDefaultAsync(f => f.Id == id);
        }

        public async Task<BlogPost> CreateAsync(BlogPost blogPost)
        {
            await dbContext.BlogPosts.AddAsync(blogPost);
            await dbContext.SaveChangesAsync();
            return blogPost;
        }


    }
}
