using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nomen.Names
{
    class NameBuilder
    {
        private IList<string> subnames, titles;
        
        public NameBuilder()
        {
            this.subnames = new List<string>();
            this.titles = new List<string>();
        }

        public void AddSubname(string subname)
        {
            subnames.Add(subname);
        }

        public void AddTitle(string title)
        {
            titles.Add(title);
        }

        public Name Build()
        {
            return new Name(subnames, titles);
        }
    }
}
