using OnlineStrategyGame.Dtos.RaceCreator;
using OnlineStrategyGame.Dtos.RaceCreator.Enums;
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
                Name = "Jaszczuroludzie",
                Description = "",
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
                Name = "Ludzie",
                Description = "",
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
                Name = "Fanatyzm",
                Description = "",
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
                Name = "Wojskowość",
                Description = "",
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
                Name = "Kreatywność",
                Description = "",
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
                Name = "Handel",
                Description = "",
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
                Name = "Wyniszczenie",
                Description = "",
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
                Name = "Sygnał z kosmosu",
                Description = "",
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
                Name = "Eksploracja",
                Description = "",
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
                Name = "Korporacje",
                Description = "",
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
                Name = "Wyścig zbrojeń",
                Description = "",
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
                Name = "Informacja bronią",
                Description = "",
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