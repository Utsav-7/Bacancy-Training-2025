using System.Text.Json;
using Day_3_Task_1.Model;
using Weather.NET;

namespace Day_3_Task_1
{
    // interface for write data into file
    public interface IWriteData
    {
        void SaveToFile(string city);
    }

    // class for write data into file
    public class SaveClass : IWriteData
    {
        public void SaveToFile(string city)
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
                System.IO.File.WriteAllTextAsync(filePath, jsonString);
            }
            catch (Exception)
            {
                throw new("Somethings wents wrong....");
            }
        }
    }

    // interface for read data from file
    public interface IReadData
    {
        public WeatherData ReadDataFile();
    }

    // class for read data from file
    public class ReadClass : IReadData
    {
        public WeatherData ReadDataFile() 
        {
            string filepath = Path.Combine(Directory.GetCurrentDirectory(), "WeatherData.txt");

            string jsonData = System.IO.File.ReadAllText(filepath);

            WeatherData weatherData = JsonSerializer.Deserialize<WeatherData>(jsonData);

            return weatherData;
        }
    }

}
