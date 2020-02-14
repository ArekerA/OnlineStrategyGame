using OnlineStrategyGame.Dtos.Galaxy;

namespace OnlineStrategyGame.Base.Galaxy
{
    public interface ISolarSystemManager
    {
        SolarSystemDto GetSolarSystem(int cordX, int cordY, int cordZ);
    }
}