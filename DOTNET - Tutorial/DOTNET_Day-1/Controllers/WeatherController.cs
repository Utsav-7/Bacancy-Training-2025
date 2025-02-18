using Microsoft.AspNetCore.Mvc;
using Weather.NET;
using Weather.NET.Enums;
using System.Text.Json;

namespace DOTNET_Day_1.Controllers
{
    [Route("/api/weather/[controller]")]
    [ApiController]
    public class WeatherController : Controller
    {
        [HttpPost ("/v2/PostWeather/{city}")]
        public async Task<IActionResult> PostWeather(string city)
        {
            // Get current weather for the given city

            string API_KEY = "74990608688c51e27475591536971ec4";
            WeatherClient weatherClient = new WeatherClient(API_KEY);

            var weatherModel = weatherClient.GetCurrentWeather(city);

            // Serialize the object to JSON
            string jsonString = JsonSerializer.Serialize(weatherModel.Main);

            // Define the file path
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), "WeatherData.txt");

            // Write to file asynchronously
            await System.IO.File.AppendAllTextAsync(filePath, jsonString);

            if (weatherModel != null && weatherModel.Main != null)
            {
                return Ok(new { City = weatherModel.CityName,
                                TimeZone = weatherModel.Timezone,
                                Temperature = weatherModel.Main.Temperature,
                                Pressure = weatherModel.Main.AtmosphericPressure
                                });
            }

            return NotFound("Weather data not available for the specified city.");
        }
    }
}
