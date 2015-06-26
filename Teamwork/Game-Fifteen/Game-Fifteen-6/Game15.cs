using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wintellect.PowerCollections;

namespace Game15
{
    class Game15
    {
        static int[,] pole = new int[4, 4];
        static OrderedMultiDictionary<int, string> najDobrite = new OrderedMultiDictionary<int, string>(true);
        static Dictionary<int, koordinati> numberPositions = new Dictionary<int, koordinati>();

        static void Main()
        {
            Nachalo();
            Zapochni();
        }

        private static void Nachalo()
        {
            do
            {
                IskamProizvolnaDyska();
            } while (proverkaGameFieldIsSolved());
            Console.WriteLine("Welcome to the game “15”. Please try to arrange the numbers sequentially." +
                "Use 'top' to view the top scoreboard, 'restart' to start a new game and 'exit' to quit the game.");
        }

        private static void IskamProizvolnaDyska()
        {
            List<int> numbers = new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };
            numberPositions.Clear();
            Random rand = new Random();
            for (int i = 0; i < pole.GetLength(0); i++)
            {
                for (int j = 0; j < pole.GetLength(1); j++)
                {
                    int position = rand.Next(0, numbers.Count);
                    pole[i, j] = numbers[position];
                    numberPositions.Add(numbers[position], new koordinati(i, j));
                    numbers.RemoveAt(position);
                }
            }
        }

        private static void Zapochni()
        {
            PrintGameField();
            Console.Write("Enter a number to move: ");
            string input = Console.ReadLine();
            bool gameIsFinished = false;
            int moves = 0;
            while (input!="exit")
            {
                moves++;
                switch (input)
                {
                    case "top":
                        PrintBestOfTheBest();
                        break;
                    case "restart":
                        Nachalo();
                        break;
                    default:
                        int numberToMove;
                        if (int.TryParse(input, out numberToMove))
                        {
                            if (0 < numberToMove && numberToMove < 16)
                            {
                                TryToMoveNumber(numberToMove);
                            }
                            else
                            {
                                Console.WriteLine("Illegal command!");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Illegal command!");
                        }
                        break;
                }
                PrintGameField();
                gameIsFinished = proverkaGameFieldIsSolved();
                if (gameIsFinished)
                {
                    AddToScoreBoard(moves);
                    moves = 0;
                    Nachalo();
                }
                Console.Write("Enter a number to move: ");
                input = Console.ReadLine();
            }
        }

        private static void TryToMoveNumber(int numberToMove)
        {
            if (numberPositions[0].ProverkaNeighbout(numberPositions[numberToMove]))
            {
                koordinati temp = numberPositions[0];
                numberPositions[0] = numberPositions[numberToMove];
                numberPositions[numberToMove] = temp;
                pole[numberPositions[numberToMove].Row, numberPositions[numberToMove].Col] = numberToMove;
                pole[numberPositions[0].Row, numberPositions[0].Col] = 0;
            }
            else
            {
                Console.WriteLine("Illegal command!");
            }
        }

        private static void AddToScoreBoard(int moves)
        {
            Console.WriteLine("Congratulations! You won the game in {0} moves.", moves);
            Console.Write("Please enter your name for the top scoreboard: ");
            string name = Console.ReadLine();
            najDobrite.Add(moves, name);
        }

        private static bool proverkaGameFieldIsSolved()
        {
            int[,] matrica =
            {
                {1,2,3,4},
                {5,6,7,8},
                {9,10,11,12},
                {13,14,15,0}
            };
            bool a = true;
            for (int i = 0; i < pole.GetLength(0); i++)
            {
                for (int j = 0; j < pole.GetLength(1); j++)
                {
                    if (pole[i,j]!=matrica[i,j])
                    {
                        a = false;
                        break;
                    }
                }
            }
            return a;
        }

        private static void PrintBestOfTheBest()
        {
            if (najDobrite.Count==0)
            {
                Console.WriteLine("Scoreboard is empty.");
            }
            int counter = 1;
            foreach (var item in najDobrite)
            {
                Console.WriteLine("{0}. {1} --> {2} moves", counter, item.Value, item.Key);
                counter++;
            }
        }

        private static void PrintGameField()
        {
            Console.WriteLine(" -------------------");
            for (int i = 0; i < pole.GetLength(0); i++)
            {
                Console.Write("|");
                for (int j = 0; j < pole.GetLength(1); j++)
                {
                    if (pole[i,j]==0)
                    {
                        Console.Write("    |");
                        continue;
                    }
                    Console.Write(" {0,2} |",pole[i,j]);
                }
                Console.WriteLine();
            }
            Console.WriteLine(" -------------------");
        }
    }
}
