using System.Net.Http.Json;
using ClassLibrary1.Interfaces;
using ClassLibrary1.Models;

namespace ClassLibrary1.Services;

public sealed class HttpClientWeatherService : IWeatherService
{
	private readonly HttpClient httpClient;

	public HttpClientWeatherService(HttpClient httpClient)
	{
		this.httpClient = httpClient;
	}

	public string RenderMode => "WASM";

	public async Task<IEnumerable<WeatherForecast>> GetForecastsAsync()
	{
		return await httpClient.GetFromJsonAsync<IEnumerable<WeatherForecast>>("weather/GetWeatherForecasts") ?? Enumerable.Empty<WeatherForecast>();
	}
}