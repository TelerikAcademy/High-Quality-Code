using System;
using System.Collections.Generic;


// bachka!! yesss

namespace Labyrinth
{

    class Program : Game
    {
        static void Main(string[] args)
        {



            positionX = positionY = 3;  // player position
            flag2 = flag3 = true;
            string[,] labyrinth = new string[7, 7];

            while (flag3)
            {
                Console.WriteLine("Welcome to \"Labyrinth\" game. Please try to escape. Use 'top' to view the top \nscoreboard,'restart' to start a new game and 'exit' to quit the game.\n ");

                flag = flag4 = false;

                while (flag == false)
                {
                    LabyrinthGenerator(labyrinth, positionX, positionY);
                    SolutionChecker(labyrinth, positionX, positionY);
                }
                DisplayLabyrinth(labyrinth);
                Test(labyrinth, flag2, positionX, positionY);
                while (flag4) //used for adding score only when game is finished naturally and not by the restart command.
                {
                    Add(scores, currentMoves);

                }
            }
        }
        static void Add(List<Table> s, int m)
        {
            if (s.Count != 0)
            {
                s.Sort(delegate(Table s1, Table s2) { return s1.moves.CompareTo(s2.moves); });
            }


            if (s.Count == 5)
            {

                if (s[4].moves > m)
                {

                    s.Remove(s[4]);
                    Console.WriteLine("Please enter your nickname");
                    string name = Console.ReadLine();
                    s.Add(new Table(m, name));
                    Table_(s);

                }

            }
            if (s.Count < 5)
            {
                Console.WriteLine("Please enter your nickname");
                string name = Console.ReadLine();
                s.Add(new Table(m, name));
                Table_(s);
            }


            flag4 = false;

        }

        static void Table_(List<Table> scores)
        {
            Console.WriteLine("\n");
            if (scores.Count == 0) { Console.WriteLine("The scoreboard is empty! "); }
            else
            {
                int i = 1;
                scores.Sort(delegate(Table s1, Table s2) { return s1.moves.CompareTo(s2.moves); });
                Console.WriteLine("Top 5: \n");
                scores.ForEach(delegate(Table s)
                {



                    Console.WriteLine(String.Format(i+". {1} ---> {0} moves", s.moves, s.name));
                    i++;   
                }
                );
                Console.WriteLine("\n");
            }

        }

        static void Test(string[,] labyrinth, bool flag_temp, int x, int y)
        {

            currentMoves = 0;

            while (flag_temp)
            {


                Console.Write("\nEnter your move (L=left, R=right, D=down, U=up): ");
                string i = string.Empty;
                i = Console.ReadLine();



                switch (i)
                {
                    case "d":


                        if (labyrinth[x + 1, y] == "-")
                        {
                            labyrinth[x, y] = "-";
                            labyrinth[x + 1, y] = "*";
                            x++;
                            currentMoves++;
                        }
                        else
                        {
                            Console.WriteLine("\nInvalid move! \n ");

                        }

                        if (x == 6)
                        {


                            Console.WriteLine("\nCongratulations you escaped with {0} moves.\n", currentMoves);
                            flag_temp = false;

                            flag4 = true;
                        }

                        DisplayLabyrinth(labyrinth);




                        break;

                    case "D":
                        if (labyrinth[x + 1, y] == "-")
                        {
                            labyrinth[x, y] = "-";
                            labyrinth[x + 1, y] = "*";
                            x++;
                            currentMoves++;
                        }
                        else
                        {
                            Console.WriteLine("\nInvalid move! \n ");

                        }

                        if (x == 6)
                        {
                            Console.WriteLine("\nCongratulations you escaped with {0} moves.\n", currentMoves);
                            flag_temp = false;
                            flag4 = true;
                        }

                        DisplayLabyrinth(labyrinth);

                        break;




                    case "u":
                        if (labyrinth[x - 1, y] == "-")
                        {
                            labyrinth[x, y] = "-";
                            labyrinth[x - 1, y] = "*";
                            x--;
                            currentMoves++;
                        }
                        else
                        {
                            Console.WriteLine("\nInvalid move! \n ");

                        }

                        if (x == 0)
                        {
                            Console.WriteLine("\nCongratulations you escaped with {0} moves.\n", currentMoves);
                            flag_temp = false;
                            flag4 = true;
                        }

                        DisplayLabyrinth(labyrinth);


                        break;
                    case "U":
                        if (labyrinth[x - 1, y] == "-")
                        {
                            labyrinth[x, y] = "-";
                            labyrinth[x - 1, y] = "*";
                            x--;
                            currentMoves++;
                        }
                        else
                        {
                            Console.WriteLine("\nInvalid move! \n ");

                        }

                        if (x == 0)
                        {
                            Console.WriteLine("\nCongratulations you escaped with {0} moves.\n", currentMoves);
                            flag_temp = false;
                            flag4 = true;
                        }

                        DisplayLabyrinth(labyrinth);


                        break;
                    case "r":

                        if (labyrinth[x, y + 1] == "-")
                        {
                            labyrinth[x, y] = "-";
                            labyrinth[x, y + 1] = "*";
                            y++;
                            currentMoves++;
                        }
                        else
                        {
                            Console.WriteLine("\nInvalid move! \n ");

                        }

                        if (y == 6)
                        {
                            Console.WriteLine("\nCongratulations you escaped with {0} moves.\n", currentMoves);
                            flag_temp = false;
                            flag4 = true;
                        }

                        DisplayLabyrinth(labyrinth);

                        break;
                    case "R":

                        if (labyrinth[x, y + 1] == "-")
                        {
                            labyrinth[x, y] = "-";
                            labyrinth[x, y + 1] = "*";
                            y++;
                            currentMoves++;
                        }
                        else
                        {
                            Console.WriteLine("\nInvalid move! \n ");

                        }

                        if (y == 6)
                        {
                            Console.WriteLine("\nCongratulations you escaped with {0} moves.\n", currentMoves);
                            flag_temp = false;
                            flag4 = true;
                        }

                        DisplayLabyrinth(labyrinth);

                        break;
                    case "l":

                        if (labyrinth[x, y - 1] == "-")
                        {
                            labyrinth[x, y] = "-";
                            labyrinth[x, y - 1] = "*";
                            y--;
                            currentMoves++;
                        }
                        else
                        {
                            Console.WriteLine("\nInvalid move! \n ");

                        }

                        if (y == 0)
                        {
                            Console.WriteLine("\nCongratulations you escaped with {0} moves.\n", currentMoves);
                            flag_temp = false;
                            flag4 = true;
                        }

                        DisplayLabyrinth(labyrinth);

                        break;
                    case "L":

                        if (labyrinth[x, y - 1] == "-")
                        {
                            labyrinth[x, y] = "-";
                            labyrinth[x, y - 1] = "*";
                            y--;
                            currentMoves++;
                        }
                        else
                        {
                            Console.WriteLine("\nInvalid move! \n ");

                        }

                        if (y == 0)
                        {
                            Console.WriteLine("\nCongratulations you escaped with {0} moves.\n", currentMoves);
                            flag_temp = false;
                            flag4 = true;
                        }

                        DisplayLabyrinth(labyrinth);


                        break;
                    case "top":

                        Table_(scores);
                        Console.WriteLine("\n");
                        DisplayLabyrinth(labyrinth);

                        break;
                    case "restart":
                        flag_temp = false;

                        break;
                    case "exit":
                        Console.WriteLine("Good bye!");
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid command!");
                        break;

                }

            }
        }

    }

}


