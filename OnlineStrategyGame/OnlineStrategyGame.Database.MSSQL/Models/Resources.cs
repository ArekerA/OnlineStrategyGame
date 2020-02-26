using System.ComponentModel.DataAnnotations;

namespace OnlineStrategyGame.Database.MSSQL.Models
{
    public class Resources
    {
        [Key]
        public int Id { get; set; }

        public Planet Planet { get; set; }
        public int? PlanetId { get; set; }
        public Moon Moon { get; set; }
        public int? MoonId { get; set; }

        public long Carbon { get; set; }
        public long Uranium { get; set; }
        public long Titanium { get; set; }
        public long Aluminium { get; set; }
        public long Hydrogen { get; set; }
        public long Food { get; set; }
        public long Graphene { get; set; }
        public long AluminiumAlloy { get; set; }
        public long TitaniumAlloy { get; set; }
        public long Antimatter { get; set; }
        public long Helium3 { get; set; }
    }
}