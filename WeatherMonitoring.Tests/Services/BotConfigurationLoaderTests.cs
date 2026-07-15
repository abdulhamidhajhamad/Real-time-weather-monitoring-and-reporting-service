using WeatherMonitoring.Console.Bots;
using WeatherMonitoring.Console.Services;
using Xunit;

namespace WeatherMonitoring.Tests.Services;

public class BotConfigurationLoaderTests
{
    [Fact]
    public void LoadBots_ReturnsBots_FromConfigurationFile()
    {
        var factory = new BotFactory();

        var loader = new BotConfigurationLoader(
            "TestData/bots.json",
            factory);

        var bots = loader.LoadBots();

        Assert.Equal(2, bots.Count);

        Assert.Contains(bots, bot => bot is RainBot);
        Assert.Contains(bots, bot => bot is SnowBot);
    }
}