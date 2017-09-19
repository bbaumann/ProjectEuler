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
            GetProblem(17).Solve();
            Console.Read();
        }

        static IProjectEulerProblem GetProblem(int i)
        {
            switch (i)
            {
                case 17:
                    return new LettersInNumbers();
                case 26:
                    return new ReciprocalCycles();
                case 31:
                    return new Coins();
                default:
                    break;
            }
            throw new ApplicationException("Problem not solved " + i.ToString()) ;
        }
    }
}
