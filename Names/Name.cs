using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nomen.Names
{
    public class Name
    {
        private static readonly IEnumerable<string> emptySequence = new string[] { };

        private string full, friendly, formal;


        public IEnumerable<string> Subnames { get; private set; }

        public IEnumerable<string> Titles { get; private set; }


        public Name(IEnumerable<string> subnames, IEnumerable<string> titles)
        {
            this.Subnames = subnames;
            this.Titles = titles;
        }

        public Name(IEnumerable<string> subnames) : this(subnames, emptySequence) { }

        public Name(params string[] subnames) : this(subnames, emptySequence) { }


        public string Full
        {
            get
            {
                if (!string.IsNullOrEmpty(full))
                    return full;
                else
                    return full = this.AssembleFull();
            }
        }

        public string Friendly
        {
            get
            {
                if (!string.IsNullOrEmpty(friendly))
                    return friendly;
                else
                    return friendly = AssembleFriendly();
            }
        }

        public string Formal
        {
            get
            {
                if (!string.IsNullOrEmpty(formal))
                    return formal;
                else
                    return formal = this.AssembleFormal();
            }
        }


        protected virtual string AssembleFull()
        {
            var result =
                this.Subnames
                    .Aggregate(string.Empty, (a, s) => string.Concat(a, " ", s))
                    .TrimStart(' ');

            if (!this.Titles.Any())
                return result;

            result += 
                this.Titles
                    .Aggregate(string.Empty, (a, t) => string.Concat(a, ", ", t));

            return result;
        }

        protected virtual string AssembleFriendly()
        {
            return this.Subnames.First();
        }

        protected virtual string AssembleFormal()
        {
            if (this.Titles.Any())
                return string.Concat(this.Subnames.Last(), " ", this.Titles.First());

            return this.Subnames.Last();
        }
    }
}
