using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MyWeatherApp;
using MudBlazor.Services;
using Blazored.LocalStorage;
using MyWeatherApp.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddMudServices();
builder.Services.AddScoped<WeatherService>();
builder.Services.AddScoped<LocationService>();
builder.Services.AddScoped<LoginService>();
builder.Services.AddScoped<FavoriteServices>();
builder.Services.AddBlazoredLocalStorageAsSingleton();

builder.Services.AddSingleton(sp =>
{
    var config = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("wwwroot/appsettings.json", optional: false, reloadOnChange: true)
        .Build();
    return config;
});


builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

await builder.Build().RunAsync();
