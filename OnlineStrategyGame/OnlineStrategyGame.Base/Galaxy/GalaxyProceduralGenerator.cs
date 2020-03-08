using OnlineStrategyGame.Dtos.Galaxy;
using System;
using System.Collections.Generic;
using Calculate = OnlineStrategyGame.Base.Galaxy.GalaxyProceduralGeneratorCalculateMethods;

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
            .SetPlanetNumber(2,12)
            .SetPlanetMass(4.0013e21,2.468e28)//kg
            .SetPlanetRadius(2257.812, 209733)//km
            .SetPlanetTemperature(50,7000)//K
            .SetPlanetDistanceToStar(3.141e5, 1.032e9)//km
            .SetPlanetFriendlyAtmosphereChance(200)
            .SetPlanetToxicAtmosphereChance(200)
            .SetPlanetStrongRadiationChance(100)
            .SetPlanetHightVolcanicActivityChance(100)
            .SetPlanetHotTreshold(340)
            .SetPlanetColdTreshold(230)
            .SetMoonNumberMinimum(0)
            .SetMoonNumberMaximum(3)
            .SetMoonStrongRadiationChance(100)
            .Create();

        public static bool CheckIfSolarSystemExist(int x, int y, int z)
        {
            var rand = new Random(Calculate.CalculateProceruralSeed(Settings, x, y, z));
            var value = rand.Next() % _modulo;
            if (value > _modulo - Settings.ChanceToSolarSystemExist)
                return true;
            return false;
        }

        public static SolarSystemDto CreateSolarSystem(int x, int y, int z)
        {
            var rand = new Random(Calculate.CalculateProceruralSeed(Settings, x, y, z));
            var value = rand.Next() % _modulo;

            var solarSystem = new SolarSystemDto
            {
                CordX = x,
                CordY = y,
                CordZ = z
            };
            solarSystem.Star = CreateStar(value);
            solarSystem.Planets = CreatePlanets(value, solarSystem.Star.Temperature);

            return solarSystem;
        }
        public static StarDto CreateStar(int randomValue)
        {
            var rand = new Random(randomValue * Settings.Seed);
            var value = rand.Next() % (_modulo*10);
            var mass = Settings.StarMassMinimum + (value * _modulo * 10) / (Settings.StarMassMaximum - Settings.StarMassMinimum);
            value = rand.Next() % (_modulo * 10);
            var radius = Settings.StarRadiusMinimum + (value * _modulo * 10) / (Settings.StarRadiusMaximum - Settings.StarRadiusMinimum);
            var star = new StarDto
            {
                Mass = mass,
                Radius = radius,
                Temperature = Calculate.CalculateStarTemeperature(Settings, mass, radius)
            };
            return star;
        }
        public static List<PlanetDto> CreatePlanets(int randomValue, double starTemperature)
        {
            var result = new List<PlanetDto>();
            var rand = new Random(randomValue * Settings.Seed);
            var value = rand.Next();
            var valueDouble = rand.NextDouble();
            var numberOfPlanets = Settings.PlanetNumberMinimum + value % (Settings.PlanetNumberMaximum - Settings.PlanetNumberMinimum);
            for (int i = 0; i < numberOfPlanets; i++)
            {
                var mass = Settings.PlanetMassMinimum + rand.NextDouble() * (Settings.PlanetMassMaximum - Settings.PlanetMassMinimum);
                var radius = Settings.PlanetRadiusMinimum + rand.NextDouble() * (Settings.PlanetRadiusMaximum - Settings.PlanetRadiusMinimum);
                var distanceToStar = Settings.PlanetDistanceToStarMinimum + rand.NextDouble() * (Settings.PlanetDistanceToStarMaximum - Settings.PlanetDistanceToStarMinimum);
                var planet = new PlanetDto
                {
                    Mass = mass,
                    Radius = radius,
                    DistanceToStar = distanceToStar,
                    MinTemperature = Calculate.CalculatePlanetTemperatureMinimum(Settings, mass, distanceToStar, starTemperature),
                    MaxTemperature = Calculate.CalculatePlanetTepmeratureMaximum(Settings, distanceToStar, starTemperature),
                    GravitationalAcceleration = Calculate.CalculatePlanetGravitationalAcceleration(mass, radius),
                    Moons = CreateMoons(value),
                    Name = GeneratePlanetName(),
                    Population = 0,
                    Resources = new ResourcesDto(),
                    Buildings = new BuildingsDto()
                };
                planet.Triats = GenerateTriatsForPlanet(planet, value);
                result.Add(planet);
            }
            return result;
        }

        private static TriatsDto GenerateTriatsForPlanet(PlanetDto planet, int value)
        {
            var rand = new Random(value * Settings.Seed);
            var triats = new TriatsDto();
            triats.Rocky = true;
            if (Calculate.CalculateIsPlanetGasGiant(planet.Mass, planet.Radius))
            {
                triats.GasGiant = true;
                triats.Rocky = false;
            }
            else if (Calculate.CalculateIsPlanetHasDenseAtmosphere(Settings, planet.Mass, planet.MaxTemperature))
            {
                triats.DenseAtmosphere = true;
            }
            else if (!Calculate.CalculateIsPlanetHasAtmosphere(Settings, planet.Mass, planet.MaxTemperature))
            {
                triats.NoAtmosphere = true;
            }

            var number = rand.Next() % _modulo;
            if (triats.Rocky && !triats.NoAtmosphere && number < Settings.PlanetFriendlyAtmosphereChance)
            {
                triats.FriendlyAtmosphere = true;
            }

            number = rand.Next() % _modulo;
            if (triats.Rocky && !triats.NoAtmosphere && number < Settings.PlanetToxicAtmosphereChance)
            {
                triats.ToxicAtmosphere = true;
            }

            number = rand.Next() % _modulo;
            if (number < Settings.PlanetStrongRadiationChance)
            {
                triats.StrongRadiation = true;
            }

            number = rand.Next() % _modulo;
            if (triats.Rocky && number < Settings.PlanetHightVolcanicActivityChance)
            {
                triats.HightVolcanicActivity = true;
            }
            
            if((planet.MinTemperature+planet.MaxTemperature)/2 > Settings.PlanetHotTreshold)
            {
                triats.Hot = true;
            }
            else if ((planet.MinTemperature + planet.MaxTemperature) / 2 < Settings.PlanetColdTreshold)
            {
                triats.Cold = true;
            }

            return triats;
        }

        private static string GeneratePlanetName()
        {
            throw new NotImplementedException();
        }

        private static List<MoonDto> CreateMoons(int value)
        {
            var result = new List<MoonDto>();
            var numberOfMoons = Settings.MoonNumberMinimum + value % (Settings.MoonNumberMaximum - Settings.MoonNumberMinimum);
            for (int i = 0; i < numberOfMoons; i++)
            {
                var moon = new MoonDto
                {
                    Buildings = new BuildingsDto(),
                    Population = 0,
                    Resources = new ResourcesDto()
                };
                moon.Triats = GenerateTriatsForMoon(moon, value);
                result.Add(moon);
            }
            return result;
        }

        private static TriatsDto GenerateTriatsForMoon(MoonDto moon, int value)
        {
            var rand = new Random(value * Settings.Seed);
            var triats = new TriatsDto();
            triats.Rocky = true;
            triats.NoAtmosphere = true;
            triats.Cold = true;

            var number = rand.Next() % _modulo;
            if (number < Settings.MoonStrongRadiationChance)
            {
                triats.StrongRadiation = true;
            }

            return triats;
        }
    }
}