namespace WeatherMonitoring.Console.Services;
using System.Text.Json;
using WeatherMonitoring.Console.Bots;

public class BotConfigurationLoader
{
    private readonly string _filePath;
    private readonly BotFactory _factory;
    public BotConfigurationLoader(string filePath, BotFactory factory)
    {
        _filePath = filePath;
        _factory = factory;
    }    
    public string ReadConfiguration()
    {
        return File.ReadAllText(_filePath);
    }
    public List<IBot> LoadBots()
    {
        var json = ReadConfiguration();

        using var document = JsonDocument.Parse(json);

        var bots = new List<IBot>();

        foreach(var bot in document.RootElement.EnumerateObject())
        {
            string type = bot.Name;

            var configElement = bot.Value;

            var config = new BotConfiguration
            {
                Enabled = configElement.GetProperty("Enabled").GetBoolean(),
                Message = configElement.GetProperty("Message").GetString() ?? ""
            };

            foreach(var property in configElement.EnumerateObject())
            {
                if(property.Name.EndsWith("Threshold"))
                {
                    config.Threshold = property.Value.GetDouble();
                    break;
                }
            }

            bots.Add(_factory.CreateBot(type, config));
        }

        return bots;
    }
}