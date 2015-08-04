using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kata.Greed.Simple
{
    public class Roll
    {
        private int[] diceRolled;

        public Roll(int[] diceRolled)
        {
            this.diceRolled = diceRolled;
        }

        public Dictionary<int, int> Dice { get; set; }
        private Dictionary<int, int> DiceScored { get; set; }
        public Dictionary<int, int> DiceToScore 
        { 
            get 
            {
                return Dice.Except(DiceScored).ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
            } 
        }
        public int Score { get; set; }
    }
}
