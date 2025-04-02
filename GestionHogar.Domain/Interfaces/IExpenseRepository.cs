using HomeManagment.Domain.Entities;

namespace HomeManagment.Domain.Interfaces;
public interface IExpenseRepository
{
    Task<Expense> GetByIdAsync(Guid id);
    Task<IEnumerable<Expense>> GetAllAsync();
    Task AddAsync(Expense expense);
    void Update(Expense expense);
    void Delete(Expense expense);
}
