using System;
using System.Collections.Generic;
using System.Globalization;

namespace OnlineStrategyGame.Base.Names
{
    public static class NamesGenerator
    {
        private static int _minPlanetSyllables = 2;
        private static int _maxPlanetSyllables = 4;
        private static int _minNameSyllables = 2;
        private static int _maxNameSyllables = 5;

        public static List<string> MiddleEastLikeSyllables = new List<string>()
        {
            "al", "hal", "hyi", "wa", "hu", "zuz", "haf", "ayah", "qu", "qa", "dib", "dra", "taj", "ak", "ga", "hud", "id", "rog", "fah", "has",
        };

        public static List<string> FarEastLikeSyllables = new List<string>()
        {
           "izen", "mon", "fay", "shi", "zag", "blarg", "rash",
        };

        public static List<string> SciFi1Syllables = new List<string>()
        {
           "turn", "ter", "nus", "rus", "tania", "hiri", "hines", "gawa", "nides", "carro", "rilia", "stea", "lia", "lea", "ria", "nov", "phus", "mia", "nerth", "wei", "ruta", "tov", "zuno", "vis", "lara", "nia", "liv", "tera", "gantu", "yama", "tune", "ter", "nus", "cury", "bos", "pra", "thea", "nope", "tis", "clite"
        };

        public static List<string> SciFi2Syllables = new List<string>()
        {
           "una", "ion", "iea", "iri", "illes", "ides", "agua", "olla", "inda", "eshan", "oria", "ilia", "erth", "arth", "orth", "oth", "illon", "ichi", "ov", "arvis", "ara", "ars", "yke", "yria", "onoe", "ippe", "osie", "one", "ore", "ade", "adus", "urn", "ypso", "ora", "iuq", "orix", "apus", "ion", "eon", "eron", "ao", "omia"
        };

        public static List<string> Name1Syllables = new List<string>()
        {
           "bea", "bis", "bo", "dah", "del", "den", "dia", "dore", "dows", "fey", "gan", "gish", "gren", "hala", "hana", "hel", "hina", "kala", "kira", "la", "lara", "laris", "las", "lear", "less", "lia", "lis", "lore", "mani", "mer", "mia", "mora", "mu", "muria", "mus", "naha", "nahar", "nara", "nas", "nase", "nee", "neer", "nemo", "nera", "nero", "ney", "neya", "nis", "nor", "nora", "now", "noya", "nya", "nyss", "phae", "phis", "pyre", "ra", "raya", "sira", "sium", "soah", "sone", "sora", "tia", "tira", "tory", "tu", "vana", "ven", "vyre", "wan", "wen", "wyn", "zo"
        };

        public static List<string> Name2Syllables = new List<string>()
        {
           "'dem", "'qar", "'qira", "'xin", "'ziha", "bax", "byss", "dahn", "dell", "dess", "dis", "doze", "dues", "gara", "garn", "gash", "gor", "grinn", "hara", "hull", "huza", "jura", "kax", "kaz", "khan", "kiru", "kura", "mas", "mez", "mixar", "morta", "muria", "mus", "muy", "nahar", "naq", "naza", "naze", "nery", "nex", "nin", "nixa", "niza", "no", "nur", "nura", "ny", "paqar", "pax", "pyre", "qa", "qore", "qu", "qur", "ra", "rax", "siux", "six", "sour", "sura", "thor", "tix", "turan", "vara", "vax", "vye", "wax", "wren", "wyn", "xan", "zar", "zo", "zora", "zya", "zyss"
        };

        public static List<List<string>> PlanetsSyllables = new List<List<string>>
        {
            MiddleEastLikeSyllables,
            FarEastLikeSyllables,
            SciFi1Syllables,
            SciFi2Syllables
        };

        public static List<List<string>> NamesSyllables = new List<List<string>>
        {
            Name1Syllables,
            Name2Syllables
        };

        public static string GeneratePlanetName(int seed, int value)
        {
            var listOfSyllables = PlanetsSyllables[seed % PlanetsSyllables.Count];
            var rand = new Random(value);
            var result = "";
            var numberOfSyllables = _minPlanetSyllables + rand.Next() % (_maxPlanetSyllables - _minPlanetSyllables);
            for (int i = 0; i < numberOfSyllables; i++)
            {
                result += listOfSyllables[rand.Next() % listOfSyllables.Count];
            }
            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(result);
        }

        public static string GenerateName(int seed, int value)
        {
            var listOfSyllables = NamesSyllables[seed % NamesSyllables.Count];
            var rand = new Random(value);
            var result = "";
            var numberOfSyllables = _minNameSyllables + rand.Next() % (_maxNameSyllables - _minNameSyllables);
            for (int i = 0; i < numberOfSyllables; i++)
            {
                result += listOfSyllables[rand.Next() % listOfSyllables.Count];
            }
            if (result[0] == '\'')
                result = result.Substring(1);
            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(result);
        }

        public static string GenerateDoubleName(int seed)
        {
            var rand = new Random(seed);
            return GenerateName(rand.Next(), rand.Next()) + " " + GenerateName(rand.Next(), rand.Next());
        }
    }
}