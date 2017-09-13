using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler
{
    public static class Utils
    {
        public static string FormatList(IEnumerable<int> list)
        {
            return "[" + String.Join<int>(",",list) + "]";
        }

        public static string DisplayNumbers(IEnumerable<int> list)
        {
            return String.Join<int>("", list);
        }

    }
}
