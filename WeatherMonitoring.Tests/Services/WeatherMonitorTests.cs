using WeatherMonitoring.Console.Models;
using WeatherMonitoring.Console.Services;
using WeatherMonitoring.Tests.TestDoubles;
using Xunit;

namespace WeatherMonitoring.Tests.Services;

public class WeatherMonitorTests
{
    private readonly WeatherMonitor _weatherMonitor;
    private readonly SpyBot _spyBot;
    private readonly WeatherData _weatherData;

    public WeatherMonitorTests()
    {
        _weatherMonitor = new WeatherMonitor();
        _spyBot = new SpyBot();

        _weatherData = new WeatherData
        {
            Temperature = 30,
            Humidity = 80
        };
    }

    [Fact]
    public void ReceiveWeatherData_CallsUpdate_OnSubscribedBot()
    {
        
        _weatherMonitor.Subscribe(_spyBot);

        
        _weatherMonitor.ReceiveWeatherData(_weatherData);

        
        Assert.Equal(1, _spyBot.UpdateCallCount);
        Assert.Same(_weatherData, _spyBot.ReceivedWeatherData);
    }

    [Fact]
    public void ReceiveWeatherData_DoesNotCallUpdate_OnUnsubscribedBot()
    {
        
        _weatherMonitor.Subscribe(_spyBot);
        _weatherMonitor.Unsubscribe(_spyBot);

        
        _weatherMonitor.ReceiveWeatherData(_weatherData);

        
        Assert.Equal(0, _spyBot.UpdateCallCount);
    }
}