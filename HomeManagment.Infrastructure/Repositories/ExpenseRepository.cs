using HomeManagment.Domain.Entities;
using HomeManagment.Domain.Interfaces;
using HomeManagment.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace HomeManagment.Infrastructure.Repositories;
public class ExpenseRepository : IExpenseRepository
{
    private readonly HomeManagmentDbContext _context;
    public ExpenseRepository(HomeManagmentDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Expense>> GetAllAsync()
    {
        return await _context.Expenses.Include(e => e.Category).ToListAsync();
    }

    public async Task<Expense?> GetByIdAsync(Guid id) =>
        await _context.Expenses
            .Include(e => e.Category)
            .FirstOrDefaultAsync(e => e.Id == id);

    public async Task AddAsync(Expense expense)
    {
        await _context.Expenses.AddAsync(expense);
        await _context.SaveChangesAsync();
    }

    public async Task Update(Expense expense)
    {
        _context.Expenses.Update(expense);
        await _context.SaveChangesAsync();
    }

    public async Task Delete(Expense expense)
    {
        _context.Expenses.Remove(expense);
        await _context.SaveChangesAsync();
    }
} 