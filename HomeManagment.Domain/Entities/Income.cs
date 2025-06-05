using HomeManagment.Domain.Exceptions;

namespace HomeManagment.Domain.Entities;

public class Income
{
    public Guid Id { get; private set; }
    public decimal Amount { get; private set; }
    public DateTime Date { get; private set; }
    public string Description { get; private set; }
    public Guid ApplicationUserId { get; private set; }
    public Guid CategoryId { get; private set; }
    public Category Category { get; private set; }
    private Income() { }

    public Income(decimal amount, DateTime date, string description, Guid applicationUserId, Category? category)
    {
        if (amount <= 0)
        {
            throw new MontoInvalidoException(amount);
        }
        if (category == null)
        {
            throw new ArgumentNullException(nameof(category));
        }
        Id = Guid.NewGuid();
        Amount = amount;
        Date = date;
        Description = description;
        ApplicationUserId = applicationUserId;
        Category = category;
        CategoryId = category.Id;
    }

    public void Update(decimal amount, DateTime date, string description, Category category)
    {
        if (amount <= 0)
        {
            throw new MontoInvalidoException(amount);
        }
        if (category == null)
        {
            throw new ArgumentNullException(nameof(category));
        }

        Amount = amount;
        Date = date;
        Description = description;
        Category = category;
        CategoryId = category.Id;
    }
}
