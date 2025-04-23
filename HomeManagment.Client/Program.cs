using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using HomeManagment.Client;
using HomeManagment.Client.Providers;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using HomeManagment.Client.Services;
using MudBlazor.Services;
using Microsoft.Extensions.Options;
using MudBlazor;


var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services.AddMudServices(options => { options.SnackbarConfiguration.PositionClass = Defaults.Classes.Position.TopRight; }
);
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

// 2. LocalStorage y auth
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<AuthenticationStateProvider, ApiAuthenticationStateProvider>();

builder.Services.AddScoped<AuthService>();
builder.Services.AddScoped<IncomeService>();
builder.Services.AddScoped<CategoryService>();

await builder.Build().RunAsync();

