using System.ComponentModel.DataAnnotations;

namespace OnlineStrategyGame.Dtos.Galaxy
{
    /// <summary>
    /// Star characteristic
    /// </summary>
    public class StarDto
    {
        public int Id { get; set; }

        public double Mass { get; set; }
        public double Radius { get; set; }
        public double Temperature { get; set; }
        public SolarSystemDto SolarSystem { get; set; }
    }
}