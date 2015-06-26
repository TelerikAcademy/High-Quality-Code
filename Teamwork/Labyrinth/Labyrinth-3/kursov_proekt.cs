using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;


namespace kursov_proekt
{

	// ej na tova mu se vika kasha. ima vsiakakvi podpravki, moze da dobavite oshte sol i da izhvurlite na bokluka
	// happy hacking!
    class Program
    {
        private static bool mazeHasSolution; // shows if the random generated labyrinth has an exit route.
        private static bool commandListener; //waiting for input.
        private static bool playing; //game in progress.
        private static bool flag; //used to prevent adding scores when restarting the game.

        private static int positionX;  //used for coordinates. rows.
        private static int positionY;  //used for coordinates. columns.

        public static int currentMoves;
        public static List<Scoreboard> scores = new List<Scoreboard>(4);

        static void Main(string[] args)
        {



            positionX = positionY = 3;  // player position
            commandListener = playing = true;
            string[,] labyrinth = new string[7, 7];

            while (playing)
            {
                Console.WriteLine("Welcome to \"Labyrinth\" game. Please try to escape. Use 'top' to view the top \nscoreboard,'restart' to start a new game and 'exit' to quit the game.\n ");

                mazeHasSolution = flag = false;

                while (mazeHasSolution == false)
                {
                    LabyrinthGenerator(labyrinth, positionX, positionY);
                    SolutionChecker(labyrinth, positionX, positionY);
                }
                DisplayLabyrinth(labyrinth);
                TypeCommand(labyrinth, commandListener, positionX, positionY);
                while (flag) //used for adding score only when game is finished naturally and not by the restart command.
                {
                    AddScore(scores, currentMoves);

                }
            }
        }
        static void AddScore(List<Scoreboard> scores, int currentMoves)
        {
            if (scores.Count != 0)
            {
                scores.Sort(delegate(Scoreboard s1, Scoreboard s2) { return s1.moves.CompareTo(s2.moves); });
            }


            if (scores.Count == 5)
            {

                if (scores[4].moves > currentMoves)
                {

                    scores.Remove(scores[4]);
                    Console.WriteLine("Please enter your nickname");
                    string name = Console.ReadLine();
                    scores.Add(new Scoreboard(currentMoves, name));
                    ShowScoreboard(scores);

                }

            }
            if (scores.Count < 5)
            {
                Console.WriteLine("Please enter your nickname");
                string name = Console.ReadLine();
                scores.Add(new Scoreboard(currentMoves, name));
                ShowScoreboard(scores);
            }


            flag = false;

        }

        static void ShowScoreboard(List<Scoreboard> scores)
        {
            Console.WriteLine("\n");
            if (scores.Count == 0) { Console.WriteLine("The scoreboard is empty! "); }
            else
            {
                int i = 1;
                scores.Sort(delegate(Scoreboard s1, Scoreboard s2) { return s1.moves.CompareTo(s2.moves); });
                Console.WriteLine("Top 5: \n");
                scores.ForEach(delegate(Scoreboard s)
                {



                    Console.WriteLine(String.Format(i+". {1} ---> {0} moves", s.moves, s.name));
                    i++;   
                }
                );
                Console.WriteLine("\n");
            }

        }

        static void TypeCommand(string[,] labyrinth, bool flag_temp, int x, int y)
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

                            flag = true;
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
                            flag = true;
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
                            flag = true;
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
                            flag = true;
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
                            flag = true;
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
                            flag = true;
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
                            flag = true;
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
                            flag = true;
                        }

                        DisplayLabyrinth(labyrinth);


                        break;
                    case "top":

                        ShowScoreboard(scores);
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

        static void LabyrinthGenerator(string[,] labyrinth, int x, int y)
        {

            Random randomInt = new Random();

            for (int i = 0; i < 7; i++)
            {


                for (int j = 0; j < 7; j++)
                {
                    labyrinth[i, j] = Convert.ToString(randomInt.Next(2));
                    if (labyrinth[i, j] == "0") { labyrinth[i, j] = "-"; } else { labyrinth[i, j] = "x"; }
                }


            }
            labyrinth[positionX, positionY] = "*";
        }

        static void SolutionChecker(string[,] labyrinth, int x, int y)
        {

            bool checking = true;


            if (labyrinth[x + 1, y] == "x" && labyrinth[x, y + 1] == "x" && labyrinth[x - 1, y] == "x" && labyrinth[x, y - 1] == "x")
            {
                checking = false;

            }

            while (checking)
            {
                try
                {


                    if (labyrinth[x + 1, y] == "-")
                    {
                        labyrinth[x + 1, y] = "0";
                        x++;

                    }
                    else if (labyrinth[x, y + 1] == "-")
                    {
                        labyrinth[x, y + 1] = "0";
                        y++;
                    }
                    else if (labyrinth[x - 1, y] == "-")
                    {
                        labyrinth[x - 1, y] = "0";
                        x--;
                    }
                    else if (labyrinth[x, y - 1] == "-")
                    {
                        labyrinth[x, y - 1] = "0";
                        y--;
                    }
                    else
                    {
                        checking = false;

                    }

                }
                catch (Exception)
                {
                    for (int i = 0; i < 7; i++)
                    {


                        for (int j = 0; j < 7; j++)
                        {

                            if (labyrinth[i, j] == "0") { labyrinth[i, j] = "-"; }
                        }

                        checking = false;
                        mazeHasSolution = true;
                    }

                }
            }
        }

        static void DisplayLabyrinth(string[,] labyrinth)
        {
            for (int i = 0; i < 7; i++)
            {
                string s1 = labyrinth[i, 0];
                string s2 = labyrinth[i, 1];
                string s3 = labyrinth[i, 2];
                string s4 = labyrinth[i, 3];
                string s5 = labyrinth[i, 4];
                string s6 = labyrinth[i, 5];
                string s7 = labyrinth[i, 6];

                Console.WriteLine("{0} {1} {2} {3} {4} {5} {6} ", s1, s2, s3, s4, s5, s6, s7);
            }
            Console.WriteLine();
        }

    }

    public class Scoreboard
    {
        public int moves;
        public string name;

        public Scoreboard(int moves, string name)
        {
            this.moves = moves;
            this.name = name;
        }

    }

}


