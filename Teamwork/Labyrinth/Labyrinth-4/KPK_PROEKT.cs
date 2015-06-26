using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Labyrinth
{
	// Nothing is more admirable than the fortitude with which millionaires tolerate the disadvantages of their wealth.

    class KPK_PROEKT
    {
        public static void ShowLabyrinth(LabyrinthMatrix labyrinth)
        {
            Console.WriteLine();
            char[][] myMatrix = labyrinth.Matrix;
            for (int i = 0; i < myMatrix.Length; i++)
            {
                for (int j = 0; j < myMatrix[i].Length; j++)
                {
                    if (i == labyrinth.MyPostionVertical && j == labyrinth.MyPostionHorizontal)
                    {



                        Console.Write("*");
                    }
                    else
                    {
                        Console.Write(myMatrix[j][i]);
                    }
                }
                Console.WriteLine();
            }
        }

        static void Main(string[] args)
        {
            LabyrinthProcesor processor = new LabyrinthProcesor();

            while (true)
            {
                ShowLabyrinth(processor.Matrix);
                processor.ShowInputMessage();
                String input;



                input = Console.ReadLine();
                processor.HandleInput(input);
            }
        }
        
        
    }
}
