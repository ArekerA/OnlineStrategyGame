using OnlineStrategyGame.Dtos.RaceCreator;
using OnlineStrategyGame.Dtos.RaceCreator.Enums;
using System.Collections.Generic;

namespace OnlineStrategyGame.Base.RaceCreator.Interfaces
{
    public interface IRaceCreatorManager
    {
        RaceCreatorElementDto GetElement(int id);
        IEnumerable<RaceCreatorElementDto> GetElements(int id = 0);
        Dictionary<RaceCreatorBonusType, double> GetSummaryBonuses(IEnumerable<RaceCreatorElementDto> elements);
        bool Save(int[] ids, string userId);
    }
}