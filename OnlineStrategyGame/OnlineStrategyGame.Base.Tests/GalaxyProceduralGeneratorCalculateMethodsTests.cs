using NUnit.Framework;
using OnlineStrategyGame.Base.Galaxy;

namespace OnlineStrategyGame.Base.Tests
{
    public class GalaxyProceduralGeneratorCalculateMethodsTests
    {
        public GalaxyProceduralGeneratorSettings settings;
        [SetUp]
        public void Setup()
        {
            settings = GalaxyProceduralGenerator.Settings;
        }

        [Test]
        public void CalculateStarTemeperatureForMinMassAndMinRadiusTest()
        {
            var result = GalaxyProceduralGeneratorCalculateMethods.CalculateStarTemeperature(settings, settings.StarMassMinimum, settings.StarRadiusMinimum);
            var exceptedResult = settings.StarTemperatureMinimum + (settings.StarTemperatureMaximum - settings.StarTemperatureMinimum) / 2;
            Assert.AreEqual(exceptedResult, result);
        }
        [Test]
        public void CalculateStarTemeperatureForMaxMassAndMinRadiusTest()
        {
            var result = GalaxyProceduralGeneratorCalculateMethods.CalculateStarTemeperature(settings, settings.StarMassMaximum, settings.StarRadiusMinimum);
            Assert.AreEqual(settings.StarTemperatureMaximum, result);
        }
        [Test]
        public void CalculateStarTemeperatureForMinMassAndMaxRadiusTest()
        {
            var result = GalaxyProceduralGeneratorCalculateMethods.CalculateStarTemeperature(settings, settings.StarMassMinimum, settings.StarRadiusMaximum);
            Assert.AreEqual(settings.StarTemperatureMinimum, result);
        }
        [Test]
        public void CalculateStarTemeperatureForMaxMassAndMaxRadiusTest()
        {
            var result = GalaxyProceduralGeneratorCalculateMethods.CalculateStarTemeperature(settings, settings.StarMassMaximum, settings.StarRadiusMaximum);
            var exceptedResult = settings.StarTemperatureMinimum + (settings.StarTemperatureMaximum - settings.StarTemperatureMinimum) / 2;
            Assert.AreEqual(exceptedResult, result);
        }
        [Test]
        public void CalculateIsPlanetHasDenseAtmosphereTest()
        {
            GalaxyProceduralGeneratorCalculateMethods.CalculateIsPlanetHasDenseAtmosphere(settings, 4.867e24, 737);
            var result = GalaxyProceduralGeneratorCalculateMethods.CalculateStarTemeperature(settings, settings.StarMassMaximum, settings.StarRadiusMaximum);
            var exceptedResult = settings.StarTemperatureMinimum + (settings.StarTemperatureMaximum - settings.StarTemperatureMinimum) / 2;
            Assert.AreEqual(exceptedResult, result);
        }
    }
}