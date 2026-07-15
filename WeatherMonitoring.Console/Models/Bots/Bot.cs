namespace WeatherMonitoring.Console.Bots;
using WeatherMonitoring.Console.Models;

public abstract class Bot : IBot
{
    public bool Enabled { get; set; }
    public string Message { get; set; } = string.Empty;

    public void Update(WeatherData weatherData)
    {
        if (!Enabled) return;
        if (ShouldActivate(weatherData))
            PrintMessage();
    }

    protected void PrintMessage() => System.Console.WriteLine(Message);

    public abstract bool ShouldActivate(WeatherData data);
}