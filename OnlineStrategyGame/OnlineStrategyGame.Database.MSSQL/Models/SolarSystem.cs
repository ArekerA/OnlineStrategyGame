using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OnlineStrategyGame.Database.MSSQL.Models
{
    /// <summary>
    /// Store information about solar system
    /// </summary>
    public class SolarSystem
    {
        [Key]
        public int Id { get; set; }

        public Star Star { get; set; }
        public int StarId { get; set; }
        public List<Planet> Planets { get; set; }
        public int CordX { get; set; }
        public int CordY { get; set; }
        public int CordZ { get; set; }
    }
}