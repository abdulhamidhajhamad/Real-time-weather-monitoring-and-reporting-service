namespace WeatherMonitoring.Console.Bots;
using WeatherMonitoring.Console.Models;
public interface IBot
{
    void Update(WeatherData weatherData);
}