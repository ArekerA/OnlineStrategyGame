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
        public float Mass { get; set; }
        public float Radius { get; set; }
        public float GravitationalAcceleration { get; set; }
        public float MaxTemperature { get; set; }
        public float MinTemperature { get; set; }
        public float DistanceToStar { get; set; }
        public SolarSystemDto SolarSystem { get; set; }
        public int SolarSystemId { get; set; }
    }
}