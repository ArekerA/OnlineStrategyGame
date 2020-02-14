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

        public float Mass { get; set; }
        public float Radius { get; set; }
        public float GravitationalAcceleration { get; set; }
        public float Temperature { get; set; }
    }
}