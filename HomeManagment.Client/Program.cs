using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using HomeManagment.Client;
using HomeManagment.Client.Providers;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using HomeManagment.Client.Services;
using MudBlazor.Services;
using MudBlazor;
using HomeManagment.Client.Interfaces;


var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services.AddMudServices(options => { options.SnackbarConfiguration.PositionClass = Defaults.Classes.Position.TopRight; }
);

var HomeManagmentApi = builder.Configuration.GetValue<string>("HomeManagment.Api");
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(HomeManagmentApi) });

// 2. LocalStorage y auth
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<AuthenticationStateProvider, ApiAuthenticationStateProvider>();

builder.Services.AddScoped<AuthService>();
builder.Services.AddScoped<IIncomeService, IncomeService>();
builder.Services.AddScoped<CategoryService>();

await builder.Build().RunAsync();

