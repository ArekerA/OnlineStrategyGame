using System;

namespace OnlineStrategyGame.Base.Galaxy
{
    public static class GalaxyProceduralGenerator
    {
        private const int _modulo = 1000;

        public static GalaxyProceduralGeneratorSettings Settings { get; set; }
            = GalaxyProceduralGeneratorSettings.Init()
            .SetMinX(-100)
            .SetMaxX(100)
            .SetMinY(-100)
            .SetMaxY(100)
            .SetMinZ(-100)
            .SetMaxZ(100)
            .ChanceToSolarSystemExist(800)
            .Create();

        public static bool CheckIfSolarSystemExist(int x, int y, int z)
        {
            var seed = z + y * Settings.ZWidth + x * Settings.ZWidth * Settings.YWidth;
            var rand = new Random(seed);
            var value = rand.Next() % _modulo;
            if (value > _modulo - Settings.ChanceToSolarSystemExist)
                return true;
            return false;
        }
    }
}