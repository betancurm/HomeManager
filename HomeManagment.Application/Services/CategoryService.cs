using HomeManagment.Application.DTOs.Categories;
using HomeManagment.Application.Interfaces;
using HomeManagment.Domain.Entities;
using HomeManagment.Domain.Interfaces;

namespace HomeManagment.Application.Services;

public class CategoryService : ICategoryService
{
    private readonly ICategoryService _categoryService;
    private readonly ICategoryRepository _categoryRepository;

    public CategoryService(ICategoryService categoryService, ICategoryRepository categoryRepository)
    {
        _categoryService = categoryService;
        _categoryRepository = categoryRepository;
    }
    public async Task<Guid> RegisterCategory(CategoryDto categoryDto)
    {
        var category = new Category(categoryDto.Name, categoryDto.Description);
        await _categoryRepository.AddAsync(category);

        return category.Id;
    }
}
