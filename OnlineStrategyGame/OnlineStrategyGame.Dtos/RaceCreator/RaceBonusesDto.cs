using OnlineStrategyGame.Database.MSSQL.Models;
using System.ComponentModel.DataAnnotations;

namespace OnlineStrategyGame.Dtos.RaceCreator
{
    public class RaceBonusesDto
    {
        public int Id { get; set; }

        public double MilitaryOffensive { get; set; }
        public double MilitaryDefensive { get; set; }
        public double Economy { get; set; }
        public double Research { get; set; }
        public bool MilitaryTechnology { get; set; }
        public bool ExplorationTechnology { get; set; }
        public bool EspionageTechnology { get; set; }
        public bool ExtendedPlanet { get; set; }
        public AppIdentityUser AppIdentityUser { get;set;}
        public string AppIdentityUserId { get; set; }
    }
}