using HomeManagment.Infrastructure.Identity;
using HomeManagment.Infrastructure.DependencyInjection;
using HomeManagment.Application.DependencyInjection;
using HomeManagment.Domain.Entities;
using HomeManagment.Infrastructure.Data;


var builder = WebApplication.CreateBuilder(args);

// 1. Servicios de aplicaci�n (si hiciste un paquete de extensi�n)
builder.Services.AddApplication();            // opcional

// 2. Servicios de infraestructura (DbContext, Identity, repos, etc.)
builder.Services.AddInfrastructure(builder.Configuration);

builder.Services.AddControllers();            // para API
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Sembrar roles/usuario inicial
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<HomeManagmentDbContext>();

    // Solo agrega si est� vac�a
    if (!context.Categories.Any())
    {
        context.Categories.Add(new Category("Salario", "Ingresos por salario mensual"));
        context.Categories.Add(new Category("Ventas", "Ingresos por ventas"));

        await context.SaveChangesAsync();
    }

    await IdentityDataSeeder.SeedAsync(scope.ServiceProvider); // si ya tienes esto
}


// Pipeline HTTP
app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();                         // API
app.Run();
