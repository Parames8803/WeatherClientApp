using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MyWeatherApp;
using MudBlazor.Services;
using Blazored.LocalStorage;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.DependencyInjection;
using MyWeatherApp.Services;
using Microsoft.Extensions.Configuration;

var builder = WebAssemblyHostBuilder.CreateDefault(args);


builder.Services.AddMudServices();
builder.Services.AddScoped<WeatherService>();
builder.Services.AddScoped<LocationService>();
builder.Services.AddScoped<LoginService>();
builder.Services.AddScoped<FavoriteServices>();
builder.Services.AddBlazoredLocalStorageAsSingleton();


builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddSingleton<IConfiguration>(sp =>
{
    var httpClient = sp.GetRequiredService<HttpClient>();
    var config = new ConfigurationBuilder()
        .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)  
        .Build();
    return config;
});

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

await builder.Build().RunAsync();
