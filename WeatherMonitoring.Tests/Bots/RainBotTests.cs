using System.Diagnostics;
using WeatherMonitoring.Console.Bots;
using WeatherMonitoring.Console.Models;
using Xunit;

namespace WeatherMonitoring.Tests.Bots;
public class RainBotTests
{
    private readonly RainBot _rainBot;

    public RainBotTests()
    {
        var config = new BotConfiguration
        {
            Enabled = true,
            Threshold = 70,
            Message = "Rain!"
        };

        _rainBot = new RainBot(config);
    }

    [Fact]
    public void ShouldActivate_ReturnsTrue_WhenHumidityIsGreaterThanThreshold()
    {
        var weatherData = new WeatherData
        {
            Humidity = 80
        };
        var result = _rainBot.ShouldActivate(weatherData);
        Assert.True (result);
    }
    [Fact]
    public void ShouldActivate_ReturnsFalse_WhenHumidityIsLessThanThreshold()
    {
        var weatherData = new WeatherData
        {
            Humidity = 50
        };

        var result = _rainBot.ShouldActivate(weatherData);

        Assert.False(result);
    }
}