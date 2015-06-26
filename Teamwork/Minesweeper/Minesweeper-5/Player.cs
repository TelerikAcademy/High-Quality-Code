using System;
using System.Collections.Generic;
using System.Text;

namespace Minesweeper
{
    class Player : IComparable
    {
        public Player(string name, int score)
        {
            this.name = name;
            this.score = score;
        }
        private string name;
        private int score;
        public string Name
        {
            get { return this.name; }
        }
        public int Score
        {
            get { return this.score; }
        }
        public int CompareTo(object obj)
        {
            if (!(obj is Player))
            {
                throw new ArgumentException(
                   "A Player object is required for comparison.");
            }
            return -1 * this.score.CompareTo(((Player)obj).score);
        }
        public override string ToString()
        {
            string result = this.name + " --> " + this.score;
            return result;
        }
    }
}
