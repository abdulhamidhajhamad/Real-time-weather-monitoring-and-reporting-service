using WeatherMonitoring.Console.Bots;
using WeatherMonitoring.Console.Models;
using WeatherMonitoring.Console.Services;

namespace WeatherMonitoring.Tests.TestDoubles;

public class SpyBot : IBot
{
    public int UpdateCallCount { get; private set; }

    public WeatherData? ReceivedWeatherData { get; private set; }

    public void Update(WeatherData weatherData)
    {
        UpdateCallCount++;
        ReceivedWeatherData = weatherData;
    }
}