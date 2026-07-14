using WeatherMonitoring.Console.Bots;
using WeatherMonitoring.Console.Models;
using Xunit;

namespace WeatherMonitoring.Tests.Bots;

public class SunBotTests
{
    private readonly SunBot _sunBot;

    public SunBotTests()
    {
        var config = new BotConfiguration
        {
            Enabled = true,
            Threshold = 30,
            Message = "It is sunny today!"
        };

        _sunBot = new SunBot(config);
    }


    [Fact]
    public void ShouldActivate_ReturnsTrue_WhenTemperatureIsGreaterThanThreshold()
    {
        
        var weatherData = new WeatherData
        {
            Temperature = 35
        };

        
        var result = _sunBot.ShouldActivate(weatherData);

        
        Assert.True(result);
    }


    [Fact]
    public void ShouldActivate_ReturnsFalse_WhenTemperatureIsLessThanThreshold()
    {
        
        var weatherData = new WeatherData
        {
            Temperature = 20
        };

        
        var result = _sunBot.ShouldActivate(weatherData);

        
        Assert.False(result);
    }
}