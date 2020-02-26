using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OnlineStrategyGame.Database.MSSQL.Models
{
    public class Moon
    {
        [Key]
        public int Id { get; set; }
        public Resources Resources { get; set; }
        public Planet Planet { get; set; }
        public int PlanetId { get; set; }
    }
}
