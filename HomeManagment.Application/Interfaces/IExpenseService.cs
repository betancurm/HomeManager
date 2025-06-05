using HomeManagment.Application.DTOs.Expenses;
namespace HomeManagment.Application.Interfaces;

public interface IExpenseService
{
    IEnumerable<GetExpenseDto> GetExpensesAsync();
    Task<Guid> RegisterExpense(ExpenseDto expenseDto);
    Task UpdateExpense(Guid id, UpdateExpenseDto expenseDto);
    Task DeleteExpense(Guid id);
}
