using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MinesweeperProject
{
    class ConsoleMinesweeperGame : MinesweeperGame
    {
        public ConsoleMinesweeperGame(int rows, int columns, int minesCount)
            : base(rows, columns, minesCount)
        {
        }

        public override void Start()
        {
            base.Start();
            string startMessage = "Welcome to the game “Minesweeper”. Try to reveal all cells without mines. Use 'top' to view the scoreboard, 'restart' to start a new game and 'exit' to quit the game.";
            Console.WriteLine(startMessage);
            Console.WriteLine(Grid.ToString());
            NextCommand();
        }

        public void NextCommand()//console -  output grid and message to request command
        {
            
            Console.Write("Enter row and column:");
            
            string commandLine = Console.ReadLine().ToUpper().Trim();

            List<string> commandList = commandLine.Split(' ').ToList();
            
            if (commandList.Count == 0)//if command list is empty
            {
                NextCommand();
            }

            try
            {
                string firstCommand = commandList.ElementAt(0);
                switch (firstCommand)
                {
                    case "RESTART": Start(); break;
                    case "TOP":
                        {
                            PrintScoreBoard();
                            NextCommand();
                        }; break;
                    case "EXIT": Exit(); break;
                    //case "EXPLOREMINES":
                    //    {
                    //        Grid.RevealMines();
                    //        Console.WriteLine(Grid.ToString());
                    //        NextCommand();
                    //    }; break;
                    default:
                        {
                            int row = 0;
                            int column = 0;
                            bool tryParse = false;

                            if (commandList.Count < 2)
                                throw new CommandUnknownException();

                            tryParse = (Int32.TryParse(commandList.ElementAt(0), out row) || tryParse);
                            tryParse = (Int32.TryParse(commandList.ElementAt(1), out column) || tryParse);

                            if (!tryParse)
                                throw new CommandUnknownException();


                            if (Grid.RevealCell(row, column) == '*')
                            {
                                Grid.mark('-');
                                Grid.RevealMines();
                                Console.WriteLine(Grid.ToString());
                                Console.WriteLine(String.Format("Booooom! You were killed by a mine. You revealed {0} cells without mines.", Score));
                                Console.Write("Please enter your name for the top scoreboard: ");
                                string playerName = Console.ReadLine();
                                ScoreBoard.Add(new ScoreRecord(playerName, Score));
                                Console.WriteLine();
                                PrintScoreBoard();
                                Start();
                            }
                            else
                            {
                                Console.WriteLine(Grid.ToString());
                                Score++;
                                NextCommand();
                            }

                        }; break;
                }
            }
            catch (InvalidCellException)
            {
                Console.WriteLine("Illegal move!");
                NextCommand();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                NextCommand();
            }
        }

        public void Exit()
        {
            Console.WriteLine("Good bye!");
        }

        public void PrintScoreBoard()
        {
            StringBuilder sb = new StringBuilder();    
            sb.AppendLine("Scoreboard:");
            ScoreBoard.Sort();
            int i=0;
            foreach (ScoreRecord sr in ScoreBoard)
            {
                i++;
                sb.AppendFormat("{0}. {1} --> {2} cells \n", i, sr.PlayerName, sr.Score);
            }
            Console.WriteLine(sb.ToString());
        }

    }
}
