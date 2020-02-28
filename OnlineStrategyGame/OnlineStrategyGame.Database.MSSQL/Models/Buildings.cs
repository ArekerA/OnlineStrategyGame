using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OnlineStrategyGame.Database.MSSQL.Models
{
    public class Buildings
    {
        [Key]
        public int Id { get; set; }
        public Planet Planet { get; set; }
        public int? PlanetId { get; set; }
        public Moon Moon { get; set; }
        public int? MoonId { get; set; }

        public int CarbonMine { get; set; }
        public int UraniumMine { get; set; }
        public int AluminiumMine { get; set; }
        public int TitaniumMine { get; set; }
        public int HydrogenExtractor { get; set; }
        public int Helium3Extractor { get; set; }

        public int ParticleAccelerator { get; set; }
        public int GrapheneProductionPlant { get; set; }
        public int AluminiumFactory { get; set; }
        public int TitaniumFactory { get; set; }

        public int CoalPowerStation { get; set; }
        public int SolarPowerPlant { get; set; }
        public int NuclearPowerPlant { get; set; }
        public int FusionPowerPlant { get; set; }
        public int HydrogenPowerPlant { get; set; }

        public int Warehouse { get; set; }
        public int Helium3Tank { get; set; }
        public int HydrogenTank { get; set; }
        public int AntimatterTank { get; set; }

        public int Laboratory { get; set; }
        public int Shipyard { get; set; }
        public int RobotFactory { get; set; }

        public int Farm { get; set; }
        public int Greenhouse { get; set; }
        public int Cities { get; set; }
        public int SkyCities { get; set; }
        public int Terraformer { get; set; }
    }
}
