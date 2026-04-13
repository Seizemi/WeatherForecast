using AutoFixture;
using AutoFixture.AutoMoq;
using Microsoft.Extensions.Logging;
using WebApplication1.Controllers;

namespace WeatherForecastTests
{
    [TestClass]
    public sealed class WeatherForecastControllerTests
    {
        IFixture? _fixture;
        ILogger<WeatherForecastController>? _loggerMock;
        WeatherForecastController? _sut;

        [TestInitialize]
        public void Initialization()
        {
            _fixture = new Fixture().Customize(new AutoMoqCustomization());
            _loggerMock = _fixture.Freeze<ILogger<WeatherForecastController>>();
            _sut = new(_loggerMock);
        }

        [TestMethod]
        public void WeatherForecastController_Get_ShouldReturnNonEmptyWeatherForecast()
        {
            IEnumerable<WebApplication1.WeatherForecast>? result = _sut?.Get();

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Any());
        }
    }
}
