using Domain.Entities;

namespace Application.Contracts.Persistence {
    public interface ICategoryRepository 
    {
        
        Task<Category> GetByIdAsync(Guid id);
        Task<List<Category>> GetAllCategories();
        Task<Category> CreateAsync(Category category);

    }
}
