using HomeManagment.Infrastructure.Identity;
using HomeManagment.Infrastructure.DependencyInjection;
using HomeManagment.Application.DependencyInjection;
using HomeManagment.Domain.Entities;
using HomeManagment.Infrastructure.Data;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using HomeManagment.Application.Interfaces;
using HomeManagment.Application.Services;

var builder = WebApplication.CreateBuilder(args);

// 1. Servicios de aplicación (si hiciste un paquete de extensión)
builder.Services.AddApplication();            // opcional

// 2. Servicios de infraestructura (DbContext, Identity, repos, etc.)
builder.Services.AddInfrastructure(builder.Configuration);
var jwt = builder.Configuration.GetSection("Jwt");
var key = Encoding.UTF8.GetBytes(jwt["Key"]);

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = jwt["Issuer"],
        ValidAudience = jwt["Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(key)
    };
});

builder.Services.AddAuthorization();
builder.Services.AddControllers();            // para API
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    // Define el esquema de seguridad "Bearer"
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Ingresa ‘Bearer {token}’"
    });

    // Aplica el esquema a todos los endpoints
    c.AddSecurityRequirement(new OpenApiSecurityRequirement {
    {
        new OpenApiSecurityScheme {
            Reference = new OpenApiReference {
                Type = ReferenceType.SecurityScheme,
                Id   = "Bearer"
            }
        },
        Array.Empty<string>()
    }});
});

builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<ICurrentUserService, CurrentUserService>();

var app = builder.Build();

// Sembrar roles/usuario inicial
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<HomeManagmentDbContext>();

    // Solo agrega si está vacía
    if (!context.Categories.Any())
    {
        context.Categories.Add(new Category("Salario", "Ingresos por salario mensual"));
        context.Categories.Add(new Category("Ventas", "Ingresos por ventas"));

        await context.SaveChangesAsync();
    }

    await IdentityDataSeeder.SeedAsync(scope.ServiceProvider); 
}


// Pipeline HTTP
app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();                         // API
app.Run();
