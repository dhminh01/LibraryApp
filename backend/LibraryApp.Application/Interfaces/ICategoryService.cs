using LibraryApp.Application.DTOs.Category;

namespace LibraryApp.Application.Interfaces
{
    public interface ICategoryService
    {
        Task<List<CategoryDto>> GetAllAsync();
        Task<CategoryDto> GetByIdAsync(Guid id);
        Task<CategoryDto> CreateAsync(CreateCategoryDto categoryDto);
        Task<CategoryDto?> UpdateAsync(UpdateCategoryDto categoryDto);
        Task<bool> DeleteAsync(Guid id);
    }
}

