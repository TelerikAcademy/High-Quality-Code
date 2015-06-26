using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BalloonsPops
{
    class Person
    {
        string name;
        int score;

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

        public int Score
        {
            get
            {
                return score;
            }
            set
            {
                score = value;
            }
        }

        public static bool operator <(Person x, Person y)
        {
            return x.Score < y.Score;
        }

        public static bool operator >(Person x, Person y)
        {
            return x.Score > y.Score;
        }
    }
}
