using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kata.Greed.Simple
{
    /// <summary>
    /// Holds logic for scoring the complete game
    /// </summary>
    public class Scoring
    {   
        //TODO: Make separate "Turn" class
        //TODO: Make separate "Roll" class
        int score = 0;

        private int[] dies;

        public Scoring ()
	    { 

	    }

        public int CalculateScore(int[] diceRoll)
        {
            dies = diceRoll;
            //ToDO: get into grouped dice
            //_groupedDice = 
            //    diceRoll.GroupBy(d => d)
            //    .ToDictionary<int, int>((g) =>g.Key);

        #region Scoring for 6 dice

            //Sort up front for all scoring so they don't have to all sort.
            Array.Sort(dies);

            //Score full straight. 1500. I'd like to make the decision to put both the  of "contains straight" and points in the same method for simplicity sake. It would be more reusable to put in 2, but is "ContainsStraight" valuable?
            score += ScoreFullStraight();
            //could have some type of escape here to not score anymore if score > 0. How to make that logic reusable though?

            //Six of any number: 3000
            score += ScoreSixOfAny();

            //2 triplets. 2500
            score += ScoreTwoTriplets();

            //Four of any + a pair. 1500
            score += ScoreFourOfAnyWithAPair();
            
            //Three pairs: 1500
            score += ScoreThreePairs();

            if (score > 0)
                return score;
	#endregion
            
            //remember to remove used dice
            //Needed though? Yes.. for something like {1,1,1,1,5,5}, 4 ones would be 1000, and they shouldn't be counted again when doing ones.
            
            //Five of any: 2000
            score += ScoreFiveOfAny();//using += in case rule lines are added befire this.
            //Four of any: 1000
            score += ScoreFourOfAny();
            return score;
            //Three ones: 1000, or Three of any: # * 100
            score += ScoreThreeOfAny();
            
            //TODO: also score singles
            score += ScoreSingleOne();
            score += ScoreSingleFives();

            return score;
        }

        private int ScoreSingleFives()
        {
            throw new NotImplementedException();
        }

        private int ScoreSingleOne()
        {
            throw new NotImplementedException();
        }

        private int ScoreFiveOfAny()
        {
            //Does the dies stack have a count of 5 in it?
            var fiveOfAny = dies.GroupBy(d => d).FirstOrDefault(g => g.Count() == 5);
            if (fiveOfAny != null)
            {
                dies = RemoveScoredDice(dies, fiveOfAny.ToArray());
                return 2000;
            }
            return 0;
        }

        private static int[] RemoveScoredDice(int[] rolledDice, int[] scoredDice)
        {
            return rolledDice.Except(scoredDice).ToArray();
        }

        private int ScoreSixOfAny()
        {
            if (dies.Count(d => d == dies[0]) == 6)
            {
                return 3000;
            }
            return 0;
        }

        private int ScoreFullStraight()
        {
            var exampleStraight = Enumerable.Range(1, 6).ToArray();
            if (exampleStraight.SequenceEqual(dies))
            {
                return 1500;
            }
            return 0;
        }

        private int ScoreThreeOfAny()
        {
            throw new NotImplementedException();
        }

        private int ScoreFourOfAny()
        {
            return 1000;
        }

        private int ScoreThreePairs()
        {
            if(dies.Distinct().Count() == 3)
            {
                return 1500;
            }
            return 0;
        }

        private int ScoreFourOfAnyWithAPair()
        {
            var rollGrouped = dies.GroupBy(d => d);

            if (rollGrouped.Count() == 2 && rollGrouped.Any(g => g.Count() == 4))
            {
                return 1500;
            }
            return 0;
        }

        private int ScoreTwoTriplets()
        {
            var rollGrouped = dies.GroupBy(d => d);
            
            //Expanding to not score FourDice+Pair.
            if (dies.Distinct().Count() == 2
                && rollGrouped.All(g => g.Count() == 3))
            {
                return 2500; 
            }
            return 0;
        }

    }
}
