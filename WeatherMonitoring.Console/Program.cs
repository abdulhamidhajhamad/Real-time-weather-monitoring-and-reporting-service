using WeatherMonitoring.Console.Parsers;
using WeatherMonitoring.Console.Services;
using WeatherMonitoring.Console.Contexts;
var factory = new BotFactory();

var loader = new BotConfigurationLoader(
    "Configuration/botsettings.json",
    factory
);

var monitor = new WeatherMonitor();

var bots = loader.LoadBots();

foreach (var bot in bots)
{
    monitor.Subscribe(bot);
}



IWeatherDataParser jsonParser = new JsonWeatherDataParser();

var jsonProcessor = new WeatherDataProcessor(jsonParser);

var jsonWeatherData = """
                      {
                          "Location": "Nablus",
                          "Temperature": 20,
                          "Humidity": 90
                      }
                      """;

var weatherFromJson = jsonProcessor.Process(jsonWeatherData);

Console.WriteLine("JSON Weather Update:");
monitor.ReceiveWeatherData(weatherFromJson);



IWeatherDataParser xmlParser = new XmlWeatherDataParser();

var xmlProcessor = new WeatherDataProcessor(xmlParser);

var xmlWeatherData = """
                     <WeatherData>
                         <Location>Nablus</Location>
                         <Temperature>35</Temperature>
                         <Humidity>30</Humidity>
                     </WeatherData>
                     """;

var weatherFromXml = xmlProcessor.Process(xmlWeatherData);

Console.WriteLine("XML Weather Update:");
monitor.ReceiveWeatherData(weatherFromXml);