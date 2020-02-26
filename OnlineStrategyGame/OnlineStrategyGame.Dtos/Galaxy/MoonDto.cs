using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineStrategyGame.Dtos.Galaxy
{
    public class MoonDto
    {
        public int Id { get; set; }
        public ResourcesDto Resources { get; set; }
        public PlanetDto Planet { get; set; }
        public int PlanetId { get; set; }
    }
}
