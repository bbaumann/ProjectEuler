using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
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

        public static BigInteger Factorial(int n)
        {
            if (n < 0)
                throw new ApplicationException("Cannot compute n! if n is negative");
            BigInteger fac = 1;
            for (int i = 2; i <= n; i++)
            {
                fac = fac * i;
            }
            return fac;
        }


    }
}
