using WeatherMonitoring.Console.Bots;
using WeatherMonitoring.Console.Models;
using Xunit;

namespace WeatherMonitoring.Tests.Bots;

public class SnowBotTests
{
    private readonly SnowBot _snowBot;

    public SnowBotTests()
    {
        var config = new BotConfiguration
        {
            Enabled = true,
            Threshold = 5,
            Message = "It is snowing!"
        };

        _snowBot = new SnowBot(config);
    }


    [Fact]
    public void ShouldActivate_ReturnsTrue_WhenTemperatureIsLowerThanThreshold()
    {
        var weatherData = new WeatherData
        {
            Temperature = 0
        };

        var result = _snowBot.ShouldActivate(weatherData);

        
        Assert.True(result);
    }


    [Fact]
    public void ShouldActivate_ReturnsFalse_WhenTemperatureIsHigherThanThreshold()
    {
        var weatherData = new WeatherData
        {
            Temperature = 10
        };

        
        var result = _snowBot.ShouldActivate(weatherData);

        
        Assert.False(result);
    }
}