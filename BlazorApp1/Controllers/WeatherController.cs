using ClassLibrary1.Interfaces;
using ClassLibrary1.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlazorApp1.Controllers;

[Route("api/weather")]
[ApiController]
public sealed class WeatherController : ControllerBase
{
	private readonly IWeatherService weatherService;

	public WeatherController(IWeatherService weatherService)
	{
		this.weatherService = weatherService;
	}

	[HttpGet("GetWeatherForecasts")]
	public async Task<ActionResult<IEnumerable<WeatherForecast>>> GetWeatherForecastsAsync()
	{
		return Ok(await weatherService.GetForecastsAsync());
	}
}