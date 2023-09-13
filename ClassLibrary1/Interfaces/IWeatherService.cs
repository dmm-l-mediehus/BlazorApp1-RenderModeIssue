using ClassLibrary1.Models;

namespace ClassLibrary1.Interfaces;

public interface IWeatherService
{
	string RenderMode { get; }

	Task<IEnumerable<WeatherForecast>> GetForecastsAsync();
}