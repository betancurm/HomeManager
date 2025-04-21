
using HomeManagment.Application.Interfaces;
using HomeManagment.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace HomeManagment.Application.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IIncomeService, IncomeService>();
        //services.AddScoped<IExpenseService, ExpenseService>();
        return services;
    }
}
