using NUnit.Framework;
using AzureDevOpsApi.Controllers;
using Microsoft.Extensions.Logging;
using Moq;
//samp
namespace AzureDevOpsApi.Tests
{
    [TestFixture]
    public class WeatherForecastControllerTests
    {
        [Test]
        public void Get_ReturnsWeatherForecasts()
        {
            // Arrange
            var loggerMock = new Mock<ILogger<WeatherForecastController>>();
            var controller = new WeatherForecastController(loggerMock.Object);

            // Act
            var result = controller.Get();

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<IEnumerable<WeatherForecast>>(result);

            var forecasts = result.ToArray();
            Assert.AreEqual(5, forecasts.Length);

            foreach (var forecast in forecasts)
            {
                Assert.IsNotNull(forecast.Date);
                Assert.GreaterOrEqual(forecast.TemperatureC, -20);
                Assert.LessOrEqual(forecast.TemperatureC, 55);
                Assert.IsNotNull(forecast.Summary);
            }
        }
    }
}
