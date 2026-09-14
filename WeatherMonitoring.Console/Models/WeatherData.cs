namespace WeatherMonitoring.Console.Models;
public class WeatherData
{
    public string Location {get;set; }=String.Empty;
    public double Temperature { get; set; }
    public double Humidity { get; set; }
}