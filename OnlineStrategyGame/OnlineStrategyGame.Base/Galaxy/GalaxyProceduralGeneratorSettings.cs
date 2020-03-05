using OnlineStrategyGame.Base.Galaxy.Fluent;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineStrategyGame.Base.Galaxy
{
    public class GalaxyProceduralGeneratorSettings
    {
        public int Seed { get; private set; }
        public int XWidth
        {
            get {
                return MaxX - MinX;
            }
        }
        public int YWidth
        {
            get {
                return MaxY - MinY;
            }
        }
        public int ZWidth
        {
             get {
                return MaxZ - MinZ;
            }
        }
        public int MinX { get; private set; }
        public int MaxX { get; private set; }
        public int MinY { get; private set; }
        public int MaxY { get; private set; }
        public int MinZ { get; private set; }
        public int MaxZ { get; private set; }
        public int ChanceToSolarSystemExist { get; private set; }
        public double StarMassMinimum { get; private set; }
        public double StarMassMaximum { get; private set; }
        public double StarRadiusMinimum { get; private set; }
        public double StarRadiusMaximum { get; private set; }
        public double StarTemperatureMinimum { get; private set; }
        public double StarTemperatureMaximum { get; private set; }
        public int PlanetNumberMinimum { get; private set; }
        public int PlanetNumberMaximum { get; private set; }
        public double PlanetMassMinimum { get; private set; }
        public double PlanetMassMaximum { get; private set; }
        public double PlanetRadiusMinimum { get; private set; }
        public double PlanetRadiusMaximum { get; private set; }
        public double PlanetTemperatureMinimum { get; private set; }
        public double PlanetTemperatureMaximum { get; private set; }
        public double PlanetDistanceToStarMinimum { get; private set; }
        public double PlanetDistanceToStarMaximum { get; private set; }
        private GalaxyProceduralGeneratorSettings()
        {

        }
        public static ISeed Init()
        {
            var settings = new GalaxyProceduralGeneratorSettings();
            return new GalaxyProceduralGeneratorSettingsFluentBuilder(settings);
        }

        public class GalaxyProceduralGeneratorSettingsFluentBuilder : ISeed, ISetMinX, ISetMaxX, ISetMinY, ISetMaxY, ISetMinZ, ISetMaxZ, IChanceToSolarSystemExist, ICreate, 
            ISetStarMass, ISetStarRadius, ISetStarTemperature, 
            ISetPlanetNumber, ISetPlanetMass, ISetPlanetRadius, ISetPlanetTemperature, ISetPlanetDistanceToStar
        {
            private readonly GalaxyProceduralGeneratorSettings settings;
            public GalaxyProceduralGeneratorSettingsFluentBuilder(GalaxyProceduralGeneratorSettings settings)
            {
                this.settings = settings;
            }

            public ISetStarMass ChanceToSolarSystemExist(int chanceToSolarSystemExist)
            {
                settings.ChanceToSolarSystemExist = chanceToSolarSystemExist;
                return this;
            }

            public GalaxyProceduralGeneratorSettings Create()
            {
                return settings;
            }

            public ISetMinX Seed(int seed)
            {
                settings.Seed = seed;
                return this;
            }

            public ISetMinY SetMaxX(int maxX)
            {
                settings.MaxX = maxX;
                return this;
            }

            public ISetMinZ SetMaxY(int maxY)
            {
                settings.MaxY = maxY;
                return this;
            }

            public IChanceToSolarSystemExist SetMaxZ(int maxZ)
            {
                settings.MaxZ = maxZ;
                return this;
            }

            public ISetMaxX SetMinX(int minX)
            {
                settings.MinX = minX;
                return this;
            }

            public ISetMaxY SetMinY(int minY)
            {
                settings.MinY = minY;
                return this;
            }

            public ISetMaxZ SetMinZ(int minZ)
            {
                settings.MinZ = minZ;
                return this;
            }

            public ICreate SetPlanetDistanceToStar(double min, double max)
            {
                settings.PlanetDistanceToStarMinimum = min;
                settings.PlanetDistanceToStarMaximum = max;
                return this;
            }

            public ISetPlanetRadius SetPlanetMass(double min, double max)
            {
                settings.PlanetMassMinimum = min;
                settings.PlanetMassMaximum = max;
                return this;
            }

            public ISetPlanetMass SetPlanetNumber(int min, int max)
            {
                settings.PlanetNumberMinimum = min;
                settings.PlanetNumberMaximum = max;
                return this;
            }

            public ISetPlanetTemperature SetPlanetRadius(double min, double max)
            {
                settings.PlanetRadiusMinimum = min;
                settings.PlanetRadiusMaximum = max;
                return this;
            }

            public ISetPlanetDistanceToStar SetPlanetTemperature(double min, double max)
            {
                settings.PlanetTemperatureMinimum = min;
                settings.PlanetTemperatureMaximum = max;
                return this;
            }

            public ISetMinX SetSeed(int seed)
            {
                settings.Seed = seed;
                return this;
            }

            public ISetStarRadius SetStarMass(double min, double max)
            {
                settings.StarMassMinimum = min;
                settings.StarMassMaximum = max;
                return this;
            }

            public ISetStarTemperature SetStarRadius(double min, double max)
            {
                settings.StarRadiusMinimum = min;
                settings.StarRadiusMaximum = max;
                return this;
            }

            public ISetPlanetNumber SetStarTemperature(double min, double max)
            {
                settings.StarTemperatureMinimum = min;
                settings.StarTemperatureMaximum = max;
                return this;
            }
        }

    }
    namespace Fluent
    {
        public interface ISeed
        {
            ISetMinX Seed(int seed);
        }
        public interface ISetMinX
        {
            ISetMaxX SetMinX(int minX);
        }
        public interface ISetMaxX
        {
            ISetMinY SetMaxX(int maxX);
        }
        public interface ISetMinY
        {
            ISetMaxY SetMinY(int minY);
        }
        public interface ISetMaxY
        {
            ISetMinZ SetMaxY(int maxY);
        }
        public interface ISetMinZ
        {
            ISetMaxZ SetMinZ(int minZ);
        }
        public interface ISetMaxZ
        {
            IChanceToSolarSystemExist SetMaxZ(int maxZ);
        }
        public interface IChanceToSolarSystemExist
        {
            ISetStarMass ChanceToSolarSystemExist(int chanceToSolarSystemExist);
        }
        public interface ISetStarMass
        {
            ISetStarRadius SetStarMass(double min, double max);
        }
        public interface ISetStarRadius
        {
            ISetStarTemperature SetStarRadius(double min, double max);
        }
        public interface ISetStarTemperature
        {
            ISetPlanetNumber SetStarTemperature(double min, double max);
        }
        public interface ISetPlanetNumber
        {
            ISetPlanetMass SetPlanetNumber(int min, int max);
        }
        public interface ISetPlanetMass
        {
            ISetPlanetRadius SetPlanetMass(double min, double max);
        }
        public interface ISetPlanetRadius
        {
            ISetPlanetTemperature SetPlanetRadius(double min, double max);
        }
        public interface ISetPlanetTemperature
        {
            ISetPlanetDistanceToStar SetPlanetTemperature(double min, double max);
        }
        public interface ISetPlanetDistanceToStar
        {
            ICreate SetPlanetDistanceToStar(double min, double max);
        }
        public interface ICreate
        {
            GalaxyProceduralGeneratorSettings Create();
        }
    }
}
