using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Labyrinth
{
    static class UserInputAndOutput
    {
        public const string INVALID_MOVE_MSG = "Invalid move!";
        public const string INVALID_COMMAND_MSG = "Invalid command!";
        public const string SCOREBOARD_EMPTY_MSG = "The scoreboard is empty.";
        public const string ENTER_NAME_FOR_SCOREBOARD_MSG = "Please enter" +
            "your name for the top scoreboard: ";
        public const string GOODBYE_MSG = "Good Bye";
        private const string GET_INPUT_MSG = "Enter your move (L=left," +
            "R-right, U=up, D=down): ";
        private const string WELLCOME_MSG = "Welcome to “Labirinth” game." +
            " Please try to escape." +
            " Use 'top' to view the top scoreboard," +
            " 'restart' to start a new game and 'exit' to quit the game.";

        private static void PrintGetInputMessage()
        {
            Console.Write(GET_INPUT_MSG);
        }

        public static void PrintWelcomeMessage()
        {
            Console.WriteLine(WELLCOME_MSG);
        }

        public static string GetInput()
        {
            PrintGetInputMessage();
            string inputLine = Console.ReadLine();
            return inputLine;
        }

        public static void PrinyLabyrinth(Labyrinth labyrinth)
        {
            int labyrinthSize = Labyrinth.LABYRINTH_SIZE;
            for (int row = 0; row < labyrinthSize; row++)
            {
                for (int col = 0; col < labyrinthSize; col++)
                {
                    Cell cell = labyrinth.GetCell(row, col);
                    Console.Write(cell.ValueChar + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
