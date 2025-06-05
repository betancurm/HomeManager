using HomeManagment.Application.DTOs.Categories;
namespace HomeManagment.Application.Interfaces;

public interface ICategoryService
{
    IEnumerable<CategoryDto> GetCategoriesAsync();
}
