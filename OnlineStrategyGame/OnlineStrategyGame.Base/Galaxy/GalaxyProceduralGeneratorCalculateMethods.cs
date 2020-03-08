using System;

namespace OnlineStrategyGame.Base.Galaxy
{
    public static class GalaxyProceduralGeneratorCalculateMethods
    {
        private const float _planetTemperatureMultipler = .2f;
        private const double _gravitationalConstant = 6.67430e-11;
        private const double _gasGiantMaxDensity = 3000;
        private const double _planetDenseAtmosphere = .18;
        private const double _planetAtmosphere = .08;

        public static double CalculateStarTemeperature(GalaxyProceduralGeneratorSettings settings, double mass, double radius)
        {
            mass -= settings.StarMassMinimum;
            radius -= settings.StarRadiusMinimum;
            var massMultipler = mass / (settings.StarMassMaximum - settings.StarMassMinimum);
            var radiusMultipler = 1 - (radius / (settings.StarRadiusMaximum - settings.StarRadiusMinimum));
            var temperatureFromMass = (settings.StarTemperatureMaximum - settings.StarTemperatureMinimum) * massMultipler * .5;
            var temperatureFromRadius = (settings.StarTemperatureMaximum - settings.StarTemperatureMinimum) * radiusMultipler * .5;
            return settings.StarTemperatureMinimum + temperatureFromMass + temperatureFromRadius;
        }

        public static int CalculateProceruralSeed(GalaxyProceduralGeneratorSettings settings, int x, int y, int z)
        {
            return (z + y * settings.ZWidth + x * settings.ZWidth * settings.YWidth) * settings.Seed;
        }

        public static double CalculatePlanetTemperatureMinimum(GalaxyProceduralGeneratorSettings settings, double mass, double distanceToStar, double starTemperature)
        {
            var maxTemp = CalculatePlanetTepmeratureMaximum(settings, distanceToStar, starTemperature);
            return maxTemp * (1-Math.Pow(CalaculatePlanetAtmosphere(settings, mass, maxTemp),30));
        }

        public static double CalculatePlanetTepmeratureMaximum(GalaxyProceduralGeneratorSettings settings, double distanceToStar, double starTemperature)
        {
            var starTemperatureNormalized = (starTemperature - settings.StarTemperatureMinimum) / (settings.StarTemperatureMaximum - settings.StarTemperatureMinimum);
            var distanceNormalized = (distanceToStar - settings.PlanetDistanceToStarMinimum) / (settings.PlanetDistanceToStarMaximum - settings.PlanetDistanceToStarMinimum);
            return settings.PlanetTemperatureMinimum + (settings.PlanetTemperatureMaximum - settings.PlanetTemperatureMinimum) * distanceNormalized * starTemperatureNormalized;
        }

        public static double CalculatePlanetGravitationalAcceleration(double mass, double radius)
        {
            return _gravitationalConstant * mass / (radius * 1000 * radius * 1000);
        }

        public static bool CalculateIsPlanetGasGiant(double mass, double radius)
        {
            return (mass / (4 / 3 * Math.PI * radius * radius * radius)) < _gasGiantMaxDensity;
        }
        public static double CalaculatePlanetAtmosphere(GalaxyProceduralGeneratorSettings settings, double mass, double maxTemperature)
        {
            var massNormalized = (mass - settings.PlanetMassMinimum) / (settings.PlanetMassMaximum - settings.PlanetMassMinimum);
            var temperatureNormalized = 1 - (maxTemperature - settings.PlanetTemperatureMinimum) / (settings.PlanetTemperatureMaximum - settings.PlanetTemperatureMinimum);
            return massNormalized * temperatureNormalized;
        }
        public static bool CalculateIsPlanetHasDenseAtmosphere(GalaxyProceduralGeneratorSettings settings, double mass, double maxTemperature)
        {
            return CalaculatePlanetAtmosphere(settings, maxTemperature, maxTemperature) > _planetDenseAtmosphere;
        }
        public static bool CalculateIsPlanetHasAtmosphere(GalaxyProceduralGeneratorSettings settings, double mass, double maxTemperature)
        {
            return CalaculatePlanetAtmosphere(settings, maxTemperature, maxTemperature) > _planetAtmosphere;
        }
    }
}