using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nomen.Utility
{
    class StringCombinator
    {
        private IList<ISet<string>> sets;

        public StringCombinator()
        {
            this.sets = new List<ISet<string>>();
        }

        public void AddSet(params string[] strings)
        {
            sets.Add(new HashSet<string>(strings));
        }

        public IEnumerable<string> Enumerate()
        {
            return this.Enumerate(0);
        }

        private IEnumerable<string> Enumerate(int index)
        {
            if ((index < 0) || (index >= sets.Count))
                throw new IndexOutOfRangeException();

            if (index == sets.Count - 1)
            {
                foreach (var item in sets[index])
                    yield return item;
            }
            else
            {
                foreach (var suffix in this.Enumerate(index + 1))
                    foreach (var prefix in sets[index])
                        yield return string.Concat(prefix, suffix);
            }
        }
    }
}
