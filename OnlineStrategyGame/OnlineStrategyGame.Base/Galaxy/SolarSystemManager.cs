using AutoMapper;
using OnlineStrategyGame.Database.MSSQL;
using OnlineStrategyGame.Database.MSSQL.Models;
using OnlineStrategyGame.Dtos.Galaxy;
using System.Collections.Generic;
using System.Linq;

namespace OnlineStrategyGame.Base.Galaxy
{
    public class SolarSystemManager : ISolarSystemManager
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public SolarSystemManager(ApplicationDbContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public SolarSystemDto GetSolarSystem(int cordX, int cordY, int cordZ)
        {
            return GetOrCreateSolarSystemFromDatabase(cordX, cordY, cordZ);
        }

        private bool CheckIsSolarSystemExist(int cordX, int cordY, int cordZ)
        {
            return true;
        }

        private SolarSystemDto GetOrCreateSolarSystemFromDatabase(int cordX, int cordY, int cordZ)
        {
            if (CheckIsSolarSystemExist(cordX, cordY, cordZ))
            {
                var solarSystem = _context.SolarSystems.FirstOrDefault(a => a.CordX == cordX && a.CordY == cordY && a.CordZ == cordZ);
                if (solarSystem == null)
                {
                    var star = new Star
                    {
                        GravitationalAcceleration = 1,
                        Mass = 100,
                        Radius = 10,
                        Temperature = 100
                    };
                    var planet = new Planet
                    {
                        GravitationalAcceleration = 1,
                        Mass = 100,
                        Radius = 10,
                        DistancenToStar = 10,
                        MaxTemperature = 10,
                        MinTemperature = 0,
                    };
                    solarSystem = new SolarSystem
                    {
                        CordX = cordX,
                        CordY = cordY,
                        CordZ = cordZ,
                        Ruler = null,
                        Star = star,
                        Planets = new List<Planet>() { planet }

                    };
                    _context.SolarSystems.Add(solarSystem);
                    _context.SaveChanges();
                }
                return _mapper.Map<SolarSystemDto>(solarSystem); ;
            }
            return null;
        }
    }
}