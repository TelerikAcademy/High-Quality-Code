using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

//harasva li vi koda? za vruzka s mene v Twitter sym #shisho33
namespace BalloonsPops
{
	public class Baloons
	{
		const int shirina = 5;
		const int length = 10;

		private static int ost = shirina * length;
		private static int counter = 0;	private static int clearedCells = 0;
                		public static string[,] _t = new string[shirina, length];
		public static StringBuilder tmp = new StringBuilder();
		private static SortedDictionary<int, string> statistics = new SortedDictionary<int, string>();

        public static void Start()
        {
			Console.WriteLine("Welcome to “Balloons Pops” game. Please try to pop the balloons. Use 'top' to view the top scoreboard, 'restart' to start a new game and 'exit' to quit the game.");
			ost = shirina * length;
			counter = 0;

			clearedCells = 0;
            for (int i = 0; i < shirina; i++)
            {
                for (int j = 0; j < length; j++)
                {
                    _t[i, j] = RND.GetRandomInt();
                }
            }
            Console.WriteLine("    0 1 2 3 4 5 6 7 8 9");
            Console.WriteLine("   ---------------------");

            for (int i = 0; i < shirina; i++)
            {
                Console.Write(i + " | ");

                for (int j = 0; j < length; j++)
                {
                    Console.Write(_t[i, j] + " ");
                }
                Console.Write("| ");
                Console.WriteLine();
            }

            Console.WriteLine("   ---------------------");
            GameLogic(tmp);
        }

		public static void GameLogic(StringBuilder userInput)
		{
				PlayGame();
				counter++;
				userInput.Clear();
				GameLogic(userInput);
			

		}
		private static bool IsLegalMove(int i, int j)
		{
			if ((i < 0) || (j < 0) || (j > length - 1) || (i > shirina - 1)) return false;
			else return (_t[i, j] != ".");
		}

		private static void greshka()
		{
			Console.WriteLine("Invalid move or command");
			tmp.Clear(); 
			GameLogic(tmp); 
		}

		private static void InvalidMove()
		{
			Console.WriteLine("Illegal move: cannot pop missing ballon!");
			tmp.Clear();
			GameLogic(tmp);


		}

		private static void ShowStatistics()
		{
			PrintAgain();
		}

		private static void Exit()
		{
			Console.WriteLine("Good Bye");
			Thread.Sleep(1000);
			Console.WriteLine(counter.ToString());
			Console.WriteLine(ost.ToString());
			Environment.Exit(0);
		}

		private static void Restart()
		{


			Start();
		}

		private static void ReadTheIput()
		{
			if (!IsFinished())
			{
				Console.Write("Enter a row and column: ");
				tmp.Append(Console.ReadLine());
			}
			else
			{
				Console.Write("opal;aaaaaaaa! You popped all baloons in "+ counter +" moves."
								 +"Please enter your name for the top scoreboard:");
				tmp.Append(Console.ReadLine());
				statistics.Add(counter, tmp.ToString());
				PrintAgain();
				tmp.Clear();
				Start();
			}
		}

		private static void PrintAgain()
		{
			int p = 0;



			Console.WriteLine("Scoreboard:");
			foreach(KeyValuePair<int, string> s in statistics)
			{
				if (p == 4) break;
				else
				{
					p++;
					Console.WriteLine("{0}. {1} --> {2} moves",p , s.Value, s.Key);
				}
			}
		}
        private static void PlayGame()
        {
			int i = -1;
			int j = -1;

			Play :
ReadTheIput();

			string hop = tmp.ToString();

			if (tmp.ToString() == "") greshka();
			if (tmp.ToString() == "top") { ShowStatistics(); tmp.Clear(); goto Play; }
			if (tmp.ToString() == "restart") { tmp.Clear(); Restart(); }
			if (tmp.ToString() == "exit") Exit();

			string activeCell;
			tmp.Replace(" ", "");
			try
			{
				i = Int32.Parse(tmp.ToString()) / 10;
				j = Int32.Parse(tmp.ToString()) % 10;
			}
			catch(Exception) 
			{
				greshka();
			}
            if (IsLegalMove(i, j))
			{
				activeCell = _t[i, j];
				clear(i, j, activeCell);
			}
            else
                InvalidMove();
            remove();
            Console.WriteLine("    0 1 2 3 4 5 6 7 8 9");
            Console.WriteLine("   ---------------------");

            for (int ii = 0; ii < shirina; ii++)
            {
                Console.Write(ii + " | ");

                for (int jj = 0; jj < length; jj++)
                {
                    Console.Write(_t[ii, jj] + " ");
                }
                Console.Write("| ");
                Console.WriteLine();
            }

            Console.WriteLine("   ---------------------");
        }

		private static void clear(int i, int j, string activeCell)
		{
			if ((i >= 0) && (i <= 4) && (j <= 9) && (j >= 0) && (_t[i, j] == activeCell))
			{
				_t[i, j] = ".";
				clearedCells++;
				//Up
				clear(i-1, j, activeCell);
				//Down
				clear(i + 1, j, activeCell);
				//Left
				clear(i, j + 1, activeCell);
				//Right
				clear(i, j - 1, activeCell);
			}
			else
			{
				ost -= clearedCells;
				clearedCells = 0;
				return; 
			}
		}

		private static void remove()
		{
			int i; 
			int j;
			Queue<string> temp = new Queue<string>();
			for (j = length-1; j >= 0; j--)
			{
				for (i = shirina-1; i >= 0; i--)
				{
					if (_t[i, j] != ".")
					{
						temp.Enqueue(_t[i, j]);
						_t[i, j] = ".";
					}
				}
				i = 4;
				while (temp.Count > 0)
				{
					_t[i, j] = temp.Dequeue();
					i--;
				}
				temp.Clear();
			}
		}
		private static bool IsFinished() 
		{
			return (ost == 0);
		}
	}

    public static class RND
    {

        static Random r = new Random();
        public static string GetRandomInt()
        {
            string legalChars = "1234";
            string builder = null;
            builder = legalChars[r.Next(0, legalChars.Length)].ToString();
            return builder;
        }
    }

    class StartBaloons
	{
		
		static void Main(string[] args)
		{
			Baloons.Start();
		}
	}
}
