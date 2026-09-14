using WeatherMonitoring.Console.Bots;
using WeatherMonitoring.Console.Models;

namespace WeatherMonitoring.Tests.Bots;

[Collection("Bot tests")]
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
        Assert.True(result);
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

    [Fact]
    public void Update_PrintsMessage_WhenHumidityIsGreaterThanThreshold()
    {
        var weatherData = new WeatherData
        {
            Humidity = 80
        };
        var originalOut = System.Console.Out;
        using var writer = new StringWriter();
        System.Console.SetOut(writer);
        _rainBot.Update(weatherData);
        System.Console.SetOut(originalOut);
        Assert.Equal("Rain!\r\n", writer.ToString());
    }

    [Fact]
    public void Update_DoesNotPrintMessage_WhenHumidityIsLowerThanThreshold()
    {
        var weatherData = new WeatherData
        {
            Humidity = 50
        };
        var originalOut = System.Console.Out;
        using var writer = new StringWriter();
        System.Console.SetOut(writer);
        _rainBot.Update(weatherData);
        System.Console.SetOut(originalOut);
        Assert.Empty(writer.ToString());
    }
}