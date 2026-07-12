namespace WeatherMonitoring.Console.Parsers;
using WeatherMonitoring.Console.Models;

public interface IWeatherDataParser
{
    WeatherData Parse(string data);
}