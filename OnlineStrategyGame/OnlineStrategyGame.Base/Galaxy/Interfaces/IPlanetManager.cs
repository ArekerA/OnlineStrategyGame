using OnlineStrategyGame.Dtos.Galaxy;

namespace OnlineStrategyGame.Base.Galaxy.Interfaces
{
    public interface IPlanetManager
    {
        PlanetDto GetPlanet(int id);
        PlanetDto GetPlanetBuildings(int id);
    }
}