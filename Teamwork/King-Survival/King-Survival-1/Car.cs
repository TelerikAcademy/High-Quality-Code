using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarqIPeshkite
{
    class Car

        // tova e carq
        //ima si koordinati
    {
        int x;
        int y;

        public Car()
        {
            this.x = 0;
            this.y = 0;
        }
        public Car(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        public int X
        {
            get { return x; }
            set { x = value; }
        }
        public int Y
        {
            get { return y; }
            set { y = value; }
        }
    }
}
