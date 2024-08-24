using Application.Contracts.Persistence;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.DatabaseContext;



namespace Persistence.Repositories {
    public class CategoryRepository : ICategoryRepository
    {
        protected readonly ApplicationDbContext dbContext;

        public CategoryRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Category> CreateAsync(Category category)
        {
            dbContext.Categories.Add(category);
            await dbContext.SaveChangesAsync();
            return category;
        }

        public async Task<List<Category>> GetAllCategories()
        {
            return await dbContext.Categories.AsNoTracking().ToListAsync();
        }

        public async Task<Category> GetByIdAsync(Guid id) {
            return await dbContext.Categories.FirstOrDefaultAsync(f => f.Id == id);
        }
    }
}
