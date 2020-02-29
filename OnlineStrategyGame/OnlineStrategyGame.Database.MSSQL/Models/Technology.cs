using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OnlineStrategyGame.Database.MSSQL.Models
{
    public class Technology
    {
        [Key]
        public int Id { get; set; }
        public AppIdentityUser AppIdentityUser { get; set; }
        public string AppIdentityUserId { get; set; }
        public int Combat { get; set; }
        public int Exploration { get; set; }
        public int Espionage { get; set; }
        public int Protective { get; set; }
        public int Material { get; set; }
        public int Quantum { get; set; }
        public int QuantumHardware { get; set; }
        public int CombustionDrive { get; set; }
        public int ImpulseDrive { get; set; }
        public int HyperspaceDrive { get; set; }
        public int Laser { get; set; }
        public int Ion { get; set; }
        public int Plasma { get; set; }
        public int Gravity { get; set; }
        public int Hiperspace { get; set; }
        public int Energy { get; set; }
    }
}
