using AutoMapper;
using LibraryApp.Application.DTOs.Category;
using LibraryApp.Application.Interfaces;
using LibraryApp.Domain.Entities;
using LibraryApp.Domain.Interfaces;

namespace LibraryApp.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<List<CategoryDto>> GetAllAsync()
        {
            var categories = await _categoryRepository.GetAllCategoriesAsync();

            return _mapper.Map<List<CategoryDto>>(categories);
        }

        public async Task<CategoryDto> GetByIdAsync(Guid id)
        {
            var category = await _categoryRepository.GetCategoryByIdAsync(id);

            return _mapper.Map<CategoryDto>(category);
        }

        public async Task<CategoryDto> CreateAsync(CreateCategoryDto categoryDto)
        {
            var category = _mapper.Map<Category>(categoryDto);
            await _categoryRepository.AddCategoryAsync(category);

            return _mapper.Map<CategoryDto>(category);
        }

        public async Task<CategoryDto?> UpdateAsync(UpdateCategoryDto categoryDto)
        {
            var category = await _categoryRepository.GetCategoryByIdAsync(categoryDto.Id);
            if (category == null) return null;

            _mapper.Map(categoryDto, category);
            await _categoryRepository.UpdateCategoryAsync(category);

            return _mapper.Map<CategoryDto>(category);
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var category = await _categoryRepository.GetCategoryByIdAsync(id);
            if (category == null)
                return false;

            await _categoryRepository.DeleteCategoryAsync(category);

            return true;
        }


    }
}


