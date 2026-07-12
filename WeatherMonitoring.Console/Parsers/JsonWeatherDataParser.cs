namespace DefaultNamespace;

public class JsonWeatherDataParser : IWeatherDataParser
{
    public WeatherData Parse(string data)
    {
        return JsonSerializer.Deserialize<WeatherData>(data);
    }
}