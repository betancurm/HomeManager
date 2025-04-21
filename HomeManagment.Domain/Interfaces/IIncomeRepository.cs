using HomeManagment.Domain.Entities;
namespace HomeManagment.Domain.Interfaces;
public interface IIncomeRepository
{
    Task<Income> GetByIdAsync(Guid id);
    Task<IEnumerable<Income>> GetAllAsync();
    Task AddAsync(Income income);
    void Update(Income income);
    void Delete(Income income);

    //Task<IEnumerable<Income>> GetByUserIdAsync(Guid userId);
    //Task<IEnumerable<Income>> GetByCategoryIdAsync(Guid categoryId);
}
