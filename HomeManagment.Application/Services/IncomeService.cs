using HomeManagment.Application.Interfaces;
using HomeManagment.Domain.Interfaces;
using HomeManagment.Domain.Entities;
using HomeManagment.Application.DTOs.Incomes;

namespace HomeManagment.Application.Services;

public class IncomeService : IIncomeService
{
    private readonly IIncomeRepository _incomeRepository;
    private readonly ICategoryRepository _categoryRepository;
    private readonly ICurrentUserService _currentUserService;
    public IncomeService(IIncomeRepository incomeRepository, ICategoryRepository categoryRepository, ICurrentUserService currentUserService)
    {
        _incomeRepository = incomeRepository;
        _categoryRepository = categoryRepository;
        _currentUserService = currentUserService;
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
            CategoryId = i.CategoryId,
            CategoryName = i.Category.Name
        });
    }
    public async Task<Guid> CreateIncome(CreateIncomeDto dto)
    {
        var category = await _categoryRepository.GetByIdAsync(dto.CategoryId) ?? throw new Exception("Category not found");
        var applicationUserId = _currentUserService.ApplicationUserId;
        var income = new Income(dto.Amount,
                                 dto.Date,
                                 dto.Description,
                                 applicationUserId,
                                 category);
        await _incomeRepository.AddAsync(income);
        
        return income.Id;
    }

    public async Task UpdateIncome(Guid id, UpdateIncomeDto dto)
    {
        var income = await _incomeRepository.GetByIdAsync(id) ?? throw new Exception("Income not found");
        var category = await _categoryRepository.GetByIdAsync(dto.CategoryId) ?? throw new Exception("Category not found");
        
        if (income.ApplicationUserId != _currentUserService.ApplicationUserId)
        {
            throw new UnauthorizedAccessException("No tienes permiso para actualizar este ingreso");
        }

        income.Update(dto.Amount, dto.Date, dto.Description, category);
        await _incomeRepository.Update(income);
    }

    public async Task DeleteIncome(Guid id)
    {
        var income = await _incomeRepository.GetByIdAsync(id) ?? throw new Exception("Income not found");
        
        if (income.ApplicationUserId != _currentUserService.ApplicationUserId)
        {
            throw new UnauthorizedAccessException("No tienes permiso para eliminar este ingreso");
        }

        await _incomeRepository.Delete(income);
    }
}
