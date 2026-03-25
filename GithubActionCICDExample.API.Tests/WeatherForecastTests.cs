namespace GithubActionCICDExample.API.Tests;

public class WeatherForecastTests
{
    [Theory]
    [InlineData(0, 32)]
    [InlineData(25, 76)]
    [InlineData(-20, -3)]
    [InlineData(55, 130)]
    [InlineData(100, 211)]
    public void TemperatureF_ShouldConvertFromCelsiusCorrectly(int celsius, int expectedFahrenheit)
    {
        var forecast = new WeatherForecast(DateOnly.FromDateTime(DateTime.Now), celsius, "Test");

        Assert.Equal(expectedFahrenheit, forecast.TemperatureF);
    }

    [Fact]
    public void WeatherForecast_ShouldStoreDate()
    {
        var date = new DateOnly(2026, 3, 25);

        var forecast = new WeatherForecast(date, 20, "Warm");

        Assert.Equal(date, forecast.Date);
    }

    [Fact]
    public void WeatherForecast_ShouldStoreSummary()
    {
        var forecast = new WeatherForecast(DateOnly.FromDateTime(DateTime.Now), 20, "Warm");

        Assert.Equal("Warm", forecast.Summary);
    }

    [Fact]
    public void WeatherForecast_ShouldAllowNullSummary()
    {
        var forecast = new WeatherForecast(DateOnly.FromDateTime(DateTime.Now), 20, null);

        Assert.Null(forecast.Summary);
    }

    [Fact]
    public void TemperatureF_ShouldHandleNegativeCelsius()
    {
        var forecast = new WeatherForecast(DateOnly.FromDateTime(DateTime.Now), -40, "Freezing");

        var expectedF = 32 + (int)(-40 / 0.5556);
        Assert.Equal(expectedF, forecast.TemperatureF);
    }
}