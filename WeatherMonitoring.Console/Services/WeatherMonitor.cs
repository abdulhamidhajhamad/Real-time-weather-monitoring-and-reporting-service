namespace WeatherMonitoring.Console.Services;

using WeatherMonitoring.Console.Bots;
using WeatherMonitoring.Console.Models;

public class WeatherMonitor
{
    private readonly List<IBot> _bots = new();

    public void Subscribe(IBot bot)
    {
        _bots.Add(bot);
    }

    public void Unsubscribe(IBot bot)
    {
        _bots.Remove(bot);
    }

    public void ReceiveWeatherData(WeatherData data)
    {
        Notify(data);
    }

    private void Notify(WeatherData data)
    {
        foreach (var bot in _bots)
        {
            bot.Update(data);
        }
    }
}