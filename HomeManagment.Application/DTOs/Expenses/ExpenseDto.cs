namespace HomeManagment.Application.DTOs.Expenses;

public class ExpenseDto
{
    public decimal Amount { get; set; }
    public DateTime Date { get; set; }
    public string Description { get; set; } = string.Empty;
    public Guid UserId { get; set; }
    public Guid CategoryId { get; set; }
}
