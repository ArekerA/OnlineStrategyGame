using OnlineStrategyGame.Dtos.RaceCreator;
using OnlineStrategyGame.Dtos.RaceCreator.Enums;
using OnlineStrategyGame.Localisation;
using System.Collections.Generic;

namespace OnlineStrategyGame.Base.RaceCreator
{
    public static class RaceCreatorStatic
    {
        private static List<RaceCreatorElementDto> elements;

        public static List<RaceCreatorElementDto> Elements
        {
            get
            {
                if (elements == null)
                    elements = InitElements();
                return elements;
            }
            private set => elements = value;
        }

        private static List<RaceCreatorElementDto> InitElements()
        {
            var element11 = new RaceCreatorElementDto()
            {
                Id = 11,
                Name = Localisation.Localisation.RaceCreator_Lizardman_Name,
                Description = Localisation.Localisation.RaceCreator_Lizardman_Description,
                Bonuses = new List<RaceCreatorBonusElementDto>()
                {
                    new RaceCreatorBonusElementDto()
                    {
                        Type = RaceCreatorBonusType.MilitaryOffensive,
                        Value = 1.1
                    },
                    new RaceCreatorBonusElementDto()
                    {
                        Type = RaceCreatorBonusType.MilitaryDefensive,
                        Value = 1.1
                    }
                }
            };
            var element12 = new RaceCreatorElementDto()
            {
                Id = 12,
                Name = Localisation.Localisation.RaceCreator_Human_Name,
                Description = Localisation.Localisation.RaceCreator_Human_Description,
                Bonuses = new List<RaceCreatorBonusElementDto>()
                {
                    new RaceCreatorBonusElementDto()
                    {
                        Type = RaceCreatorBonusType.Economy,
                        Value = 1.15
                    }
                }
            };
            var element21 = new RaceCreatorElementDto()
            {
                Id = 21,
                Name = Localisation.Localisation.RaceCreator_Fanaticism_Name,
                Description = Localisation.Localisation.RaceCreator_Fanaticism_Description,
                Bonuses = new List<RaceCreatorBonusElementDto>()
                {
                    new RaceCreatorBonusElementDto()
                    {
                        Type = RaceCreatorBonusType.MilitaryOffensive,
                        Value = 1.3
                    }
                }
            };
            var element22 = new RaceCreatorElementDto()
            {
                Id = 22,
                Name = Localisation.Localisation.RaceCreator_Military_Name,
                Description = Localisation.Localisation.RaceCreator_Military_Description,
                Bonuses = new List<RaceCreatorBonusElementDto>()
                {
                    new RaceCreatorBonusElementDto()
                    {
                        Type = RaceCreatorBonusType.MilitaryOffensive,
                        Value = 1.1
                    },
                    new RaceCreatorBonusElementDto()
                    {
                        Type = RaceCreatorBonusType.MilitaryDefensive,
                        Value = 1.1
                    },
                    new RaceCreatorBonusElementDto()
                    {
                        Type = RaceCreatorBonusType.Economy,
                        Value = 1.1
                    }
                }
            };
            var element23 = new RaceCreatorElementDto()
            {
                Id = 23,
                Name = Localisation.Localisation.RaceCreator_Creativity_Name,
                Description = Localisation.Localisation.RaceCreator_Creativity_Description,
                Bonuses = new List<RaceCreatorBonusElementDto>()
                {
                    new RaceCreatorBonusElementDto()
                    {
                        Type = RaceCreatorBonusType.Research,
                        Value = 1.3
                    }
                }
            };
            var element24 = new RaceCreatorElementDto()
            {
                Id = 24,
                Name = Localisation.Localisation.RaceCreator_Trade_Name,
                Description = Localisation.Localisation.RaceCreator_Trade_Description,
                Bonuses = new List<RaceCreatorBonusElementDto>()
                {
                    new RaceCreatorBonusElementDto()
                    {
                        Type = RaceCreatorBonusType.Economy,
                        Value = 1.3
                    }
                }
            };
            var element31 = new RaceCreatorElementDto()
            {
                Id = 31,
                Name = Localisation.Localisation.RaceCreator_Extermination_Name,
                Description = Localisation.Localisation.RaceCreator_Extermination_Description,
                Bonuses = new List<RaceCreatorBonusElementDto>()
                {
                    new RaceCreatorBonusElementDto()
                    {
                        Type = RaceCreatorBonusType.MilitaryOffensive,
                        Value = 1.3
                    },
                    new RaceCreatorBonusElementDto()
                    {
                        Type = RaceCreatorBonusType.MilitaryDefensive,
                        Value = 1.3
                    },
                    new RaceCreatorBonusElementDto()
                    {
                        Type = RaceCreatorBonusType.Economy,
                        Value = .9
                    },
                    new RaceCreatorBonusElementDto()
                    {
                        Type = RaceCreatorBonusType.MilitaryTechnology,
                        Value = 1
                    }
                }
            };
            var element32 = new RaceCreatorElementDto()
            {
                Id = 32,
                Name = Localisation.Localisation.RaceCreator_SignalFromSpace_Name,
                Description = Localisation.Localisation.RaceCreator_SignalFromSpace_Description,
                Bonuses = new List<RaceCreatorBonusElementDto>()
                {
                    new RaceCreatorBonusElementDto()
                    {
                        Type = RaceCreatorBonusType.Research,
                        Value = 1.3
                    }
                }
            };
            var element33 = new RaceCreatorElementDto()
            {
                Id = 33,
                Name = Localisation.Localisation.RaceCreator_Exploration_Name,
                Description = Localisation.Localisation.RaceCreator_Exploration_Description,
                Bonuses = new List<RaceCreatorBonusElementDto>()
                {
                    new RaceCreatorBonusElementDto()
                    {
                        Type = RaceCreatorBonusType.Economy,
                        Value = 1.2
                    },
                    new RaceCreatorBonusElementDto()
                    {
                        Type = RaceCreatorBonusType.Research,
                        Value = 1.1
                    },
                    new RaceCreatorBonusElementDto()
                    {
                        Type = RaceCreatorBonusType.ExplorationTechnology,
                        Value = 1
                    }
                }
            };
            var element34 = new RaceCreatorElementDto()
            {
                Id = 34,
                Name = Localisation.Localisation.RaceCreator_Corporation_Name,
                Description = Localisation.Localisation.RaceCreator_Corporation_Description,
                Bonuses = new List<RaceCreatorBonusElementDto>()
                {
                    new RaceCreatorBonusElementDto()
                    {
                        Type = RaceCreatorBonusType.Economy,
                        Value = 1.35
                    },
                    new RaceCreatorBonusElementDto()
                    {
                        Type = RaceCreatorBonusType.ExtendedPlanet,
                        Value = 1
                    }
                }
            };
            var element35 = new RaceCreatorElementDto()
            {
                Id = 35,
                Name = Localisation.Localisation.RaceCreator_ArmsRace_Name,
                Description = Localisation.Localisation.RaceCreator_ArmsRace_Description,
                Bonuses = new List<RaceCreatorBonusElementDto>()
                {
                    new RaceCreatorBonusElementDto()
                    {
                        Type = RaceCreatorBonusType.MilitaryOffensive,
                        Value = 1.1
                    },
                    new RaceCreatorBonusElementDto()
                    {
                        Type = RaceCreatorBonusType.MilitaryDefensive,
                        Value = 1.1
                    },
                    new RaceCreatorBonusElementDto()
                    {
                        Type = RaceCreatorBonusType.Research,
                        Value = 1.1
                    },
                    new RaceCreatorBonusElementDto()
                    {
                        Type = RaceCreatorBonusType.MilitaryTechnology,
                        Value = 1
                    }
                }
            };
            var element36 = new RaceCreatorElementDto()
            {
                Id = 36,
                Name = Localisation.Localisation.RaceCreator_InformationWepon_Name,
                Description = Localisation.Localisation.RaceCreator_InformationWepon_Description,
                Bonuses = new List<RaceCreatorBonusElementDto>()
                {
                    new RaceCreatorBonusElementDto()
                    {
                        Type = RaceCreatorBonusType.Economy,
                        Value = 1.2
                    },
                    new RaceCreatorBonusElementDto()
                    {
                        Type = RaceCreatorBonusType.Research,
                        Value = 1.1
                    },
                    new RaceCreatorBonusElementDto()
                    {
                        Type = RaceCreatorBonusType.EspionageTechnology,
                        Value = 1
                    }
                }
            };

            element11.Childrens = new List<RaceCreatorElementDto>()
            {
                element21,
                element22,
                element23
            };
            element12.Childrens = new List<RaceCreatorElementDto>()
            {
                element22,
                element23,
                element24
            };
            element21.Childrens = new List<RaceCreatorElementDto>()
            {
                element31,
                element32,
                element35
            };
            element22.Childrens = new List<RaceCreatorElementDto>()
            {
                element32,
                element35,
                element36
            };
            element23.Childrens = new List<RaceCreatorElementDto>()
            {
                element32,
                element33,
                element36
            };
            element24.Childrens = new List<RaceCreatorElementDto>()
            {
                element32,
                element33,
                element34
            };

            return new List<RaceCreatorElementDto>()
            {
                element11,
                element12,
                element21,
                element22,
                element23,
                element24,
                element31,
                element32,
                element33,
                element34,
                element35,
                element36
            };
        }
    }
}