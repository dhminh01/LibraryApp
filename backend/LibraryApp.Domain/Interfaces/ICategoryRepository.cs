using LibraryApp.Domain.Entities;

namespace LibraryApp.Domain.Interfaces
{
    public interface ICategoryRepository
    {
        Task<Category?> GetCategoryByIdAsync(Guid id);
        Task<IEnumerable<Category>> GetAllCategoriesAsync();
        Task AddCategoryAsync(Category category);
        Task UpdateCategoryAsync(Category category);
        Task DeleteCategoryAsync(Category category);
        Task<bool> CategoryExistsAsync(Guid id);
    }
}