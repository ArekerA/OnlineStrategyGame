using System.ComponentModel.DataAnnotations;

namespace OnlineStrategyGame.Dtos.Galaxy
{
    /// <summary>
    /// Star characteristic
    /// </summary>
    public class StarDto
    {
        public int Id { get; set; }

        public float Mass { get; set; }
        public float Radius { get; set; }
        public float GravitationalAcceleration { get; set; }
        public float Temperature { get; set; }
        public SolarSystemDto SolarSystem { get; set; }
    }
}