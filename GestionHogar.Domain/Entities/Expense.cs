using HomeManagment.Domain.Exceptions;

namespace HomeManagment.Domain.Entities;
public class Expense
{
    public Guid Id { get; private set; }
    public decimal Amount { get; private set; }
    public DateTime Date { get; private set; }
    public string Description { get; private set; }
    public Guid UserId { get; private set; }
    public Guid CategoryId { get; private set; }
    public Category Category { get; private set; }


    public Expense(decimal amount, DateTime date, string description, Guid userId, Category category)
    {
        if (amount <= 0)
        {
            throw new MontoInvalidoException(amount);
        }
        if (Category == null)
        {
            throw new ArgumentNullException(nameof(Category), "La categoría no puede ser nula.");
        }
        Id = Guid.NewGuid();
        Amount = amount;
        Date = date;
        Description = description;
        UserId = userId;
        CategoryId = category.Id;
        Category = Category;
    }
}
