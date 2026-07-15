using WeatherMonitoring.Console.Bots;
using WeatherMonitoring.Console.Models;

namespace WeatherMonitoring.Tests.Bots;

[Collection("Bot tests")]
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

    [Fact]
    public void Update_PrintsMessage_WhenTemperatureIsGreaterThanThreshold()
    {
        var weatherData = new WeatherData
        {
            Temperature = 35
        };
        var originalOut = System.Console.Out;
        using var writer = new StringWriter();
        System.Console.SetOut(writer);
        _sunBot.Update(weatherData);
        System.Console.SetOut(originalOut);
        Assert.Equal("It is sunny today!\r\n", writer.ToString());
    }

    [Fact]
    public void Update_DoesNotPrintMessage_WhenTemperatureIsLessThanThreshold()
    {
        var weatherData = new WeatherData
        {
            Temperature = 20
        };
        var originalOut = System.Console.Out;
        using var writer = new StringWriter();
        System.Console.SetOut(writer);
        _sunBot.Update(weatherData);
        System.Console.SetOut(originalOut);
        Assert.Empty(writer.ToString());
    }
}