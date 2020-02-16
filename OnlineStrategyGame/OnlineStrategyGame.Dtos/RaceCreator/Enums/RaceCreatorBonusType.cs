using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineStrategyGame.Dtos.RaceCreator.Enums
{
    public enum RaceCreatorBonusType
    {
        MilitaryOffensive = 1,
        MilitaryDefensive = 2,
        Economy = 4,
        Research = 8,
        MilitaryTechnology = 16,
        ExplorationTechnology = 32,
        EspionageTechnology = 64,
        ExtendedPlanet = 128,
    }
}
