using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kata.Greed.Simple
{
    public class ScoreKeeper
    {
        internal static int Score(int[] roll)
        {
            return new RollScoring(roll).Score();
        }
    }
}
