using DOTNET_Day_4.Interface;
using DOTNET_Day_4.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DOTNET_Day_4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherController : ControllerBase
    {
        private readonly IReadData _readData;
        private readonly IWriteData _writeData;

        public WeatherController(IReadData readData, IWriteData writeData)
        {
            _readData = readData;
            _writeData = writeData;
        }

        [HttpGet("/GetWeather")]
        public IActionResult Get()
        {
            try
            {
                WeatherData weatherData = _readData.ReadData();
                return Ok(weatherData);
            }
            catch (Exception ex)
            {
                throw new Exception("Sorry, Data not reading....");
            }
        }

        [HttpPost("/PostWeather")]
        public IActionResult Post([FromQuery] string city)
        {
            try
            {
                string data = _writeData.WriteData(city);
                return Ok("Data fetch successfully.\n" + data);
            }
            catch (Exception ex)
            {
                throw new Exception("ERROR! Data not fetching....");
            }
        }
    }
}
