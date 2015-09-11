using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nomen.Utility
{
    public static class StringUtility
    {
        public static string Capitalize(this string s)
        {
            if (s.Length == 0)
                return s;

            if (s.Length == 1)
                return s.ToUpper();

            return string.Concat(s.Substring(0, 1).ToUpper(), s.Substring(1).ToLower());
        }
    }
}
