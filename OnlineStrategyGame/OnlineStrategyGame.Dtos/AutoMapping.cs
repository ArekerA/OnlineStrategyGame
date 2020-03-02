using AutoMapper;
using OnlineStrategyGame.Database.MSSQL.Models;
using OnlineStrategyGame.Dtos.Galaxy;
using OnlineStrategyGame.Dtos.RaceCreator;

namespace OnlineStrategyGame.Dtos
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<Buildings, BuildingsDto>();
            CreateMap<Moon, MoonDto>();
            CreateMap<Planet, PlanetDto>();
            CreateMap<RaceBonuses, RaceBonusesDto>();
            CreateMap<Resources, ResourcesDto>();
            CreateMap<SolarSystem, SolarSystemDto>();
            CreateMap<Star, StarDto>();
            CreateMap<Technology, TechnologyDto>();
            CreateMap<Triats, TriatsDto>();


            CreateMap<BuildingsDto, Buildings>();
            CreateMap<MoonDto, Moon>();
            CreateMap<PlanetDto, Planet>();
            CreateMap<RaceBonusesDto, RaceBonuses>();
            CreateMap<ResourcesDto, Resources>();
            CreateMap<SolarSystemDto, SolarSystem>();
            CreateMap<StarDto, Star>();
            CreateMap<TechnologyDto, Technology>();
            CreateMap<TriatsDto, Triats>();
        }
    }
}