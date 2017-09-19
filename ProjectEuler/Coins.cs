using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler
{
    //    In England the currency is made up of pound, £, and pence, p, and there are eight coins in general circulation:
    //1p, 2p, 5p, 10p, 20p, 50p, £1 (100p) and £2 (200p).
    //It is possible to make £2 in the following way:

    //1×£1 + 1×50p + 2×20p + 1×5p + 1×2p + 3×1p
    //How many different ways can £2 be made using any number of coins?
    public class Coins : IProjectEulerProblem
    {
        public void Solve()
        {
            int a = 0; //nb of 2£ coins
            int b = 0; //nb of 1£ coins
            int c = 0; //nb of 50p coins
            int d = 0; //nb of 20p coins
            int e = 0; //nb of 10p coins
            int f = 0; //nb of 5p coins
            int g = 0; //nb of 2p coins
            int h = 0; //nb of 1p coins

            //we need to fin the nb of different n-uplets (a,b,c,d,e,f,g,h) so that 200a + 100b + 50c + 20d + 10e + 5f +2g + h = 200
            //since a,b,c,d,e,f,g,h are positive we always have inequations like 200a <= 200, 200a + 100b <= 200 and so on (since 200a + X = 200 with X > 0)
            //we may find upper limits for each variable : a <= 1, b <= 2 - 2a, c <= 4 - 4a - 2b ...

            int count = 0;
            int totalPence = 200;

            for (a = 0; a <= totalPence/200; a++)
                for (b = 0; b <= (totalPence - 200 * a)/100; b++)
                    for (c = 0; c <= (totalPence - 200 * a - 100 * b)/50; c++)
                        for (d = 0; d <= (totalPence - 200 * a - 100 * b - 50 * c)/20; d++)
                            for (e = 0; e <= (totalPence - 200 * a - 100 * b - 50 * c - 20 * d)/10; e++)
                                for (f = 0; f <= (totalPence - 200 * a - 100 * b - 50 * c - 20 * d - 10 * e)/5; f++)
                                    for (g = 0; g <= (totalPence - 200 * a - 100 * b - 50 * c - 20 * d - 10 * e - 5 * f)/2; g++)
                                        //All variables are fixed, only on value for h solves the equation so 1 combination!
                                        count++;
            Console.WriteLine(count);
        }
    }
}
