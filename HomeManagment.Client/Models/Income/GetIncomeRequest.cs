namespace HomeManagment.Client.Models.Income;

public class GetIncomeRequest
{
    public decimal Amount { get; set; }
    public DateTime Date { get; set; }
    public string Description { get; set; } = string.Empty;
   // public Guid CategoryId { get; set; }
    public string CategoryName { get; set; } = string.Empty;
}
