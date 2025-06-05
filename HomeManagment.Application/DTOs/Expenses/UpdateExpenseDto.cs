using System.ComponentModel.DataAnnotations;

namespace HomeManagment.Application.DTOs.Expenses;

public class UpdateExpenseDto
{
    [Required]
    [Range(0.01, double.MaxValue, ErrorMessage = "El monto debe ser mayor a 0")]
    public decimal Amount { get; set; }
    
    [Required]
    public DateTime Date { get; set; }
    
    [Required]
    public string Description { get; set; } = string.Empty;
    
    [Required]
    public Guid CategoryId { get; set; }
} 