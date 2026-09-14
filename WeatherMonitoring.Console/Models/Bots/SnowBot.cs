namespace WeatherMonitoring.Console.Bots;
using WeatherMonitoring.Console.Models;

public class SnowBot : Bot
{
    public double HumidityThreshold { get; set; }
    public SnowBot(BotConfiguration config)
    {
        Enabled = config.Enabled;
        Message = config.Message;
        HumidityThreshold = config.Threshold;
    }

    public override bool ShouldActivate(WeatherData data)
    {
        return data.Humidity > HumidityThreshold;
    }
}