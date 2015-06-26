using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace kravi
{
    public class ScoreBoard
    {
        internal Record[] board = new Record[5];

        public ScoreBoard() {
            for (int i = 0; i < 5; i++)
                board[i] = new Record("Unknown", int.MaxValue);
        }
        public void Output()
        {
            Console.WriteLine("----Scoreboard----");
            Console.WriteLine("1.(" + board[0].Score + ")" + board[0].Name);
            Console.WriteLine("2.(" + board[1].Score + ")" + board[1].Name);
            Console.WriteLine("3.(" + board[2].Score + ")" + board[2].Name);
            Console.WriteLine("4.(" + board[3].Score + ")" + board[3].Name);
            Console.WriteLine("5.(" + board[4].Score + ")" + board[4].Name);
            Console.WriteLine("------------------");
        }
    }
}
