using OnlineStrategyGame.Base.Enums;
using OnlineStrategyGame.Base.Galaxy.Interfaces;
using OnlineStrategyGame.Database.MSSQL;
using OnlineStrategyGame.Dtos.Galaxy;
using System;
using System.Linq;

namespace OnlineStrategyGame.Base.Galaxy
{
    public class GalaxyManager : IGalaxyManager
    {
        private readonly ApplicationDbContext _context;
        private readonly SolarSystemManager _solarSystemManager;

        public GalaxyManager(ApplicationDbContext context, SolarSystemManager solarSystemManager)
        {
            _solarSystemManager = solarSystemManager;
            _context = context;
        }

        public PlanetDto GetFirstPlanetForUser(string userId)
        {
            PlanetDto result;
            var settings = _context.GalaxySettings.FirstOrDefault();
            if (settings == null)
                throw new NullReferenceException("No settings data in database. Check seed data.");
            bool isPlanetFind = false;
            Direction secondDirection = (Direction)settings.CordForNewPlayersSearchSecondDirection;
            Direction mainDirection = (Direction)settings.CordForNewPlayersSearchMainDirection;
            (int x, int y, int z) point = (settings.LastXCordForNewPlayers, settings.LastYCordForNewPlayers, settings.LastZCordForNewPlayers);
            while (!isPlanetFind)
            {
                point = GetNewPoint(point, ref secondDirection, ref mainDirection);
                var solarSystem = _solarSystemManager.GetSolarSystem(point.x, point.y, point.z);
                var planets = solarSystem.Planets.Where(a => !a.Triats.Cold
                && !a.Triats.Hot
                && a.Triats.Rocky
                && !a.Triats.DenseAtmosphere
                && !a.Triats.Devastated
                && !a.Triats.Extended
                && !a.Triats.GasGiant
                && !a.Triats.HightVolcanicActivity
                && !a.Triats.NoAtmosphere
                && !a.Triats.StrongRadiation
                && !a.Triats.ToxicAtmosphere);
                if(planets.Any())
                {
                    isPlanetFind = true;
                    result = planets.First();
                }
            }
            return null;
        }

        private (int, int, int) GetNewPoint((int x, int y, int z) point, ref Direction secondDirection, ref Direction mainDirection)
        {
            if (secondDirection == Direction.Forward && point.z > 0 && point.x == 0 && point.y == 0)
            {
                secondDirection = Direction.Right | Direction.Back;
                mainDirection = Direction.Back;
            }
            else if (point.z > 0 && point.x == 0 && point.y == 0)
                secondDirection = Direction.Forward;
            else if (secondDirection == Direction.Back && point.z < 0 && point.x == 0 && point.y == 0)
            {
                secondDirection = Direction.Right | Direction.Forward;
                mainDirection = Direction.Forward;
            }
            else if (point.z < 0 && point.x == 0 && point.y == 0)
                secondDirection = Direction.Back;
            else if (((secondDirection & (Direction.Right | Direction.Back)) == (Direction.Right | Direction.Back) || (secondDirection & (Direction.Right | Direction.Forward)) == (Direction.Right | Direction.Forward)) && point.y != 0)
                secondDirection = Direction.Right | Direction.Down;
            else if (secondDirection == (Direction.Right | Direction.Back) && point.y == 0)
                secondDirection = Direction.Left | Direction.Down;
            else if (point.y == 0 && point.x > 0)
                secondDirection = Direction.Left | Direction.Down;
            else if (point.x == 0 && point.y < 0)
                secondDirection = Direction.Left | Direction.Up;
            else if (point.y == 0 && point.x < 0)
                secondDirection = Direction.Right | Direction.Up;
            else if (mainDirection == Direction.Back && point.x == 0 && point.y == 1 && point.z <= 0)
                secondDirection = Direction.Down | Direction.Back;
            else if (mainDirection == Direction.Back && point.x == 0 && point.z <= 0 && point.y > 0)
                secondDirection = Direction.Right | Direction.DownDown | Direction.Back;
            else if (mainDirection == Direction.Back && point.x == 0 && point.y > 0)
                secondDirection = Direction.Right | Direction.Back;
            else if (mainDirection == Direction.Forward && point.x == 0 && point.y == 1 && point.z > 0)
                secondDirection = Direction.Down | Direction.Forward;
            else if (mainDirection == Direction.Forward && point.x == 0 && point.z >= 0 && point.y > 0)
                secondDirection = Direction.Right | Direction.DownDown | Direction.Forward;
            else if (mainDirection == Direction.Forward && point.x == 0 && point.y > 0)
                secondDirection = Direction.Right | Direction.Forward;


            if ((secondDirection & Direction.Left) == Direction.Left)
                point.x -= 1;
            if ((secondDirection & Direction.Right) == Direction.Right)
                point.x += 1;
            if ((secondDirection & Direction.Up) == Direction.Up)
                point.y += 1;
            if ((secondDirection & Direction.Down) == Direction.Down)
                point.y -= 1;
            if ((secondDirection & Direction.DownDown) == Direction.DownDown)
                point.y -= 2;
            if ((secondDirection & Direction.Forward) == Direction.Forward)
                point.z += 1;
            if ((secondDirection & Direction.Back) == Direction.Back)
                point.z -= 1;
            return point;
        }
    }
}