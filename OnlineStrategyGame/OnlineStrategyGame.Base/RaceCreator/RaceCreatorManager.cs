using OnlineStrategyGame.Base.RaceCreator.Interfaces;
using OnlineStrategyGame.Dtos.RaceCreator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
    }
}
