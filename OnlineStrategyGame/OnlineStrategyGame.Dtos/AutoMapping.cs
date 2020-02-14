
using AutoMapper;
using OnlineStrategyGame.Database.MSSQL.Models;
using OnlineStrategyGame.Dtos.Galaxy;

namespace OnlineStrategyGame.Dtos
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<SolarSystem, SolarSystemDto>();
        }
    }
}
