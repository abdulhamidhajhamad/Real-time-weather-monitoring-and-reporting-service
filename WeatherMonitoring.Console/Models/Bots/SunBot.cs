namespace WeatherMonitoring.Console.Bots;
using WeatherMonitoring.Console.Models;

public class SunBot : Bot
{
    public double TemperatureThreshold { get; set; }
    public SunBot(BotConfiguration config)
    {
        Enabled = config.Enabled;
        Message = config.Message;
        TemperatureThreshold = config.Threshold;
    }

    public override bool ShouldActivate(WeatherData data)
    {
        return data.Temperature > TemperatureThreshold;
    }
}