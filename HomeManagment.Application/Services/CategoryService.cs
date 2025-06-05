using HomeManagment.Application.DTOs.Categories;
using HomeManagment.Application.Interfaces;
using HomeManagment.Domain.Interfaces;

namespace HomeManagment.Application.Services;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;

    public CategoryService(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public IEnumerable<CategoryDto> GetCategoriesAsync()
    {
        var categories = _categoryRepository.GetAllAsync().Result;
        return categories.Select(c => new CategoryDto
        {
            Id =c.Id,
            Name = c.Name, 
            Description = c.Description});
    }
}
