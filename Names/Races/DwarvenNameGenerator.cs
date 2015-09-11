using Nomen.Sampling;
using Nomen.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nomen.Names.Races
{
    class DwarvenNameGenerator : INameGenerator
    {
        private RandomDistribution<string> nameSyllables;
        private RandomDistribution<int> nameLengths;
        private RandomDistribution<bool> titleBearing;
        private RandomDistribution<string> titles;

        public DwarvenNameGenerator()
        {
            this.InitializeLengths();
            this.InitializeSyllables();
            this.InitializeTitles();
        }

        private void InitializeSyllables()
        {
            nameSyllables = new RandomDistribution<string>();

            var longSyllables = new StringCombinator();
            longSyllables.AddSet("b", "d", "g", "n", "r", "t");
            longSyllables.AddSet("o", "u");
            longSyllables.AddSet("f", "g", "l", "k", "m", "n", "s", "r");

            foreach (var s in longSyllables.Enumerate())
            {
                if (s.StartsWith("f") || s.StartsWith("s"))
                    nameSyllables.Set(s, 0.4);
                else
                    nameSyllables.Set(s, 1.0);
            }

            var shortSyllables = new StringCombinator();
            shortSyllables.AddSet("a", "i", "e", "o", "u");
            shortSyllables.AddSet("f", "g", "l", "k", "m", "n", "s", "r");

            foreach (var s in shortSyllables.Enumerate())
            {
                if (s.EndsWith("f") || s.EndsWith("s"))
                    nameSyllables.Set(s, 1.0);
                else
                    nameSyllables.Set(s, 3.5);
            }
        }

        private void InitializeLengths()
        {
            nameLengths = new RandomDistribution<int>();

            nameLengths.Set(2, 0.70);
            nameLengths.Set(3, 0.29);
            nameLengths.Set(4, 0.01);
        }

        private void InitializeTitles()
        {
            titleBearing = new RandomDistribution<bool>();
            titleBearing.Set(true, 0.2);
            titleBearing.Set(false, 0.8);

            var monikers = new StringCombinator();
            monikers.AddSet("rock", "stone", "mountain", "ale", "battle", "axe", "hammer", "shield", "blood", "iron", "steel");
            monikers.AddSet("smasher", "climber", "hunter", "drinker", "seeker", "bearer", "cracker", "thirsty", "fist", "head", "skin", "foot", "beard");

            titles = new RandomDistribution<string>();

            foreach (var m in monikers.Enumerate())
                titles.Set(string.Concat("the ", m.Capitalize()), 1.0);
        }

        public Name Generate()
        {
            var builder = new NameBuilder();

            builder.AddSubname(this.RandomName());
            builder.AddTitle(string.Concat("son of ", this.RandomName()));

            var hasTitle = titleBearing.Sample();

            if (hasTitle)
                builder.AddTitle(titles.Sample());

            return builder.Build();
        }

        private string RandomName()
        {
            var builder = new StringBuilder();
            var length = nameLengths.Sample();

            for (var i = 0; i < length; i++)
                builder.Append(nameSyllables.Sample());

            return builder.ToString().Capitalize();
        }
    }
}
