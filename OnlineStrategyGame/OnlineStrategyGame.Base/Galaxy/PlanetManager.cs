using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OnlineStrategyGame.Base.Galaxy.Interfaces;
using OnlineStrategyGame.Database.MSSQL;
using OnlineStrategyGame.Dtos.Galaxy;
using System;
using System.Linq;

namespace OnlineStrategyGame.Base.Galaxy
{
    public class PlanetManager : IPlanetManager
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public PlanetManager(ApplicationDbContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public PlanetDto GetPlanet(int id)
        {
            var planet = _context.Planets.Include(a => a.Resources).FirstOrDefault(a => a.Id == id);
            if (planet == null)
                return null;
            return _mapper.Map<PlanetDto>(planet);
        }

        public PlanetDto GetPlanetBuildings(int id)
        {
            throw new NotImplementedException();
        }
    }
}