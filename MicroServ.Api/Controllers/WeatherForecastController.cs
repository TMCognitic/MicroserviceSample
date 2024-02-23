using Microsoft.AspNetCore.Mvc;
using System.Data.Common;

namespace MicroServ.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController(ILogger<WeatherForecastController> _logger, DbConnection _dbConnection) : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    [HttpGet(Name = "GetWeatherForecast")]
    public IActionResult Get()
    {
        try
        {
            _logger.LogInformation(_dbConnection.ConnectionString);
            _dbConnection.Open();
        }
        catch (Exception ex)
        {
            return BadRequest(new { Message = ex.Message });
        }

        return Ok(Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToArray());
    }
}
