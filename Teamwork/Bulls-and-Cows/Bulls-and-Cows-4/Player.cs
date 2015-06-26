using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BullsAndCowsGame
{
    class Player: IComparable<Player>
    {
        public string Name { get; set; }
        public int Attempts { get; set; }
        public Player(string playerName, int attempts)
        {
            this.Name = playerName;


            this.Attempts = attempts;
        }
        public int CompareTo(Player other)
        {
            if (other == null) return 1;
            return (other.Attempts - this.Attempts);
        }
    }
}
