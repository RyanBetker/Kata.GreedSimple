using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kata.Greed.Simple
{
    class Player
    {

        public List<Turn> Turns { get; set; }
        /// <summary>
        /// Player's current score
        /// </summary>
        public int Score { get; private set; }

        /// <summary>
        /// Whether or not a person can take a score under 500
        /// </summary>
        public bool IsOpen { get; set; }
    }
}
