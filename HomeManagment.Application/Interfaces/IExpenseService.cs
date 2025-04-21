using HomeManagment.Application.DTOs.Expenses;
namespace HomeManagment.Application.Interfaces;

public interface IExpenseService
{
    Task<Guid> RegisterExpense(ExpenseDto expenseDto);
}
