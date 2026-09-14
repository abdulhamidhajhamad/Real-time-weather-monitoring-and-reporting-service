namespace WeatherMonitoring.Console.Bots;
using WeatherMonitoring.Console.Models;

public class SnowBot : Bot
{
    public double HumidityThreshold { get; set; }

    public override bool ShouldActivate(WeatherData data)
    {
        return data.Humidity > HumidityThreshold;
    }
}