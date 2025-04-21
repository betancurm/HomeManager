using HomeManagment.Domain.Interfaces;
using HomeManagment.Domain.Entities;
using HomeManagment.Application.DTOs.Expenses;
namespace HomeManagment.Application.Services;

public class ExpenseService
{
    private readonly IExpenseRepository _expenseRepository;
    private readonly ICategoryRepository _categoryRepository;
    public ExpenseService(IExpenseRepository expenseRepository, ICategoryRepository categoryRepository)
    {
        _expenseRepository = expenseRepository;
        _categoryRepository = categoryRepository;
    }
    public async Task<Guid> RegisterExpense(ExpenseDto dto)
    {
        var category = await _categoryRepository.GetByIdAsync(dto.CategoryId) ?? throw new Exception("Category not found");
        var expense = new Expense(dto.Amount,
                                  dto.Date,
                                  dto.Description,
                                  dto.UserId,
                                  category);
        await _expenseRepository.AddAsync(expense);

        return expense.Id;
    }
}
