using HomeManagment.Domain.Interfaces;
using HomeManagment.Infrastructure.Data;
using HomeManagment.Infrastructure.Identity;
using HomeManagment.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity;

namespace HomeManagment.Infrastructure.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services,
            IConfiguration cfg)
        {
            services.AddDbContext<HomeManagmentDbContext>(opts =>
                opts.UseSqlServer(cfg.GetConnectionString("DefaultConnection")));

            services.AddIdentity<ApplicationUser, ApplicationRole>()
                    .AddEntityFrameworkStores<HomeManagmentDbContext>()
                    .AddDefaultTokenProviders();

            // Repositorios
            services.AddScoped<IIncomeRepository, IncomeRepository>();
            services.AddScoped<IExpenseRepository, ExpenseRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();

            return services;
        }
    }
}
