using System;
using System.Numerics;

namespace ProjectEuler
{
    internal class FactorialSumOfDigits : IProjectEulerProblem
    {
        public void Solve()
        {
            BigInteger n = Utils.Factorial(100);

            int sum = 0;
            while (n > 0)
            {
                sum += (int)(n % 10);
                n = n / 10;
            }
            Console.WriteLine(sum);
        }
    }
}