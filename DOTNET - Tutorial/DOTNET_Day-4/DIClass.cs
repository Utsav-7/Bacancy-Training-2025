using System.Text.Json;
using DOTNET_Day_4.Interface;
using DOTNET_Day_4.Models;
using Weather.NET;

namespace DOTNET_Day_4
{
    public class ReadDataService : IReadData
    {
        public WeatherData ReadData()
        {
            try
            {
                string filepath = Path.Combine(Directory.GetCurrentDirectory(), "WeatherData.txt");

                string jsonData = System.IO.File.ReadAllText(filepath);

                WeatherData weatherData = JsonSerializer.Deserialize<WeatherData>(jsonData);

                return weatherData;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }

    public class WriteDataService : IWriteData
    {
        public string WriteData(string city)
        {
            try
            {
                string API_KEY = "74990608688c51e27475591536971ec4";
                WeatherClient weatherClient = new WeatherClient(API_KEY);
                var weatherModel = weatherClient.GetCurrentWeather(city);

                // Serialize the object to JSON
                string jsonString = JsonSerializer.Serialize(weatherModel.Main);

                // Define the file path
                string filePath = Path.Combine(Directory.GetCurrentDirectory(), "WeatherData.txt");

                // Write to file asynchronously
                System.IO.File.AppendAllTextAsync(filePath, jsonString + Environment.NewLine);

                return jsonString;
            }
            catch (Exception)
            {
                throw new("Somethings wents wrong....");
            }
        }    
    }
}
