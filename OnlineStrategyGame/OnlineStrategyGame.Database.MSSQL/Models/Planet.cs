﻿using System.ComponentModel.DataAnnotations;

namespace OnlineStrategyGame.Database.MSSQL.Models
{
    /// <summary>
    /// Planet characteristic
    /// </summary>
    public class Planet
    {
        [Key]
        public int Id { get; set; }

        public float Mass { get; set; }
        public float Radius { get; set; }
        public float GravitationalAcceleration { get; set; }
        public float MaxTemperature { get; set; }
        public float MinTemperature { get; set; }
        public float DistancenToStar { get; set; }
        public SolarSystem SolarSystem { get; set; }
        public int SolarSystemId { get; set; }
    }
}