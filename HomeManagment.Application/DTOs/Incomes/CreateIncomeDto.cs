namespace HomeManagment.Application.DTOs.Incomes;
public class CreateIncomeDto
{
    public decimal Amount { get; set; }
    public DateTime Date { get; set; }
    public string Description { get; set; } = string.Empty;
    public Guid CategoryId { get; set; }
}
