using OnlineStrategyGame.Localisation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    public static class RaceCreatorBonusTypeExtensionMethods
    {
        public static string ToFriendlyString(this RaceCreatorBonusType t)
        {
            switch (t)
            {
                case RaceCreatorBonusType.MilitaryOffensive:
                    return Localisation.Localisation.RaceCreator_MilitaryOffensive;
                case RaceCreatorBonusType.MilitaryDefensive:
                    return Localisation.Localisation.RaceCreator_MilitaryDefensive;
                case RaceCreatorBonusType.Economy:
                    return Localisation.Localisation.RaceCreator_Economy;
                case RaceCreatorBonusType.Research:
                    return Localisation.Localisation.RaceCreator_Research;
                case RaceCreatorBonusType.MilitaryTechnology:
                    return Localisation.Localisation.RaceCreator_MilitaryTechnology;
                case RaceCreatorBonusType.ExplorationTechnology:
                    return Localisation.Localisation.RaceCreator_ExplorationTechnology;
                case RaceCreatorBonusType.EspionageTechnology:
                    return Localisation.Localisation.RaceCreator_EspionageTechnology;
                case RaceCreatorBonusType.ExtendedPlanet:
                    return Localisation.Localisation.RaceCreator_ExtendedPlanet;
                default:
                    return "RaceCreatorBonusType.Undefined";
            }
        }
    }
}
