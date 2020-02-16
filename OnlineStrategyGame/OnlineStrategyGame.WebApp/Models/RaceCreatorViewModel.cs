using OnlineStrategyGame.Dtos.RaceCreator;
using OnlineStrategyGame.Dtos.RaceCreator.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStrategyGame.WebApp.Models
{
    public class RaceCreatorViewModel
    {
        public List<RaceCreatorElementDto> Elements { get; set; } = new List<RaceCreatorElementDto>();
        public string HeaderName { get; set; }
        public string HeaderDescription { get; set; }
        public List<int> SelectedIds { get; set; } = new List<int>();
        public List<RaceCreatorElementDto> Selected { get; set; } = new List<RaceCreatorElementDto>();
        public Dictionary<RaceCreatorBonusType, double> Bonuses { get; set; } = new Dictionary<RaceCreatorBonusType, double>();
    }
}
