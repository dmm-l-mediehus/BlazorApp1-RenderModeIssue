using ClassLibrary1.Interfaces;
using ClassLibrary1.Services;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

WebAssemblyHostBuilder builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddScoped(sp => new HttpClient() { BaseAddress = new Uri("https://localhost:7164/api/") });
builder.Services.AddScoped<IWeatherService, HttpClientWeatherService>();

await builder.Build().RunAsync();