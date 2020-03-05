using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OnlineStrategyGame.Dtos.Galaxy
{
    /// <summary>
    /// Planet characteristic
    /// </summary>
    public class PlanetDto
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public double Mass { get; set; }
        public double Radius { get; set; }
        public double GravitationalAcceleration { get; set; }
        public double MaxTemperature { get; set; }
        public double MinTemperature { get; set; }
        public double DistanceToStar { get; set; }
        public SolarSystemDto SolarSystem { get; set; }
        public int SolarSystemId { get; set; }
        public ResourcesDto Resources { get; set; }
        public List<MoonDto> Moons { get; set; }
        public BuildingsDto Buildings { get; set; }
        public TriatsDto Triats { get; set; }
        public int Population { get; set; }
    }
}