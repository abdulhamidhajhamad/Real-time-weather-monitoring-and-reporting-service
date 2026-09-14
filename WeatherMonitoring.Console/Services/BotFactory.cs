namespace WeatherMonitoring.Console.Services;
using WeatherMonitoring.Console.Bots;

public class BotFactory
{
    public IBot CreateBot(string type, BotConfiguration config)
    {
        return type switch
        {
            "RainBot" => new RainBot(config),
            "SunBot" => new SunBot(config),
            "SnowBot" => new SnowBot(config),
            _ => throw new ArgumentException($"Unknown bot type: {type}")
        };
    }
}