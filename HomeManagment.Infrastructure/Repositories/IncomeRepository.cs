using HomeManagment.Domain.Entities;
using HomeManagment.Domain.Interfaces;
using HomeManagment.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace HomeManagment.Infrastructure.Repositories;
public class IncomeRepository : IIncomeRepository
{
    private readonly HomeManagmentDbContext _context;
    public IncomeRepository(HomeManagmentDbContext context)
    {
        _context = context;
    }
    public async Task<IEnumerable<Income>> GetAllAsync()
    {
        return await _context.Incomes.ToListAsync();
    }
    public async Task<Income?> GetByIdAsync(Guid id) =>
        await _context.Incomes
            .Include(i => i.Category)
            .FirstOrDefaultAsync(i => i.Id == id);

    public async Task AddAsync(Income income)
    {
        await _context.Incomes.AddAsync(income);
        await _context.SaveChangesAsync();
    }


    public void Update(Income income) => _context.Incomes.Update(income);
    public void Delete(Income income) => _context.Incomes.Remove(income);

}
