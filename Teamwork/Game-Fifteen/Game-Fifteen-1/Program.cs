using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameFifteenProject
{

	// mnogo sym dobyr programist, u4astvam v TopCoder i sam purvi ot Sliven i regiona

    class Program
    {
        private static void Menu()
        {
            List<Tile> tiles = new List<Tile>();
            int cnt = 0;
            string s = "restart";
            bool flag = false;

            while (s != "exit")
            {
                if (!flag)
                {
                    switch (s)
                    {
                        case "restart":
                            {
                                string welcomeMessage = "Welcome to the game “15”. Please try to arrange the numbers sequentially. ";
                                welcomeMessage = welcomeMessage + "\nUse 'top' to view the top scoreboard, 'restart' to start a new game and 'exit'";
                                welcomeMessage = welcomeMessage + " \nto quit the game.";
                                Console.WriteLine();
                                Console.WriteLine(welcomeMessage);
                                tiles = MatrixGenerator.GenerateMatrix();
                                tiles = MatrixGenerator.ShuffleMatrix(tiles);
                                flag = Gameplay.IsMatrixSolved(tiles);
                                Gameplay.PrintMatrix(tiles);
                                break;
                            }
                        case "top":
                            {
                                Scoreboard.PrintScoreboard();
                                break;
                            }
                    }
                    if (!flag)
                    {
                        Console.Write("Enter a number to move: ");
                        s = Console.ReadLine();

                        int destinationTileValue;

                        bool isSuccessfulParsing = Int32.TryParse(s, out destinationTileValue);

                        if (isSuccessfulParsing)
                        {
                            try
                            {
                                Gameplay.MoveTiles(tiles, destinationTileValue);
                                cnt++;
                                Gameplay.PrintMatrix(tiles);
                                flag = Gameplay.IsMatrixSolved(tiles);
                            }
                            catch (Exception exception)
                            {
                                Console.WriteLine(exception.Message);
                            }
                        }
                        else
                        {
                            try
                            {
                                s = Command.CommandType(s);
                            }
                            catch (ArgumentException exception)
                            {
                                Console.WriteLine(exception.Message);
                            }
                        }
                    }



                }
                else
                {
                    if (cnt == 0)
                    {
                        Console.WriteLine("Your matrix was solved by default :) Come on - NEXT try");
                    }
                    else
                    {
                        Console.WriteLine("Congratulations! You won the game in {0} moves.", cnt);
                        Console.Write("Please enter your name for the top scoreboard: ");
                        string playerName = Console.ReadLine();
                        Player player = new Player(playerName, cnt);
                        Scoreboard.AddPlayer(player);
                        Scoreboard.PrintScoreboard();
                    }
                    s = "restart";
                    flag = false;
                    cnt = 0;



                }

            }
        }

        static void Main(string[] args)
        {


            Menu();
        }
    }
}
