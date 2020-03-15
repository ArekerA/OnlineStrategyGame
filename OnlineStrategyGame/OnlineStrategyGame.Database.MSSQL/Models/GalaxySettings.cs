using System.ComponentModel.DataAnnotations;

namespace OnlineStrategyGame.Database.MSSQL.Models
{
    public class GalaxySettings
    {
        [Key]
        public int Id { get; set; }

        public int LastXCordForNewPlayers { get; set; }
        public int LastYCordForNewPlayers { get; set; }
        public int LastZCordForNewPlayers { get; set; }
        public short CordForNewPlayersSearchMainDirection { get; set; }
        public short CordForNewPlayersSearchSecondDirection { get; set; }
    }
}