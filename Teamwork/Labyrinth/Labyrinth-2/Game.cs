using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Labyrinth
{
    class Game
    {
        public Game(Random rand, Ladder ladder)
        {
            Labyrinth labyrinth = new Labyrinth(rand);
            
            UserInputAndOutput.PrintWelcomeMessage();
            int movesCount = 0;

            string input = "";

            while (!IsGameOver(labyrinth) && input != "restart")
            {
                UserInputAndOutput.PrinyLabyrinth(labyrinth);
                input = UserInputAndOutput.GetInput();
                ProccessInput(input, labyrinth, ref movesCount, ladder);
            }

            if (input != "restart")
            {
                Console.WriteLine("Congratulations! You escaped in {0} moves.",
                    movesCount);
                if (ladder.ResultQualifiesInLadder(movesCount))
                {
                    Console.WriteLine(
                        UserInputAndOutput.ENTER_NAME_FOR_SCOREBOARD_MSG);



                    string name = Console.ReadLine();
                    ladder.AddResultInLadder(movesCount, name);
                }
            }
            Console.WriteLine();
        }


        private bool IsGameOver(Labyrinth labyrinth)
        {
            bool isGameOver = false;
            int currentRow = labyrinth.currentCell.Row;
            int currentCol = labyrinth.currentCell.Col;
            if (currentRow == 0 ||
                currentCol == 0 ||
                currentRow == Labyrinth.LABYRINTH_SIZE - 1 ||
                currentCol == Labyrinth.LABYRINTH_SIZE - 1)
            {
                isGameOver = true;
            }

            return isGameOver;



        }

        private bool TryMove(string direction, Labyrinth labyrinth)
        {
            bool moveDone = false;
            switch (direction)
            {
                case "u":
                    moveDone =
                        labyrinth.TryMove(labyrinth.currentCell, Direction.Up);
                    break;
                case "d":
                    moveDone =
                        labyrinth.TryMove(labyrinth.currentCell, Direction.Down);
                    break;
                case "l":
                    moveDone =
                        labyrinth.TryMove(labyrinth.currentCell, Direction.Left);
                    break;
                case "r":
                    moveDone =
                        labyrinth.TryMove(labyrinth.currentCell, Direction.Right);
                    break;
                default:
                    Console.WriteLine(UserInputAndOutput.INVALID_MOVE_MSG);
                    break;



            }

            if (moveDone == false)
            {
                Console.WriteLine(UserInputAndOutput.INVALID_MOVE_MSG);
            }

            return moveDone;
        }

        private void ProccessInput(string input, Labyrinth labyrinth,
            ref int movesCount, Ladder ladder)
        {
            string inputToLower = input.ToLower();
            switch (inputToLower)
            {
                case "u":
                case "d":
                case "l":
                case "r":
                    //fallthrough
                    bool moveDone =
                        TryMove(inputToLower, labyrinth);
                    if (moveDone == true)
                    {
                        movesCount++;
                    }
                    break;
                case "top":
                    ladder.PrintLadder();
                    break;
                case "exit":
                    Console.WriteLine(UserInputAndOutput.GOODBYE_MSG);
                    Environment.Exit(0);
                    break;
                case "restart":
                    break;
                default:
                    string errorMessage = UserInputAndOutput.INVALID_COMMAND_MSG;
                    Console.WriteLine(errorMessage);
                    break;
            }
        }
    }
}
