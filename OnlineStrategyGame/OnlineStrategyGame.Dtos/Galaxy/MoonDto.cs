using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineStrategyGame.Dtos.Galaxy
{
    public class MoonDto
    {
        public int Id { get; set; }
        public string RulerId { get; set; }
        public ResourcesDto Resources { get; set; }
        public BuildingsDto Buildings { get; set; }
        public PlanetDto Planet { get; set; }
        public TriatsDto Triats { get; set; }
        public int PlanetId { get; set; }
        public int Population { get; set; }
    }
}
