namespace DefaultNamespace;

public interface IWeatherDataParser
{
    WeatherData Parse(string data);
}