using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameFifteenProject
{
    class Player : IComparable
    {
        private string name;
        private int moves;
        public string Name
        {
            get { return name; }
        }
        public int Moves
        {
            get { return moves; }
        }
        public Player(string name, int moves)
        {
            this.name = name;
            this.moves = moves;
        }
        public int CompareTo(object player)
        {
            Player currentPlayer = (Player)player;
            int result = this.moves.CompareTo(currentPlayer.Moves);
            return result;
        }
    }
}
