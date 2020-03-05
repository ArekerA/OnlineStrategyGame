using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OnlineStrategyGame.Database.MSSQL.Models
{
    /// <summary>
    /// Planet characteristic
    /// </summary>
    public class Planet
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
        public AppIdentityUser Ruler { get; set; }
        public string RulerId { get; set; }

        public double Mass { get; set; }
        public double Radius { get; set; }
        public double GravitationalAcceleration { get; set; }
        public double MaxTemperature { get; set; }
        public double MinTemperature { get; set; }
        public double DistanceToStar { get; set; }
        public SolarSystem SolarSystem { get; set; }
        public int SolarSystemId { get; set; }
        public Resources Resources { get; set; }
        public Buildings Buildings { get; set; }
        public List<Moon> Moons { get; set; }
        public Triats Triats { get; set; }
        public int Population { get; set; }
    }
}