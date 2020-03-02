using System.ComponentModel.DataAnnotations;

namespace OnlineStrategyGame.Database.MSSQL.Models
{
    /// <summary>
    /// Star characteristic
    /// </summary>
    public class Star
    {
        [Key]
        public int Id { get; set; }

        public double Mass { get; set; }
        public double Radius { get; set; }
        public double Temperature { get; set; }
        public SolarSystem SolarSystem { get; set; }
    }
}