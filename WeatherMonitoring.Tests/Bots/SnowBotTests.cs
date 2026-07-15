using WeatherMonitoring.Console.Bots;
using WeatherMonitoring.Console.Models;

namespace WeatherMonitoring.Tests.Bots;

[Collection("Bot tests")]
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

    [Fact]
    public void Update_PrintsMessage_WhenTemperatureIsLowerThanThreshold()
    {
        var weatherData = new WeatherData
        {
            Temperature = 0
        };
        var originalOut = System.Console.Out;
        using var writer = new StringWriter();
        System.Console.SetOut(writer);
        _snowBot.Update(weatherData);
        System.Console.SetOut(originalOut);
        Assert.Equal("It is snowing!\r\n", writer.ToString());
    }

    [Fact]
    public void Update_DoesNotPrintMessage_WhenTemperatureIsHigherThanThreshold()
    {
        var weatherData = new WeatherData
        {
            Temperature = 10
        };
        var originalOut = System.Console.Out;
        using var writer = new StringWriter();
        System.Console.SetOut(writer);
        _snowBot.Update(weatherData);
        System.Console.SetOut(originalOut);
        Assert.Empty(writer.ToString());
    }
}