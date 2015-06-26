using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// testvano e - ba4ka, ne pipaj!!!!!!!

namespace mini4ki
{
    public class MinesweeperMain
    {
        public class ScoreRecord
        {
            string personName;
            int scorePoints;

            public string PersonName
            {
                get { return personName; }
                set { personName = value; }
            }
            public int ScorePoints
            {
                get { return scorePoints; 
				
				
				}
                set { scorePoints = value; }
            }

            public ScoreRecord() { }

            public ScoreRecord(string personName, int points)
            {
                this.personName = personName;
                this.scorePoints = points;
            }

        }

        static void Main(string[] args)
        {
            string selectedCommand = string.Empty;
            char[,] playground = CreateWhiteBoard();
            char[,] boomBoard = CreateBombBoard();
            int counter = 0;
            bool boomed = false;


            List<ScoreRecord> champions = new List<ScoreRecord>(6);
            int rowIndex = 0;



            int columnIndex = 0;
            bool welcomeFlag = true;
            const int MAX_REVEALED_CELLS = 35;
            bool flag = false;
            
            do
            {
                if (welcomeFlag)
                {
                    Console.WriteLine("Welcome to the game “Minesweeper”. Try to reveal all cells without mines." +
                    " Use 'top' to view the scoreboard, 'restart' to start a new game and 'exit' to quit the game.");
                    PrintBoard(playground);
                    welcomeFlag = false;
                }
                Console.Write("Enter row and column: ");
                selectedCommand = Console.ReadLine().Trim();
                if (selectedCommand.Length >= 3)
                {
                    if (int.TryParse(selectedCommand[0].ToString(), out rowIndex) &&
                    int.TryParse(selectedCommand[2].ToString(), out columnIndex) &&
                        rowIndex <= playground.GetLength(0) && columnIndex <= playground.GetLength(1))
                    {


                        selectedCommand = "turn";
                    }
                }
                switch (selectedCommand)
                {
                    case "top":
                        PrintScoreBoard(champions);
                        break;
                    case "restart":
                        playground = CreateWhiteBoard();
                        boomBoard = CreateBombBoard();
                        PrintBoard(playground);
                        boomed = false;
                        welcomeFlag = false;
                        break;
                    case "exit":
                        Console.WriteLine("Good bye!");
                        break;
                    case "turn":
                        if (boomBoard[rowIndex, columnIndex] != '*')
                        {
                            if (boomBoard[rowIndex, columnIndex] == '-')
                            {
                                MakeAMove(playground, boomBoard, rowIndex, columnIndex);
                                counter++;
                            }
                            if (MAX_REVEALED_CELLS == counter)
                            {
                                flag = true;
                            }
                            else
                            {
                                PrintBoard(playground);
                            }
                        }
                        else
                        {
                            boomed = true;


                        }
                        break;
                    default:
                        Console.WriteLine("\nIllegal move!\n");
                        break;
                }
                if (boomed)
                {
                    PrintBoard(boomBoard);
                    Console.Write("\nBooooom! You were killed by a mine. You revealed {0} cells without mines."+
                        "Please enter your name for the top scoreboard: ",counter);
                    string personName = Console.ReadLine();
                    ScoreRecord record = new ScoreRecord(personName, counter);
                    if (champions.Count <5)
                    {
                        champions.Add(record);


                    }
                    else
                    {
                        for (int i = 0; i < champions.Count; i++)
                        {
                            if (champions[i].ScorePoints < record.ScorePoints)
                            {
                                champions.Insert(i, record);
                                champions.RemoveAt(champions.Count-1);
                                break;
                            }
                        }
                    }
                    champions.Sort(delegate(ScoreRecord r1, ScoreRecord r2)
                    { return r2.PersonName.CompareTo(r1.PersonName); });
                    champions.Sort(delegate(ScoreRecord r1,ScoreRecord r2)
                    {return r2.ScorePoints.CompareTo(r1.ScorePoints);  });
                    PrintScoreBoard(champions);
                    
					
					playground = CreateWhiteBoard();
                    boomBoard = CreateBombBoard();
                    counter = 0;
                    boomed = false;
                    welcomeFlag = true;
                }
                if (flag)
                {
                    Console.WriteLine("\nYou revealed all 35 cells.");
                    PrintBoard(boomBoard);
                    Console.WriteLine("Please enter your name for the top scoreboard: ");
                    string personName = Console.ReadLine();
                    ScoreRecord record = new ScoreRecord(personName, counter);
                    champions.Add(record);
                    PrintScoreBoard(champions);
                    playground = CreateWhiteBoard();
                    boomBoard = CreateBombBoard();
                    counter = 0;
                    flag = false;
                    welcomeFlag = true;
                }
            } 
            while (selectedCommand != "exit");


            Console.WriteLine("Made by Pavlin Panev 2010 - all rights reserved!");
            Console.WriteLine("Press any key to exit.");
            Console.Read();
        }
        private static void PrintScoreBoard(List<ScoreRecord> topRecords)
        {
            Console.WriteLine("\nScoreboard:");
            if (topRecords.Count > 0)
            {
                for (int i = 0; i < topRecords.Count; i++)
                {
                    Console.WriteLine("{0}. {1} --> {2} cells", i + 1, topRecords[i].PersonName, topRecords[i].ScorePoints);
                }
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("No records to display!\n");
            }
        }
        private static void MakeAMove(char[,] board,char[,] boomBoard, int rowIndex, int columnIndex)
        {
            char howManyBombs = CalculateHowManyBombs(boomBoard, rowIndex, columnIndex);
            boomBoard[rowIndex, columnIndex] = howManyBombs;
            board[rowIndex, columnIndex] = howManyBombs;
        }
        private static void PrintBoard(char[,] board)
        {
            int boardRows = board.GetLength(0);
            int boardColumns = board.GetLength(1);
            Console.WriteLine("\n    0 1 2 3 4 5 6 7 8 9");
            Console.WriteLine("   ---------------------");
            for (int i = 0; i < boardRows; i++)
            {
                Console.Write("{0} | ", i);
                for (int j = 0; j < boardColumns; j++)
                {
                    Console.Write(string.Format("{0} ",board[i, j]));
                }
                Console.Write("|");
                Console.WriteLine();
            }
            Console.WriteLine("   ---------------------\n");
        }
        private static char[,] CreateWhiteBoard()
        {
            int boardRows = 5;
            int boardColumns = 10;
            char[,] board = new char[boardRows, boardColumns];
            for (int i = 0; i < boardRows; i++)
            {
                for (int j = 0; j < boardColumns; j++)
                {
                    board[i,j] = '?';
                }
            }

            return board;



        }

        private static char[,] CreateBombBoard()
        {
            int boardRows = 5;
            int boardColumns = 10;
            char[,] board = new char[boardRows, boardColumns];

            for (int i = 0; i < boardRows; i++)
            {
                for (int j = 0; j < boardColumns; j++)
                {
                    board[i, j] = '-';



                }
            }

            List<int> randomNumbers = new List<int>();
            while (randomNumbers.Count < 15)
            {
                Random random = new Random();
                int randomNumber = random.Next(50);
                if (!randomNumbers.Contains(randomNumber))
                {
                    randomNumbers.Add(randomNumber);
                }
            }

            foreach (int number in randomNumbers)
            {
                int row = (number / boardColumns);
                int column = (number % boardColumns);
                if (column == 0 && number != 0)
                {
                    row--;
                    column = boardColumns;
                }


                else
                {
                    column++;
                }
                board[row,column-1] = '*';
            }

            return board;
        }

        private static void CalculateBombBoard(char[,] board)
        {
            int boardRows = board.GetLength(0);
            int boardColumns = board.GetLength(1);

            for (int i = 0; i < boardRows; i++)
            {
                for (int j = 0; j < boardColumns; j++)
                {
                    if (board[i,j] != '*')
                    {
                        char number = CalculateHowManyBombs(board, i, j);
                        board[i, j] = number;
                    }
                }


            }
        }

        private static char CalculateHowManyBombs(char[,] board, int rowIndex, int columnIndex)
        {
            int counted = 0;
            int boardRows = board.GetLength(0);
            int boardColumns = board.GetLength(1);

            if (rowIndex - 1 >= 0)
            {
                if (board[rowIndex - 1, columnIndex] == '*')
                { counted++; }
            }
            if (rowIndex + 1 < boardRows)
            {
                if (board[rowIndex + 1, columnIndex] == '*')
                { counted++; }



            }
            if (columnIndex - 1 >= 0)
            {
                if (board[rowIndex, columnIndex - 1] == '*')
                { counted++; }
            }
            if (columnIndex + 1 < boardColumns)
            {
                if (board[rowIndex, columnIndex + 1] == '*')
                { counted++; }
            }
            if ((rowIndex - 1 >= 0) && (columnIndex - 1 >= 0))
            {
                if (board[rowIndex - 1, columnIndex - 1] == '*')
                { counted++; }
            }
            if ((rowIndex - 1 >= 0) && (columnIndex + 1 < boardColumns))
            {
                if (board[rowIndex - 1, columnIndex + 1] == '*')
                { counted++; }
            }
            if ((rowIndex + 1 < boardRows) && (columnIndex - 1 >= 0))
            {
                if (board[rowIndex + 1, columnIndex - 1] == '*')
                { counted++; }
            }
            if ((rowIndex + 1 < boardRows) && (columnIndex + 1 < boardColumns))
            {
                if (board[rowIndex + 1, columnIndex + 1] == '*')
                { counted++; }


            }
            return char.Parse(counted.ToString());
        }

    }
}
