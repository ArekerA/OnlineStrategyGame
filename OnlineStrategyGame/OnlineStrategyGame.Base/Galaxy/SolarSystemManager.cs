using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OnlineStrategyGame.Base.Galaxy.Interfaces;
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

        private bool CheckIfSolarSystemExist(int cordX, int cordY, int cordZ)
        {
            return GalaxyProceduralGenerator.CheckIfSolarSystemExist(cordX, cordY, cordZ);
        }

        public bool CheckIfSolarSystemExist(int id)
        {
            return _context.SolarSystems.Any(e => e.Id == id);
        }

        private SolarSystemDto GetOrCreateSolarSystemFromDatabase(int cordX, int cordY, int cordZ)
        {
            if (CheckIfSolarSystemExist(cordX, cordY, cordZ))
            {
                var solarSystem = _context.SolarSystems
                    .Include(a => a.Star)
                    .Include(a => a.Planets)
                    .FirstOrDefault(a => a.CordX == cordX && a.CordY == cordY && a.CordZ == cordZ);
                if (solarSystem == null)
                {
                    return CreateNewSolarSystem(cordX, cordY, cordZ);
                }
                return _mapper.Map<SolarSystemDto>(solarSystem);
            }
            return null;
        }

        private SolarSystemDto CreateNewSolarSystem(int cordX, int cordY, int cordZ)
        {
            var solarSystemDto = GalaxyProceduralGenerator.CreateSolarSystem(cordX, cordY, cordZ);
            var solarSystem = _mapper.Map<SolarSystem>(solarSystemDto);
            _context.SolarSystems.Add(solarSystem);
            _context.SaveChanges();
            return _mapper.Map<SolarSystemDto>(solarSystem);//Double map because all ids are needed 
        }
    }
}