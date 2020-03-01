using OnlineStrategyGame.Dtos.Galaxy;

namespace OnlineStrategyGame.Base.Galaxy.Interfaces
{
    public interface ISolarSystemManager
    {
        bool CheckIfSolarSystemExist(int id);
        SolarSystemDto GetSolarSystem(int cordX, int cordY, int cordZ);
    }
}