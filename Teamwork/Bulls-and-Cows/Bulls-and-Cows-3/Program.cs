using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace kravi
{
//Helloween sa mnogo zdravi, yaaaaaaaaaaahh snoshti biah na koncerta!!!!!!!!!!!!
    public delegate void TopScoresDelegate(Game g, ScoreBoard board);
    class Program
    {
        private static void DoTopScores(Game g, ScoreBoard board)
        {
            if (g.score != -1 && g.score < board.board[4].Score)
            {
                Console.Write("TOP SCORE! Please enter your name:");
                string name = Console.ReadLine();



                List<Record> list = new List<Record>(board.board);
                list.Add(new Record(name, g.score));
                list.Sort();
                for (int i = 0; i < 5; i++)
                    board.board[i] = list[i];
            }
        }

        static void Main()
        {
            ScoreBoard board = new ScoreBoard();
            while (new Game(board, DoTopScores).Run()) { }
        }
    }
}
