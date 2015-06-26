using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace kravi
{
    public class Record : IComparable<Record>
    {
        string name;
        int score;         
        public Record(string name, int score)
        {
            this.name = name;
            this.score = score;
        }
        public string Name
        {
            get
            {



                return name;
            }
        }
        public int Score
        {
            get
            {
                return score;
            }
        }
        public int CompareTo(Record other)
        {
            return score.CompareTo(other.score);
        }
    }
}
