using HomeManagment.Domain.Interfaces;
using HomeManagment.Domain.Entities;
using HomeManagment.Application.DTOs.Expenses;
using HomeManagment.Application.Interfaces;
namespace HomeManagment.Application.Services;

public class ExpenseService : IExpenseService
{
    private readonly IExpenseRepository _expenseRepository;
    private readonly ICategoryRepository _categoryRepository;
    private readonly ICurrentUserService _currentUserService;
    public ExpenseService(IExpenseRepository expenseRepository, ICategoryRepository categoryRepository, ICurrentUserService currentUserService)
    {
        _expenseRepository = expenseRepository;
        _categoryRepository = categoryRepository;
        _currentUserService = currentUserService;
    }

    public IEnumerable<GetExpenseDto> GetExpensesAsync()
    {
        var expenses = _expenseRepository.GetAllAsync().Result;
        return expenses.Select(e => new GetExpenseDto
        {
            Id = e.Id,
            Amount = e.Amount,
            Date = e.Date,
            Description = e.Description,
            CategoryId = e.CategoryId,
            CategoryName = e.Category.Name
        });
    }

    public async Task<Guid> RegisterExpense(ExpenseDto dto)
    {
        var category = await _categoryRepository.GetByIdAsync(dto.CategoryId) ?? throw new Exception("Category not found");
        var applicationUserId = _currentUserService.ApplicationUserId;

        var expense = new Expense(dto.Amount,
                                  dto.Date,
                                  dto.Description,
                                  applicationUserId,
                                  category);
        await _expenseRepository.AddAsync(expense);

        return expense.Id;
    }

    public async Task UpdateExpense(Guid id, UpdateExpenseDto dto)
    {
        var expense = await _expenseRepository.GetByIdAsync(id) ?? throw new Exception("Expense not found");
        var category = await _categoryRepository.GetByIdAsync(dto.CategoryId) ?? throw new Exception("Category not found");
        
        if (expense.ApplicationUserId != _currentUserService.ApplicationUserId)
        {
            throw new UnauthorizedAccessException("No tienes permiso para actualizar este gasto");
        }

        expense.Update(dto.Amount, dto.Date, dto.Description, category);
        await _expenseRepository.Update(expense);
    }

    public async Task DeleteExpense(Guid id)
    {
        var expense = await _expenseRepository.GetByIdAsync(id) ?? throw new Exception("Expense not found");
        
        if (expense.ApplicationUserId != _currentUserService.ApplicationUserId)
        {
            throw new UnauthorizedAccessException("No tienes permiso para eliminar este gasto");
        }

        await _expenseRepository.Delete(expense);
    }
}
