using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler
{
    class ReciprocalCycles : IProjectEulerProblem
    {
        public void Solve()
        {
            int res = 0;
            int resVal = 0;
            for (int i = 2; i < 1000; i++)
            {
                int? r = findCycleLength(i);
                if (r.HasValue && r.Value > resVal)
                {
                    resVal = r.Value;
                    res = i;
                }
            }
            Log.Info("Max Cycle length is {0} for n = {1}", resVal,res);
        }

        /// <summary>
        /// Find the recurring cycle digit length in 1/n if any
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        private int? findCycleLength(int n)
        {
            int num = (int)Math.Pow(10,((int)Math.Log10((double)n) + 1));
            
            // reste => Premiere position où on l'a vu
            Dictionary<int,int> rests = new Dictionary<int, int>();
            List<int> successivesNumbers = new List<int>();
            int i = 0;
            int rest = num;
            int oldnum = num;
            int startIndex = 0;
            int endIndex = 0;
            while (rest != 0)
            {
                rest = num % n;
                if (rests.ContainsKey(rest))
                {
                    int nextNum = num / n;
                    startIndex = rests[rest];
                    endIndex = i;
                    if (nextNum != successivesNumbers[rests[rest]])
                    {
                        successivesNumbers.Add(nextNum);
                        startIndex++;
                    }
                    break;
                }
                successivesNumbers.Add(num / n);
                rests[rest] = i;
                oldnum = num;
                num = rest*10;
                i++;
            }
            if (rest == 0)
            {
                Log.Debug("n={1}, No Cycle {0}", (double)1 / (double)n, n);
                return null;
            }
            //else
            int res = endIndex - startIndex;
            StringBuilder zeros = new StringBuilder();
            for (int z = 0; z < (int)Math.Log10((double)n); z++)
            {
                zeros.Append("0");
            }
            Log.Debug("n={3}, Cycle found : 0.{4}{0}({1}), Length {2}", Utils.DisplayNumbers(successivesNumbers.Take(startIndex)),Utils.DisplayNumbers(successivesNumbers.Skip(startIndex)), res, n,zeros.ToString());
            
            return res;
        }
    }
}
