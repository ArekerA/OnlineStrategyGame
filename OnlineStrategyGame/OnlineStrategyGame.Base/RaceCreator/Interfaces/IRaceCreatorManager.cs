using OnlineStrategyGame.Dtos.RaceCreator;
using System.Collections.Generic;

namespace OnlineStrategyGame.Base.RaceCreator.Interfaces
{
    public interface IRaceCreatorManager
    {
        IEnumerable<RaceCreatorElementDto> GetElements(int id = 0);
    }
}