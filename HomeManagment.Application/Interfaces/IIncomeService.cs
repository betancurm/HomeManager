using HomeManagment.Application.DTOs.Incomes;

namespace HomeManagment.Application.Interfaces;

public interface IIncomeService
{
    IEnumerable<GetIncomeDto> GetIncomesAsync();
    Task<Guid> CreateIncome(CreateIncomeDto incomeDto);
    Task UpdateIncome(Guid id, UpdateIncomeDto incomeDto);
    Task DeleteIncome(Guid id);
}
