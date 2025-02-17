using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using WeatherApp.Services;
using WeatherApp;
using MudBlazor.Services;
using Blazored.LocalStorage;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// Register Services
builder.Services.AddScoped<SupabaseClient>();
builder.Services.AddMudServices();
builder.Services.AddScoped<IPreferenceService, LocalStoragePreferenceService>();
builder.Services.AddBlazoredLocalStorage();

// Configure HttpClient with base address from appsettings.json
var apiBaseAddress = builder.Configuration["BackendServices:AspNetBackend"];
if (string.IsNullOrEmpty(apiBaseAddress))
{
    throw new InvalidOperationException("BackendServices:AspNetBackend configuration is missing or empty.");
}
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(apiBaseAddress) });

await builder.Build().RunAsync();