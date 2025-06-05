using HomeManagment.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace HomeManagment.Infrastructure.Identity;

public class ApplicationUser : IdentityUser<Guid> 
{
    public ICollection<Income> Incomes { get; set; } = new List<Income>();
    public ICollection<Expense> Expenses { get; set; } = new List<Expense>();
}
