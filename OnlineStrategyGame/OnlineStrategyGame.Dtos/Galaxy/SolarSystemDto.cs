using OnlineStrategyGame.Database.MSSQL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineStrategyGame.Dtos.Galaxy
{
    public class SolarSystemDto
    {
        public int Id { get; set; }

        public AppIdentityUser Ruler { get; set; }
        public string RulerId { get; set; }
        public StarDto Star { get; set; }
        public int StarId { get; set; }
        public List<PlanetDto> Planets { get; set; }
        public int SolarSystemId { get; set; }
        public int CordX { get; set; }
        public int CordY { get; set; }
        public int CordZ { get; set; }
    }
}
