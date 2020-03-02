using OnlineStrategyGame.Dtos.Galaxy;
using System;

namespace OnlineStrategyGame.Base.Galaxy
{
    public static class GalaxyProceduralGenerator
    {
        private const int _modulo = 1000;

        public static GalaxyProceduralGeneratorSettings Settings { get; set; }
            = GalaxyProceduralGeneratorSettings.Init()
            .Seed(123456789)
            .SetMinX(-100)
            .SetMaxX(100)
            .SetMinY(-100)
            .SetMaxY(100)
            .SetMinZ(-100)
            .SetMaxZ(100)
            .ChanceToSolarSystemExist(800)
            .SetStarMass(1.5913e29, 3.9782e32)//kg
            .SetStarRadius(20,9e8)//km
            .SetStarTemperature(3500,55000)//K
            .Create();

        public static bool CheckIfSolarSystemExist(int x, int y, int z)
        {
            var rand = new Random(CalculateProceruralSeed(x, y, z));
            var value = rand.Next() % _modulo;
            if (value > _modulo - Settings.ChanceToSolarSystemExist)
                return true;
            return false;
        }

        public static SolarSystemDto CreateSolarSystem(int x, int y, int z)
        {
            return null;
            /*
            var rand = new Random(CalculateProceruralSeed(x, y, z));
            var value = rand.Next() % _modulo;
            var moon = new Moon
            {
                Resources = new Resources(),
                Buildings = new Buildings(),
                Triats = new Triats(),
            };
            var planet = new Planet
            {
                GravitationalAcceleration = 1,
                Mass = 100,
                Radius = 10,
                DistanceToStar = 10,
                MaxTemperature = 10,
                MinTemperature = 0,
                Resources = new Resources(),//TODO - generowane jeśli pierwsza planeta gracza lub kolonia
                Buildings = new Buildings(),//TODO - generowane jeśli pierwsza planeta gracza
                Triats = new Triats(),//TODO - generowane
                Moons = new List<Moon>() { moon },//TODO - generowane
                Name = "XD",//TODO - generowane
                Population = 1_000_000,

            };

            var solarSystem = new SolarSystemDto
            {
                CordX = x,
                CordY = y,
                CordZ = z,
                Star = CreateStar(x, y, z, value),
                Planets = new List<Planet>() { planet }//TODO - generowane
            };

            return solarSystem;
            */
        }
        public static StarDto CreateStar(int x, int y, int z, int randomValue)
        {
            var rand = new Random(randomValue * Settings.Seed);
            var value = rand.Next() % (_modulo*10);
            var mass = Settings.StarMassMinimum + (value * _modulo * 10) / (Settings.StarMassMaximum - Settings.StarMassMinimum);
            value = rand.Next() % (_modulo * 10);
            var radius = Settings.StarRadiusMinimum + (value * _modulo * 10) / (Settings.StarRadiusMaximum - Settings.StarRadiusMinimum);
            var temp = Settings.StarTemperatureMaximum - ((mass - Settings.StarMassMinimum) * (radius - Settings.StarRadiusMinimum) * (1 / (Settings.StarTemperatureMaximum - Settings.StarTemperatureMinimum)));
            var star = new StarDto
            {
                Mass = mass,
                Radius = radius,
                Temperature = temp
            };
            return star;
        }

        private static int CalculateProceruralSeed(int x, int y, int z)
        {
            return (z + y * Settings.ZWidth + x * Settings.ZWidth * Settings.YWidth) * Settings.Seed;
        }
    }
}