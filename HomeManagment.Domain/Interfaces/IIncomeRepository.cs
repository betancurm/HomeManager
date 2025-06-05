using HomeManagment.Domain.Entities;
namespace HomeManagment.Domain.Interfaces;
public interface IIncomeRepository
{
    Task<Income> GetByIdAsync(Guid id);
    Task<IEnumerable<Income>> GetAllAsync();
    Task AddAsync(Income income);
    Task Update(Income income);
    Task Delete(Income income);    
}
