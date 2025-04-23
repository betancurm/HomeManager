using HomeManagment.Client.Models.Income;

namespace HomeManagment.Client.Interfaces;

public interface IIncomeService
{
    Task<List<GetIncomeRequest>> GetAllIncomes();
    Task CreateIncome(CreateIncomeRequest createIncomeRequest);
}
