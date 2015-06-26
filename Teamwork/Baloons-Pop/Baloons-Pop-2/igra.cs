using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

//niamam obfuskator i zatova sym cepil na ryka, kojto mu se padne, da ne me tyrsi, zaminavam v cuzbina v kurmandirovka
namespace BalloonsPops
{
	public class igra
	{
		const int shirina = 5;
		const int length = 10;

		private static int ost = shirina * length;
		private static int userMoves = 0;
		private static int clearedCells = 0;



		public static string[,] _t = new string[shirina, length];
		public static StringBuilder userInput = new StringBuilder();
		private static SortedDictionary<int, string> statistics = new SortedDictionary<int, string>();

		public static void Start()
		{
			Console.WriteLine("Welcome to “Balloons Pops” game. Please try to pop the balloons. Use 'top' to view the top scoreboard, 'restart' to start a new game and 'exit' to quit the game.");
			ost = shirina * length;
			userMoves = 0;


			clearedCells = 0;
			CreateTable();
			PrintTable();
			GameLogic(userInput);
		}

		public static void CreateTable()
		{
			for (int i = 0; i < shirina; i++)
			{
				for (int j = 0; j < length; j++)
				{
					_t[i, j] = RandomGenerator.GetRandomInt();
				}
			}
		}
		public static void PrintTable()
		{
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
		}
		public static void GameLogic(StringBuilder userInput)
		{
				PlayGame();
				userMoves++;
				userInput.Clear();
				GameLogic(userInput);
			

		}
		private static bool IsLegalMove(int i, int j)
		{
			if ((i < 0) || (j < 0) || (j > length - 1) || (i > shirina - 1)) return false;
			else return (_t[i, j] != ".");
		}

		private static void InvalidInput()
		{
			Console.WriteLine("Invalid move or command");
			userInput.Clear(); 
			GameLogic(userInput); 
		}

		private static void InvalidMove()
		{
			Console.WriteLine("Illegal move: cannot pop missing ballon!");
			userInput.Clear();
			GameLogic(userInput);


		}

		private static void ShowStatistics()
		{
			PrintTheScoreBoard();
		}

		private static void Exit()
		{
			Console.WriteLine("Good Bye");
			Thread.Sleep(1000);
			Console.WriteLine(userMoves.ToString());
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
				userInput.Append(Console.ReadLine());
			}
			else
			{
				Console.Write("opal;aaaaaaaa! You popped all baloons in "+ userMoves +" moves."
								 +"Please enter your name for the top scoreboard:");
				userInput.Append(Console.ReadLine());
				statistics.Add(userMoves, userInput.ToString());
				PrintTheScoreBoard();
				userInput.Clear();
				Start();
			}
		}

		private static void PrintTheScoreBoard()
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

			Play : ReadTheIput();

			string hop = userInput.ToString();

			if (userInput.ToString() == "") InvalidInput();
			if (userInput.ToString() == "top") { ShowStatistics(); userInput.Clear(); goto Play; }
			if (userInput.ToString() == "restart") { userInput.Clear(); Restart(); }
			if (userInput.ToString() == "exit") Exit();

			string activeCell;
			userInput.Replace(" ", "");
			try
			{
				i = Int32.Parse(userInput.ToString()) / 10;
				j = Int32.Parse(userInput.ToString()) % 10;
			}
			catch(Exception) 
			{
				InvalidInput();
			}
			if (IsLegalMove(i, j))
			{
				activeCell = _t[i, j];
				RemoveAllBaloons(i, j, activeCell);
			}
			else InvalidMove();	ClearEmptyCells();	PrintTable();
		}
		private static void RemoveAllBaloons(int i, int j, string activeCell)
		{
			if ((i >= 0) && (i <= 4) && (j <= 9) && (j >= 0) && (_t[i, j] == activeCell))
			{
				_t[i, j] = ".";
				clearedCells++;
				//Up
				RemoveAllBaloons(i-1, j, activeCell);
				//Down
				RemoveAllBaloons(i + 1, j, activeCell);
				//Left
				RemoveAllBaloons(i, j + 1, activeCell);
				//Right
				RemoveAllBaloons(i, j - 1, activeCell);
			}
			else
			{
				ost -= clearedCells;
				clearedCells = 0;
				return; 
			}
		}

		private static void ClearEmptyCells()
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
}