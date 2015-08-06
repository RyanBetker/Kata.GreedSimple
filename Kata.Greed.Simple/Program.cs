using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kata.Greed.Simple
{
    /* Ryan Betker
       08/06/15
     
     * Kata Greed attempt without classes and only 5 dice.
     * Much simpler logic :)
     */
    class Program
    {
        static void Main(string[] args)
        {
            do
            {
                var roll = MakeARandomRoll();

                int score = ScoreRoll(roll);

                //ScoreRoll(new int[] { 1, 2, 3, 4, 5, 6 });
                Console.WriteLine("");
                Console.WriteLine("Dies rolled: ");

                for (int i = 0; i < roll.Length; i++)
                {
                    Console.Write(roll[i] + " ");
                }
                Console.WriteLine("You rolled a score of: {0}", score);

                Console.WriteLine("Wanna go again? Y/N");
            } while (Console.ReadKey().KeyChar == 'y');
        }

        private static int[] MakeARandomRoll()
        {
            var diceMade = new int[6];

            var r = new Random();
            var diceIndex = 0;
            while (diceIndex <= 5)
            {
                diceMade[diceIndex] = r.Next(1, 6);
                diceIndex++;
            }

            return diceMade;
        }

        public static int ScoreRoll(int[] diceRolled)
        {
            Dictionary<int, int> diceGrouped = diceRolled.GroupBy(g => g).ToDictionary(kvp => kvp.Key, kvp => kvp.Count());
            var score = 0;
            var triple = diceGrouped.FirstOrDefault(g => g.Value >= 3);

            if (triple.Key > 0)
            {
                diceGrouped[triple.Key] -= 3;//remove the used dice

                if (triple.Key == 1)
                    score += 1000;
                else
                    score += triple.Key * 100;
            }

            var onesCount = diceGrouped.FirstOrDefault(g => g.Key == 1).Value;
            score += onesCount * 100;

            var fivesCount = diceGrouped.FirstOrDefault(g => g.Key == 5).Value;
            score += fivesCount * 50;

            return score;
        }
    }
}
