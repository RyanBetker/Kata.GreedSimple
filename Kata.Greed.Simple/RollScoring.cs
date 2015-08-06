using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kata.Greed.Simple
{
    public class RollScoring
    {
        public RollScoring(int[] diceRolled)
        {
            DiceGroupsScored = InitializeDiceToZero();

            Dice = GroupDiceByDieNumber(diceRolled);
        }

        private Dictionary<int, int> InitializeDiceToZero()
        {
            var dice = new Dictionary<int, int>();
            for (int i = 1; i < 7; i++)
            {
                dice.Add(i, 0);
            }
            return dice;
        }

        private Dictionary<int, int> GroupDiceByDieNumber(int[] diceRolled)
        {
            return diceRolled.GroupBy(g => g).ToDictionary(kvp => kvp.Key, kvp => kvp.Count());
        }

        public Dictionary<int, int> Dice { get; private set; }
        private Dictionary<int, int> DiceGroupsScored { get; set; }
        private Dictionary<int, int> DiceGroupsToScore
        {
            get
            {
                return Dice.Except(DiceGroupsScored).ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
            }
        }
        
        internal int Score()
        {
            //All scoring, one by one.
            int score = 0;
#region Scoring for 6 dice

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
            //Three ones: 1000, or Three of any: # * 100
            score += ScoreThreeOfAny();
            
            //also score up the singles
            score += ScoreSingleOne();            
            score += ScoreSingleFives();

            return score;
        }

        private int ScoreSingleFives()
        {
            return DiceGroupsToScore.FirstOrDefault(g => g.Key == 5).Value * 50;
        }

        private int ScoreSingleOne()
        {
            var groupOfOnes = DiceGroupsToScore.FirstOrDefault(d => d.Key == 1);

            return groupOfOnes.Value * 100;
        }

        private int ScoreFiveOfAny()
        {
            var groupOfFive = DiceGroupsToScore.FirstOrDefault(g => g.Value == 5);
            if (groupOfFive.Value == 5)
            {
                //Account for used dice.
                DiceGroupsScored[groupOfFive.Key] += groupOfFive.Value;
                return 2000;
            }
            return 0;
        }

        private int ScoreSixOfAny()
        {
            if (DiceGroupsToScore.First().Value == 6)
            {
                return 3000;
            }
            return 0;
        }

        private int ScoreFullStraight()
        {
            if (DiceGroupsToScore.Count() == 6)
            {
                return 1500;
            }
            return 0;
        }

        private int ScoreThreeOfAny()
        {
            var groupOfThreeDice = DiceGroupsToScore.FirstOrDefault(d => d.Value == 3);

            if (groupOfThreeDice.Key == 0)//3 of kind wasn't found
            {
                return 0;
            }

            //remove the dice we're scoring
            DiceGroupsScored[groupOfThreeDice.Key] += groupOfThreeDice.Value;
            
            if (groupOfThreeDice.Key == 1)
            {
                return 1000; 
            }
            else
            {
                return groupOfThreeDice.Key * 100;
            }
        }

        private int ScoreFourOfAny()
        {
            KeyValuePair<int, int> groupOfFour = DiceGroupsToScore.FirstOrDefault(g => g.Value == 4);
            if (groupOfFour.Value > 0)
            {
                DiceGroupsScored[groupOfFour.Key] += groupOfFour.Value;
                return 1000;
            }
            return 0;
        }

        private int ScoreThreePairs()
        {
            //make sure there are 3 groups, and as well as each group having count of 2
            if(DiceGroupsToScore.Count() == 3 && DiceGroupsToScore.All(g => g.Value == 2))
            {
                return 1500;
            }
            return 0;
        }

        private int ScoreFourOfAnyWithAPair()
        {
            if (DiceGroupsToScore.Count() == 2 && DiceGroupsToScore.Any(g => g.Value == 4))
            {
                return 1500;
            }
            return 0;
        }

        private int ScoreTwoTriplets()
        {
            var rollGrouped = DiceGroupsToScore;
            
            //Expanding to not score FourDice+Pair.
            if (DiceGroupsToScore.Count() == 2
                && DiceGroupsToScore.All(g => g.Value == 3))//and 3 dice in each
            {
                return 2500; 
            }
            return 0;
        }

    }
}