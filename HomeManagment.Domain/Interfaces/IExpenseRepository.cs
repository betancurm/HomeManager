using HomeManagment.Domain.Entities;

namespace HomeManagment.Domain.Interfaces;
public interface IExpenseRepository
{
    Task<Expense> GetByIdAsync(Guid id);
    Task<IEnumerable<Expense>> GetAllAsync();
    Task AddAsync(Expense expense);
    Task Update(Expense expense);
    Task Delete(Expense expense);
}
