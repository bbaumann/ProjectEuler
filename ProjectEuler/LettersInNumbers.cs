using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler
{
    class LettersInNumbers : IProjectEulerProblem
    {

        //If the numbers 1 to 5 are written out in words: one, two, three, four, five, then there are 3 + 3 + 5 + 4 + 4 = 19 letters used in total.
        //If all the numbers from 1 to 1000 (one thousand) inclusive were written out in words, how many letters would be used?
        //NOTE: Do not count spaces or hyphens.For example, 342 (three hundred and forty-two) contains 23 letters and 115 (one hundred and fifteen) contains 20 letters.The use of "and" when writing out numbers is in compliance with British usage.
        public void Solve()
        {
            //Number of letters for numbers from one to twelve
            string[] baseWords = new string[20] { String.Empty, "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };
            int[] baseWordsLetterCount = baseWords.Select(number => number.Count()).ToArray();

            //Number of letters for dozens words
            string[] dozenWords = new string[] { String.Empty, String.Empty, "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };
            int[] dozenWordsLetterCount = dozenWords.Select(number => number.Count()).ToArray();
            
            string hundredWord = "hundred";
            int hundredWordCount = hundredWord.Count();

            string thousandWord = "thousand";
            int thousandWordCount = thousandWord.Count();

            string andWord = "and";
            int andWordCount = andWord.Count();

            int count = 0;

            for (int hundreds = 0; hundreds < 10; hundreds++)
            {
                if (hundreds != 0)
                {
                    //one hundred
                    //one hundred and one ...
                    int hundredsOverload = 100 * (baseWordsLetterCount[hundreds] + hundredWordCount) + 99 * andWordCount;
                    count += hundredsOverload;
                }
                for (int i = 1; i <= 19; i++)
                {
                    count += baseWordsLetterCount[i];
                }

                for (int i = 20; i <= 99; i++)
                {
                    count += dozenWordsLetterCount[i / 10];
                    count += baseWordsLetterCount[i % 10];
                }
            }
            //one thousand
            count += thousandWordCount + baseWordsLetterCount[1];
            Console.WriteLine(count);
        }
    }
}
