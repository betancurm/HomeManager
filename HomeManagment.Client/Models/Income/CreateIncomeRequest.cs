namespace HomeManagment.Client.Models.Income;

public class CreateIncomeRequest
{
    public decimal Amount { get; set; }
    public DateTime Date { get; set; }
    public string Description { get; set; } = string.Empty;
    public Guid CategoryId { get; set; }
}