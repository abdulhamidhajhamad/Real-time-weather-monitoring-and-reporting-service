using System.Xml.Serialization;
using WeatherMonitoring.Console.Models;

namespace WeatherMonitoring.Console.Parsers;

public class XmlWeatherDataParser : IWeatherDataParser
{
    public WeatherData Parse(string data)
    {
        var serializer = new XmlSerializer(typeof(WeatherData));

        using var reader = new StringReader(data);

        return (WeatherData)serializer.Deserialize(reader)!;
    }
}