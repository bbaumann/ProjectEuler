using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler
{
    class Program
    {
        
        static void Main(string[] args)
        {
            GetProblem(29).Solve();
            Console.Read();
        }

        static IProjectEulerProblem GetProblem(int i)
        {
            switch (i)
            {
                case 17:
                    return new LettersInNumbers();
                case 19:
                    return new NumberOfSundays();
                case 20:
                    return new FactorialSumOfDigits();
                case 26:
                    return new ReciprocalCycles();
                case 29:
                    return new DistinctPowers();
                case 31:
                    return new Coins();
                default:
                    break;
            }
            throw new ApplicationException("Problem not solved " + i.ToString()) ;
        }
    }
}
