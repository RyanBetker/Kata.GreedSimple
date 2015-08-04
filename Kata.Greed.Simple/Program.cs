using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kata.Greed.Simple
{
    class Program
    {
        static void Main(string[] args)
        {
            var players = new List<Player>();
            players[0].Turns = new List<Turn>();
            
            new Game(numberOfPlayers: 2);

            new Roll(diceRolled: new int[] { 1, 2, 3, 4, 5, 6 });
            
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

        public static int ScoreRoll(int[] dies)
        {
            //TODO: All scoring, one by one.
            return new Scoring().CalculateScore(dies);
        }
    }
}
