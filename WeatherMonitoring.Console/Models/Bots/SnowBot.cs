namespace WeatherMonitoring.Console.Bots;
using WeatherMonitoring.Console.Models;

public class SnowBot : Bot
{
    public double TemperatureThreshold { get; set; }
    public SnowBot(BotConfiguration config)
    {
        Enabled = config.Enabled;
        Message = config.Message;
        TemperatureThreshold = config.Threshold;
    }

    public override bool ShouldActivate(WeatherData data)
    {
        return data.Temperature < TemperatureThreshold;
    }
}