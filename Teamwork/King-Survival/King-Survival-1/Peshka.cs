using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarqIPeshkite
{
    class Peshka
    {
        //tova e klasa Peshka, koito zadava peshak s koordinati X i Y

        int x;
        int y;

        public Peshka()
        {
            this.x = 0;
            this.y = 0;
        }
        public Peshka(int x, int y)
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