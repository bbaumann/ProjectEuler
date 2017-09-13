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
            //problem26();
            Console.Read();
        }

        static void problem26()
        {

            IProjectEulerProblem problem = new ReciprocalCycles();
            problem.Solve();
        }
    }
}
