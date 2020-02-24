using AutoMapper;
using OnlineStrategyGame.Base.RaceCreator.Interfaces;
using OnlineStrategyGame.Database.MSSQL;
using OnlineStrategyGame.Database.MSSQL.Models;
using OnlineStrategyGame.Dtos.RaceCreator;
using OnlineStrategyGame.Dtos.RaceCreator.Enums;
using System.Collections.Generic;
using System.Linq;

namespace OnlineStrategyGame.Base.RaceCreator
{
    public class RaceCreatorManager : IRaceCreatorManager
    {
        private const int _firstLevelMaxId = 20;

        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public RaceCreatorManager(ApplicationDbContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

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

        public bool Save(int[] ids, string userId)
        {
            var elements = RaceCreatorStatic.Elements.Where(a => ids.Contains(a.Id));
            var bonuses = GetSummaryBonuses(elements);
            var bonusesToSave = new RaceBonuses
            {
                AppIdentityUserId = userId,
                Economy = 1,
                EspionageTechnology = false,
                ExplorationTechnology = false,
                ExtendedPlanet = false,
                MilitaryDefensive = 1,
                MilitaryOffensive = 1,
                MilitaryTechnology = false,
                Research = 1
            };
            foreach (var item in bonuses)
            {
                switch (item.Key)
                {
                    case RaceCreatorBonusType.MilitaryOffensive:
                        bonusesToSave.MilitaryOffensive = item.Value;
                        break;
                    case RaceCreatorBonusType.MilitaryDefensive:
                        bonusesToSave.MilitaryDefensive = item.Value;
                        break;
                    case RaceCreatorBonusType.Economy:
                        bonusesToSave.Economy = item.Value;
                        break;
                    case RaceCreatorBonusType.Research:
                        bonusesToSave.Research = item.Value;
                        break;
                    case RaceCreatorBonusType.MilitaryTechnology:
                        bonusesToSave.MilitaryTechnology = true;
                        break;
                    case RaceCreatorBonusType.ExplorationTechnology:
                        bonusesToSave.ExplorationTechnology = true;
                        break;
                    case RaceCreatorBonusType.EspionageTechnology:
                        bonusesToSave.EspionageTechnology = true;
                        break;
                    case RaceCreatorBonusType.ExtendedPlanet:
                        bonusesToSave.ExtendedPlanet = true;
                        break;
                    default:
                        continue;
                }
            }
            _context.RaceBonuses.Add(bonusesToSave);
            _context.SaveChanges();
            return true;
        }
    }
}