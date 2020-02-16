using OnlineStrategyGame.Dtos.RaceCreator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStrategyGame.WebApp.Models
{
    public class RaceCreatorViewModel
    {
        public IEnumerable<RaceCreatorElementDto> Elements { get; set; }
        public string HeaderName { get; set; }
        public string HeaderDescription { get; set; }
    }
}
