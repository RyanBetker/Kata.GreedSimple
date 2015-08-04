using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kata.Greed.Simple
{
    class Game
    {
        private List<Player> players;

        public Game(int numberOfPlayers)
        {
            // TODO: Complete member initialization
            this.players = new List<Player>(numberOfPlayers);
        }
    }
}
