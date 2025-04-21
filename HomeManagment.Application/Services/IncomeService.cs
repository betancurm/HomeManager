using HomeManagment.Application.Interfaces;
using HomeManagment.Domain.Interfaces;
using HomeManagment.Domain.Entities;
using HomeManagment.Application.DTOs.Incomes;

namespace HomeManagment.Application.Services;

public class IncomeService : IIncomeService
{
    private readonly IIncomeRepository _incomeRepository;
    private readonly ICategoryRepository _categoryRepository;
    public IncomeService(IIncomeRepository incomeRepository, ICategoryRepository categoryRepository)
    {
        _incomeRepository = incomeRepository;
        _categoryRepository = categoryRepository;
    }
    public IEnumerable<GetIncomeDto> GetIncomesAsync()
    {
        var incomes = _incomeRepository.GetAllAsync().Result;
        return incomes.Select(i => new GetIncomeDto
        {
            Id = i.Id,
            Amount = i.Amount,
            Date = i.Date,
            Description = i.Description,
            UserId = i.UserId,
            CategoryId = i.CategoryId,
            CategoryName = i.Category.Name
        });
    }
    public async Task<Guid> CreateIncome (CreateIncomeDto dto)
    {
        var category = await _categoryRepository.GetByIdAsync(dto.CategoryId) ?? throw new Exception("Category not found");

        var income = new Income(dto.Amount,
                                 dto.Date,
                                 dto.Description,
                                 dto.UserId,
                                 category);
        await _incomeRepository.AddAsync(income);
        
        return income.Id;
    }


}
