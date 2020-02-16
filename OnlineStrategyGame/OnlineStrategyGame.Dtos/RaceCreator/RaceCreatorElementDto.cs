using System.Collections.Generic;

namespace OnlineStrategyGame.Dtos.RaceCreator
{
    public class RaceCreatorElementDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<RaceCreatorElementDto> Childrens { get; set; }
        public List<RaceCreatorBonusElementDto> Bonuses { get; set; }
    }
}