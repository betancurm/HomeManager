using HomeManagment.Application.DTOs.Incomes;

namespace HomeManagment.Application.Interfaces;

public interface IIncomeService
{
    IEnumerable<GetIncomeDto> GetIncomesAsync();
    Task<Guid> CreateIncome (CreateIncomeDto incomeDto);
}
