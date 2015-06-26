using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BattleField
{
    class BattleFieldGame
    {   static void Main(string[] argumenti)
        {   Console.Write("Welcome to \"Battle Field game.\" Enter battle field size: n = ");         
            int n = Convert.ToInt32(Console.ReadLine());
            while (n < 1 || n > 10)
            {

                Console.WriteLine("Enter a number between 1 and 10!");
                n = Convert.ToInt32(Console.ReadLine());

            }

            int rows = n + 2;
            int cols = n*2 + 2;
         
            String[,] field = new String[rows, cols];

            field[0, 0] = " ";
            field[0, 1] = " ";
            field[1, 0] = " ";
            field[1, 1] = " ";

            for (int row = 2; row < rows; row++)
            {

                for (int col = 2; col < cols; col++)

                {
                    
                    if (col % 2 == 0)
                    {
                        if (col == 2)
                        {
                            field[0, col] = "0";
                        }
                        else
                        {
                            field[0, col] = Convert.ToString((col - 2)/2);
                        }
                    }
                    else
                    {
                        field[0, col] = " ";
                    }
                    if (col < cols - 1)
                    {
                        field[1, col] = "-";
                    }

                    field[row, 0] = Convert.ToString(row - 2);
                    field[row, 1] = "|";
                    if (col % 2 == 0)
                    {
                        field[row, col] = "-";
                    }
                    else
                    {
                        field[row, col] = " ";
                    }
                      
                }

            }

            Methods.NapylniMasiva(n, rows, cols, field);
            Methods.PrintArray(rows, cols, field);
            int countPlayed = 0;
            Methods.vremeEIgrachaDaDeistva(n, rows, cols, field, countPlayed);
           
        }


        }
    }

