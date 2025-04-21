using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using HomeManagment.Infrastructure.Identity;
using HomeManagment.Domain.Entities;

namespace HomeManagment.Infrastructure.Data;


public class HomeManagmentDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, Guid>
{
    public HomeManagmentDbContext(DbContextOptions<HomeManagmentDbContext> options)
        : base(options)
    {
    }
    public DbSet<Income> Incomes => Set<Income>();
    public DbSet<Expense> Expenses => Set<Expense>();
    public DbSet<Category> Categories => Set<Category>();
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
    }
}
