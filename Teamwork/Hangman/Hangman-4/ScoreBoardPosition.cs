using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HangMan
{
    class ScoreBoardPosition : IComparable<ScoreBoardPosition>
    {
        private string name;
        public string Name
        {
            get 
            {
                return name;
            }
            set 
            {


                name = value;
            }
        }
        private int mistakes;
        public int Mistakes 
        {
            get 
            {


                return mistakes;
            }
            set
            {
                mistakes = value;
            }
        }
        public ScoreBoardPosition(string name, int mistakes) 
        {
            this.name = name;


            this.mistakes = mistakes;
        }
        public ScoreBoardPosition() : this(string.Empty, 0) { }
        public int CompareTo(ScoreBoardPosition other)
        {
            return this.Mistakes.CompareTo(other.Mistakes);
        }
    }
}
