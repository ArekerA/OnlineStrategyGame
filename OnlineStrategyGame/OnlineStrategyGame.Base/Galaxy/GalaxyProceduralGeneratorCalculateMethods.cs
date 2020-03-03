using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineStrategyGame.Base.Galaxy
{
    public static class GalaxyProceduralGeneratorCalculateMethods
    {
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
    }
}
