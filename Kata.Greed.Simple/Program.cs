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
                                
            } while ((char)Console.Read() == 'y');
            //TODO: Loop only works for 2 total iterations
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

        private static int ScoreRoll(int[] dies)
        {
            return 25;
            //TODO: All scoring, one by one.
            int score = 0;
#region Scoring for 6 dice
		
            //Score full straight. 1500. I'd like to make the decision to put both the  of "contains straight" and points in the same method for simplicity sake. It would be more reusable to put in 2, but is "ContainsStraight" valuable?
            score += ScoreFullStraight(dies);
            //could have some type of escape here to not score anymore if score > 0. How to make that logic reusable though?
            
            //2 triplets. 2500
            score += ScoreTwoTriplets(dies);

            //Four of any + a pair. 1500
            score += ScoreFourOfAnyWithAPair(dies);
            //Three pairs: 1500
            score += ScoreThreePairs(dies);
            //Six of any number: 3000
            score += ScoreSixOfAny(dies);

            if (score > 0)
                return score;
	#endregion

            //remember to remove used dice
            //Needed though? Yes.. for something like {1,1,1,1,5,5}, 4 ones would be 1000, and they shouldn't be counted again when doing ones.
            
            //Five of any: 2000
            score += ScoreFiveOfAny(dies);//using += in case rule lines are added befire this.

            //Four of any: 1000
            score += ScoreFourOfAny(dies);
            //Three ones: 1000, or Three of any: # * 100
            score += ScoreThreeOfAny(dies);
            
                                  
            
            throw new NotImplementedException();
        }

        private static int ScoreFiveOfAny(int[] dies)
        {
            throw new NotImplementedException();
        }

        private static int ScoreSixOfAny(int[] dies)
        {
            throw new NotImplementedException();
        }

        private static int ScoreFullStraight(int[] dies)
        {
            throw new NotImplementedException();
        }

        private static int ScoreThreeOfAny(int[] dies)
        {
            throw new NotImplementedException();
        }

        private static int ScoreFourOfAny(int[] dies)
        {
            throw new NotImplementedException();
        }

        private static int ScoreThreePairs(int[] dies)
        {
            throw new NotImplementedException();
        }

        private static int ScoreFourOfAnyWithAPair(int[] dies)
        {
            throw new NotImplementedException();
        }

        private static int ScoreTwoTriplets(int[] dies)
        {
            throw new NotImplementedException();
        }
    }
}
