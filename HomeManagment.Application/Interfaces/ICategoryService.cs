using HomeManagment.Application.DTOs.Categories;
namespace HomeManagment.Application.Interfaces;

public interface ICategoryService
{
    Task<Guid> RegisterCategory(CategoryDto categoryDto);
}
