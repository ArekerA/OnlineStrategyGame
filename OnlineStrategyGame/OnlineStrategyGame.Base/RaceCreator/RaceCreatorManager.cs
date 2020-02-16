using OnlineStrategyGame.Base.RaceCreator.Interfaces;
using OnlineStrategyGame.Dtos.RaceCreator;
using OnlineStrategyGame.Dtos.RaceCreator.Enums;
using System.Collections.Generic;
using System.Linq;

namespace OnlineStrategyGame.Base.RaceCreator
{
    public class RaceCreatorManager : IRaceCreatorManager
    {
        private const int _firstLevelMaxId = 20;

        public IEnumerable<RaceCreatorElementDto> GetElements(int id = 0)
        {
            if (id == 0)
                return RaceCreatorStatic.Elements.Where(a => a.Id < _firstLevelMaxId);
            else
                return RaceCreatorStatic.Elements.Find(a => a.Id == id)?.Childrens;
        }

        public RaceCreatorElementDto GetElement(int id)
        {
            return RaceCreatorStatic.Elements.Find(a => a.Id == id);
        }

        public Dictionary<RaceCreatorBonusType, double> GetSummaryBonuses(IEnumerable<RaceCreatorElementDto> elements)
        {
            var result = new Dictionary<RaceCreatorBonusType, double>();
            foreach (var item in elements)
            {
                foreach (var bonus in item.Bonuses)
                {
                    if (result.ContainsKey(bonus.Type))
                    {
                        result[bonus.Type] *= bonus.Value;
                    }
                    else
                    {
                        result.Add(bonus.Type, bonus.Value);
                    }
                }
            }
            return result;
        }

        //public IEnumerable<string> GetSummary(int)
    }
}