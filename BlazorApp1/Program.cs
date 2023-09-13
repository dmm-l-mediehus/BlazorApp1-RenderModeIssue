using BlazorApp1.Components;
using ClassLibrary1.Interfaces;
using ClassLibrary1.Services;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddRazorComponents().AddServerComponents().AddWebAssemblyComponents();

builder.Services.AddMemoryCache();
builder.Services.AddSingleton<IWeatherService, WeatherService>();

WebApplication app = builder.Build();

if (app.Environment.IsDevelopment())
{
	app.UseWebAssemblyDebugging();
}
else
{
	app.UseExceptionHandler("/Error");
	app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.MapControllers();
app.MapRazorComponents<App>().AddAdditionalAssemblies(typeof(BlazorApp1.Client._Imports).Assembly).AddServerRenderMode().AddWebAssemblyRenderMode();

app.Run();