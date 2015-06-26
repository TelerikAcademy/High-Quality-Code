using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BalloonsPops
{
    class PersonScoreComparer : IComparer<Person>
    {
        public int Compare(Person x, Person y)
        {
            return x.Score.CompareTo(y.Score);
        }
    }
}
