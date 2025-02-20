using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Day_3_Task_1;
using System.IO;
using System.Text.Json;
using Weather.NET;
using Day_3_Task_1.Model;

namespace Day_3_Task_1.Controllers
{
    [Route("/api/weather/[controller]")]
    [ApiController]
    public class WeatherController : Controller
    {
        private readonly IWriteData _writeClass;
        private readonly IReadData _readClass;

        // Dependency injection
        public WeatherController(IWriteData writeData, IReadData readData)
        {
            _writeClass = writeData;
            _readClass = readData;
        }

        // Read the data from the file
        [HttpGet("/v1/ReadFile")]
        public async Task<IActionResult> ReadDataFile()
        {
            try
            {
                WeatherData weatherData = _readClass.ReadDataFile();
                return Ok(weatherData);
            }
            catch (Exception ex)
            {
                throw new Exception("Somethings went wrong....");
            }
        }

        // Save the data to the file
        [HttpPost("/v2/PostWeather/")]
        public IActionResult PostWeather([FromQuery]string city)
        {
            try
            {
                _writeClass.SaveToFile(city);
                return Ok("SUCCESS!!!! Data added  .");
            }
            catch(Exception ex)
            {
                throw new Exception("Somethings went wrong....");
            }
        }
    }
}
