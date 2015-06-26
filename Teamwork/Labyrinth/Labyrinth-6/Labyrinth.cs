using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EscapeFromLabyrinth
{
    public class Labyrinth
    {
        private int[,] ll = new int[7, 7];
        private string enterMove = "Enter your move (L=left, R=right, U=up, D=down):";
        private string welcome = "Welcome to “Labirinth” game. Please try to escape. Use 'top' to view the top scoreboard, 'restart' to start a new game and 'exit' to quit the game.";
        private int i = 0, j = 0, m = 3, n = 3;



        private bool _continue = true;
        private string[] topScores = new string[5];

        public void InitializeLabyrinth()
        {
            Random random = new Random();
            for (i = 0; i < 7; i++)
            {
                for (j = 0; j < 7; j++)
                {
                    ll[i, j] = random.Next(2);
                }
            }
            ll[3, 3] = 2;
        }//end InitializeLabyrinth method

        public void ShowLabyrinth()
        {
            for (i = 0; i < 7; i++)
            {
                for (j = 0; j < 7; j++)
                {
                    if (ll[i, j] == 0)
                    {


                        Console.Write("- ");
                    }
                    else if (ll[i, j] == 2)
                    {
                        Console.Write("* ");
                    }
                    else
                    {
                        Console.Write("X ");
                    }
                }
                Console.WriteLine();
            }
        }//end ShowLabyrinth method

        public void ShowTopScores()
        {
            for (int i = 0; i < topScores.Length; i++)
            {
                if (topScores[i] != null)
                {
                    Console.WriteLine(i + 1 + " - " + topScores[i]);
                }
            }

            if (topScores[0] == null && topScores[1] == null && topScores[2] == null && topScores[3] == null && topScores[4] == null)
            {



                Console.WriteLine("The scoreboard is empty.");
            }
        }//end ShowTopScores method
        public void Move()
        {
            int steps = 0;

            while (_continue == true)
            {
                Console.Write(enterMove);
                string input = Console.ReadLine();

                if (input.Length > 1 || input.Length == 0)
                {
                    switch (input)
                    {
                        case "exit":
                            Console.WriteLine("Good Bye!");
                            _continue = false;
                            break;
                        case "restart":
                            InitializeLabyrinth();
                            ShowLabyrinth();
                            _continue = true;
                            m = 3;
                            n = 3;
                            Move();
                            break;
                        case "top":
                            ShowTopScores();
                            _continue = true;
                            break;
                        default:
                            Console.WriteLine("Invalid command");
                            _continue = true;
                            break;
                    }//end switch
                }//end if
                else
                {

                    switch (input)
                    {
                        case "L":
                            if (ll[m, n - 1] == 0)
                            {
                                ll[m, n - 1] = 2;
                                ll[m, n] = 0;
                                n -= 1;
                                steps++;
                                if (n - 1 < 0)
                                {
                                    Console.WriteLine("Congratulations! You escaped in {0} moves.", steps);
                                    InitializeLabyrinth();
                                    Console.WriteLine("\n" + welcome);
                                    Console.WriteLine(enterMove);
                                    ShowLabyrinth();
                                    m = 3;
                                    n = 3;
                                    Move();
                                }
                                else
                                {
                                    ShowLabyrinth();
                                }
                            }
                            else
                            {
                                Console.WriteLine("Invalid move!");
                            }
                            break;
                        case "R":
                            if (ll[m, n + 1] == 0)
                            {
                                ll[m, n + 1] = 2;
                                ll[m, n] = 0;
                                n += 1;
                                steps++;
                                if (n + 1 > 6)
                                {
                                    Console.WriteLine("Congratulations! You escaped in {0} moves.", steps);
                                    InitializeLabyrinth();



                                    Console.WriteLine("\n" + welcome);
                                    Console.WriteLine(enterMove);
                                    ShowLabyrinth();
                                    m = 3;
                                    n = 3;
                                    Move();
                                }
                                else
                                {
                                    ShowLabyrinth();
                                }
                            }
                            else
                            {
                                Console.WriteLine("Invalid move!");
                            }
                            break;
                        case "U":
                            if (ll[m - 1, n] == 0)
                            {
                                ll[m - 1, n] = 2;
                                ll[m, n] = 0;
                                m -= 1;



                                steps++;
                                if (m - 1 < 0)
                                {
                                    Console.WriteLine("Congratulations! You escaped in {0} moves.", steps);
                                    InitializeLabyrinth();
                                    Console.WriteLine("\n" + welcome);
                                    Console.WriteLine(enterMove);
                                    ShowLabyrinth();
                                    m = 3;
                                    n = 3;
                                    Move();
                                }
                                else
                                {
                                    ShowLabyrinth();
                                }
                            }
                            else
                            {
                                Console.WriteLine("Invalid move!");
                            }
                            break;
                        case "D":
                            if (ll[m + 1, n] == 0)
                            {
                                ll[m + 1, n] = 2;
                                ll[m, n] = 0;
                                m += 1;
                                steps++;
                                if (m + 1 > 6)
                                {
                                    Console.WriteLine("Congratulations! You escaped in {0} moves.", steps);
                                    InitializeLabyrinth();
                                    Console.WriteLine("\n" + welcome);
                                    Console.WriteLine(enterMove);
                                    ShowLabyrinth();
                                    m = 3;
                                    n = 3;
                                    Move();
                                }
                                else
                                {
                                    ShowLabyrinth();
                                }
                            }
                            else
                            {
                                Console.WriteLine("Invalid move!");
                            }
                            break;
                        default:
                            Console.WriteLine("Invalid move");
                            break;
                    }//end switch
                }//end else
            }//end while
        }//end Move method
    }//end class Labyrinth
}


