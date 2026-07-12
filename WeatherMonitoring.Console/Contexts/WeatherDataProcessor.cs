namespace WeatherMonitoring.Console.Contexts;
using WeatherMonitoring.Console.Models;
using WeatherMonitoring.Console.Parsers;

public class WeatherDataProcessor
{
    private readonly IWeatherDataParser _parser;

    public WeatherDataProcessor(IWeatherDataParser parser)
    {
        _parser = parser;
    }

    public WeatherData Process(string data)
    {
        return _parser.Parse(data);
    }
}