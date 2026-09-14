using System.Diagnostics;
using WeatherMonitoring.Console.Bots;
using WeatherMonitoring.Console.Models;
using WeatherMonitoring.Console.Services;
using Xunit;

namespace WeatherMonitoring.Tests.Services;
public class BotFactoryTests
{
    private readonly BotFactory _factory;
    private readonly BotConfiguration _config;
    public BotFactoryTests()
    {
        _factory = new BotFactory();

        _config = new BotConfiguration
        {
            Enabled = true,
            Threshold = 70,
            Message = "Test message"
        };
    }
    
    [Fact]
    public void CreateBot_ReturnsRainBot_WhenTypeIsRainBot()
    {
        var bot = _factory.CreateBot("RainBot", _config);

        Assert.IsType<RainBot>(bot);
    }

    [Fact]
    public void CreateBot_ReturnsSnowBot_WhenTypeIsSnowBot()
    {
        var bot=_factory.CreateBot("SnowBot", _config);
        Assert.IsType<SnowBot>(bot);
    }

    [Fact]
    public void CreateBot_ReturnsSunBot_WhenTypeIsSunBot()
    {
        var bot=_factory.CreateBot("SunBot", _config);
        Assert.IsType<SunBot>(bot);
    }
    [Fact]
    public void CreateBot_ThrowsException_WhenTypeIsUnknown()
    {
        Assert.Throws<ArgumentException>(() =>
            _factory.CreateBot("UnknownBot", _config));
    }
}