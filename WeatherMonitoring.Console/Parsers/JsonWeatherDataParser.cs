namespace WeatherMonitoring.Console.Parsers;
using System.Text.Json;
using WeatherMonitoring.Console.Models;

public class JsonWeatherDataParser : IWeatherDataParser
{
    public WeatherData Parse(string data)
    {
        return JsonSerializer.Deserialize<WeatherData>(data)!;
    }
}