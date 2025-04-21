using HomeManagment.Domain.Entities;
using HomeManagment.Domain.Interfaces;
using HomeManagment.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace HomeManagment.Infrastructure.Repositories;

public class CategoryRepository : ICategoryRepository
{
    private readonly HomeManagmentDbContext _context;
    public CategoryRepository(HomeManagmentDbContext context)
    {
        _context = context;
    }
    public async Task<IEnumerable<Category>> GetAllAsync()
    {
        return await _context.Categories.ToListAsync();
    }
    public async Task<Category?> GetByIdAsync(Guid id) =>
        await _context.Categories
            .FirstOrDefaultAsync(c => c.Id == id);
    public async Task AddAsync(Category category) => await _context.Categories.AddAsync(category);
    public void Update(Category category) => _context.Categories.Update(category);
    public void Delete(Category category) => _context.Categories.Remove(category);


}
