using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OnlineStrategyGame.Dtos.Galaxy
{
    public class TriatsDto
    {
        public int Id { get; set; }

        public PlanetDto Planet { get; set; }
        public int? PlanetId { get; set; }
        public MoonDto Moon { get; set; }
        public int? MoonId { get; set; }

        public bool NoAtmosphere { get; set; }
        public bool FriendlyAtmosphere { get; set; }
        public bool ToxicAtmosphere { get; set; }
        public bool DenseAtmosphere { get; set; }
        public bool StrongRadiation { get; set; }
        public bool Extended { get; set; }
        public bool Devastated { get; set; }
        public bool HightVolcanicActivity { get; set; }
        public bool Hot { get; set; }
        public bool Cold { get; set; }
        public bool Rocky { get; set; }
        public bool GasGiant { get; set; }
    }
}
