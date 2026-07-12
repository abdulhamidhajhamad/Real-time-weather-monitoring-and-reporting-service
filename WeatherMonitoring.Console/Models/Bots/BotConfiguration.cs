namespace WeatherMonitoring.Console.Bots;

public class BotConfiguration
{
    public bool Enabled { get; set; }

    public double Threshold { get; set; }

    public string Message { get; set; } = string.Empty;
}