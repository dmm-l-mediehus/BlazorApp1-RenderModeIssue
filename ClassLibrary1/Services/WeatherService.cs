using ClassLibrary1.Interfaces;
using ClassLibrary1.Models;
using Microsoft.Extensions.Caching.Memory;

namespace ClassLibrary1.Services;

public sealed class WeatherService : IWeatherService
{
	private readonly IMemoryCache memoryCache;

	public WeatherService(IMemoryCache memoryCache)
	{
		this.memoryCache = memoryCache;
	}

	// Caches the next call (Prerendering double call oninitializedasync fix)
	private int loadCount;

	public string RenderMode => "Server";

	public async Task<IEnumerable<WeatherForecast>> GetForecastsAsync()
	{
		return await memoryCache.GetOrCreateAsync(loadCount - 1, async e =>
		{
			await Task.Delay(1000);

			loadCount++;

			e.SetOptions(new MemoryCacheEntryOptions
			{
				AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(30)
			});

			DateOnly startDate = DateOnly.FromDateTime(DateTime.Now);
			string[] summaries = new[] { "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching" };

			return Enumerable.Range(1, 5).Select(index => new WeatherForecast
			{
				Date = startDate.AddDays(index),
				TemperatureC = Random.Shared.Next(-20, 55),
				Summary = summaries[Random.Shared.Next(summaries.Length)]
			}).ToArray();
		}) ?? Enumerable.Empty<WeatherForecast>();
	}
}