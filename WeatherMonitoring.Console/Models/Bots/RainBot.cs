namespace WeatherMonitoring.Console.Bots;
using WeatherMonitoring.Console.Models;

public class RainBot : Bot
{
    public double HumidityThreshold { get; set; }

    public override bool ShouldActivate(WeatherData data)
    {
        return data.Humidity > HumidityThreshold;
    }


        }