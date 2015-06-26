using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BattleFiled
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the size of the battle field: n = ");
            string en = Console.ReadLine();
            int n = int.Parse(en);
            

            //tuka si pravq poleto
            string[,] battleField = new string[n, n];

            Random randomPosition = new Random();

            //celta na tova e da se zapylni matricata default s cherti
            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    
                    battleField[row, col] = "-";
                }
            }

            string[] minesArray = { "1", "2", "3", "4", "5" };

            double fifteenPercentNSquared = 0.15 * n * n; 
            double thirtyPercenNSquared = 0.3 * n * n;

            int fifteenPercent = Convert.ToInt16(fifteenPercentNSquared);
            int thirtyPercent = Convert.ToInt16(thirtyPercenNSquared);

            int numberOfMines = randomPosition.Next(fifteenPercent, thirtyPercent + 1);

            for (int i = 0; i < numberOfMines; i++)
            {
                int newRow = randomPosition.Next(0, n);
                int newCol = randomPosition.Next(0, n);

                if (battleField[newRow, newCol] == "-")
                {
                    battleField[newRow, newCol] = minesArray[randomPosition.Next(0, 5)];
                }
                else
                {
                    numberOfMines--;
                }

            }

            Console.WriteLine("Welcome to \"Battle Field\" game.");
            //tuka pochvame
            Console.WriteLine();
            printirai(battleField);
            Console.WriteLine();
            int moveCounter = 0;
            //this is a cycle from ZERO to ONE-HUNDRED 
            for (int turns = 0; turns < 100; turns++)
            {

                //here we read a string from the console
                Console.Write("Please enter coordinates: ");
                string line = Console.ReadLine();
                string stringRow = "";
                string stringCol = "";
                int row;
                int col;
                bool flagForRow = true;
                bool flagForCol = false;
                int positionWhenIStopped = 0; ;

                for (int i = 0; i < 100; i++)
                    
                    if (flagForRow)
                    
                        if (line[i] != ' '){
                            stringRow += line[i];

                            if (line[i + 1] == ' ')
                            {   positionWhenIStopped = i + 1;



                                flagForRow = false;
                                flagForCol = true;
                                break;}
                        }
                    
                

                for (int i = positionWhenIStopped; i < 100; i++)
                {
                    if (flagForCol)
                    {
                        if (line[i] != ' ')
                        {

                            stringCol = stringCol + line[i];
                            break;

                        }
                    }
                }

                row = int.Parse(stringRow);
                col = int.Parse(stringCol);

                if (battleField[row, col] == "-" || battleField[row, col]=="X")
                {
                    if (turns > 0)
                    {
                        turns -= turns;
                    }
                    else
                    {
                        turns = -1;
                    }

                    Console.WriteLine("Invalid move!");
                }
                //tuka proverqvam dali emina
                if (battleField[row, col] == "1" || battleField[row, col] == "2" || battleField[row, col] == "3" || battleField[row, col] == "4" || battleField[row, col] == "5")
                {
                        battleField = HodNaIgracha(row, col, n, battleField);
                        moveCounter++;
                }

                
                printirai(battleField);

                int count =0;
                bool krai = false;

                for (int rowCheck = 0; rowCheck < n; rowCheck++)
                {
                    for (int colCheck = 0; colCheck < n; colCheck++)
                    {
                        if (battleField[rowCheck, colCheck] == "-" || battleField[rowCheck, colCheck] == "X")
                        {
                            count++;
                        }
                        if (count == n * n)
                        {
                            krai = true; 
                        }
                    }
                }
                
                if (krai)
                {
                    printirai(battleField);
                    Console.WriteLine("Game over!");
                    PrintMoves(moveCounter);
                    break;
                }
            }
        }

        static string[,] HodNaIgracha(int row, int col, int n, string[,] battleField)
        {
            if (Convert.ToInt16(battleField[row, col]) >= 1)
            {
                if (row - 1 >= 0 && col - 1 >= 0)
                {
                    battleField[row - 1, col - 1] = "X";
                }
                if (row - 1 >= 0 && col < n - 1)
                {
                    battleField[row - 1, col + 1] = "X";
                }
                if (row < n - 1 && col - 1 > 0)
                {
                    battleField[row + 1, col - 1] = "X";
                }
                if (row < n - 1 && col < n - 1)
                {
                    battleField[row + 1, col + 1] = "X";
                }

                if (Convert.ToInt16(battleField[row, col]) >= 2)
                {
                    if (row - 1 >= 0)
                    {
                        battleField[row - 1, col] = "X";
                    }
                    if (col - 1 >= 0)
                    {
                        battleField[row, col - 1] = "X";
                    }
                    if (col < n - 1)
                    {
                        battleField[row, col + 1] = "X";
                    }
                    if (row < n - 1)
                    {
                        battleField[row + 1, col] = "X";
                    }

                    if (Convert.ToInt16(battleField[row, col]) >= 3)
                    {
                        if (row - 2 >= 0)
                        {
                            battleField[row - 2, col] = "X";
                        }
                        if (col - 2 >= 0)
                        {
                            battleField[row, col - 2] = "X";
                        }
                        if (col < n - 2)
                        {
                            battleField[row, col + 2] = "X";
                        }
                        if (row < n - 2)
                        {
                            battleField[row + 2, col] = "X";
                        }

                        if (Convert.ToInt16(battleField[row, col]) >= 4)
                        {
                            if (row - 2 >= 0 && col - 1 >= 0)
                            {
                                battleField[row - 2, col - 1] = "X";
                            }
                            if (row - 2 >= 0 && col < n - 1)
                            {
                                battleField[row - 2, col + 1] = "X";
                            }
                            if (row - 1 >= 0 && col - 2 >= 0)
                            {
                                battleField[row - 1, col - 2] = "X";
                            }
                            if (row - 1 >= 0 && col < n - 2)
                            {
                                battleField[row - 1, col + 2] = "X";
                            }
                            if (row < n - 1 && col - 2 >= 0)
                            {
                                battleField[row + 1, col - 2] = "X";
                            }
                            if (row < n - 1 && col < n - 2)
                            {
                                battleField[row + 1, col + 2] = "X";
                            }
                            if (row < n - 2 && col - 1 > 0)
                            {
                                battleField[row + 2, col - 1] = "X";
                            }
                            if (row < n - 2 && col < n - 1)
                            {
                                battleField[row + 2, col + 1] = "X";
                            }

                            if (Convert.ToInt16(battleField[row, col]) == 5)
                            {
                                if (row - 2 >= 0 && col - 2 >= 0)
                                {
                                    battleField[row - 2, col - 2] = "X";
                                }
                                if (row - 2 >= 0 && col < n - 2)
                                {
                                    battleField[row - 2, col + 2] = "X";
                                }
                                if (row < n - 2 && col - 2 > 0)
                                {
                                    battleField[row + 2, col - 2] = "X";
                                }
                                if (row < n - 2 && col < n - 2)
                                {
                                    battleField[row + 2, col + 2] = "X";
                                }
                            }
                        }
                    }
                }
            }

            battleField[row, col] = "X";

            return battleField;
        }

        static void printirai(string[,] battleField)
        {
            for (int i = 0; i < battleField.GetLength(0); i++)
            {
                if (i == 0)
                {
                    Console.Write("   {0}  ", i);
                }
                else
                {
                    Console.Write("{0}  ", i);
                }
            }

            Console.WriteLine();

            for (int i = 0; i < battleField.GetLength(0); i++)
            {
                if (i == 0)
                {
                    Console.Write("   -", i);
                }
                else
                {
                    Console.Write("---");
                }
            }
            Console.WriteLine();

            for (int i = 0; i < battleField.GetLength(0); i++)
            {
                for (int j = -2; j < battleField.GetLength(1); j++)
                
                    if (j == -2)                    
                        Console.Write("{0}", i);
                    
                    else if (j == -1)
                       Console.Write("|");
                    
                    else
                       Console.Write(" {0} ", battleField[i, j]);
                Console.WriteLine();
            }
        }

        static void PrintMoves(int moves)
        {

            Console.WriteLine("Detonated mines {0}", moves);
        
        
        
        }
    }
}
