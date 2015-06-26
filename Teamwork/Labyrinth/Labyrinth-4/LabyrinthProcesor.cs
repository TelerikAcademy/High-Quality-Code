using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Labyrinth
{
    public class LabyrinthProcesor
    {
        #region Fields

        private LabyrinthMatrix matrix;
        private uint moveCount;
        private Top5Scoreboard scoreboard;

        #endregion

        #region Properties

        public LabyrinthMatrix Matrix
        {
            get { return matrix; }
            set { matrix = value; }
        }

        #endregion

        public LabyrinthProcesor()
        {
            scoreboard = new Top5Scoreboard();
            Restart();
        }
        public void ShowInputMessage()
        {
            Console.Write("Enter your move (L=left, R-right, U=up, D=down): ");
        }
        public void HandleInput(String input)
        {
            String lowerInput = input.ToLower();

            switch(lowerInput)
            {
                case "l":
                    if (!moveLeft())
                    {
                        Console.WriteLine("Invalid move!");
                    }
                break;

                case "r":
                    if (!moveRight())
                    {
                        Console.WriteLine("Invalid move!");
                    }
                break;

                case "u":
                    if (!moveUp())
                    {
                        Console.WriteLine("Invalid move!");
                    }
                break;

                case "d":
                    if (!moveDown())
                    {
                        Console.WriteLine("Invalid move!");
                    }
                break;

                case "top":
                    scoreboard.ShowScoreboard();
                break;

                case "restart":
                    Restart();
                break;

                case "exit":
                    Console.WriteLine("Good bye!");
                    System.Environment.Exit(0);
                break;

                default:
                    Console.WriteLine("Invalid command!");
                break;
            }

            IsFinished();
        }
        private void IsFinished()
        {
            if (matrix.MyPostionHorizontal == 0 ||
                matrix.MyPostionHorizontal == 6 ||
                matrix.MyPostionVertical == 0 ||
                matrix.MyPostionVertical == 6)
            {
                Console.WriteLine("Congratulations! You escaped in " + moveCount.ToString() + " moves.");
                scoreboard.HandleScoreboard(moveCount);
                Restart();
            }
        }
        private void Restart()
        {
            Console.WriteLine();
            Console.WriteLine("Welcome to “Labirinth” game. Please try to escape. Use 'top' to view the top scoreboard, 'restart' to start a new game and 'exit' to quit the game.");

            this.matrix = new LabyrinthMatrix();
            moveCount = 0;
        }
        #region Move Methods

        private bool moveDown()
        {
            if (!(matrix.MyPostionVertical == 6) &&
                this.matrix.Matrix[matrix.MyPostionHorizontal][matrix.MyPostionVertical + 1] == '-')
            {
                matrix.MyPostionVertical++;
                moveCount++;
                return true;
            }

            return false;
        }

        private bool moveUp()
        {
            if (!(matrix.MyPostionVertical == 0) &&
                this.matrix.Matrix[matrix.MyPostionHorizontal][matrix.MyPostionVertical - 1] == '-')
            {
                matrix.MyPostionVertical--;
                moveCount++;
                return true;
            }

            return false;
        }
        private bool moveRight()
        {
            if (!(matrix.MyPostionHorizontal == 6) &&
                 this.matrix.Matrix[matrix.MyPostionHorizontal+ 1][matrix.MyPostionVertical] == '-')
            {
                matrix.MyPostionHorizontal++;
                moveCount++;
                return true;
            }

            return false;
        }
        private bool moveLeft()
        {
            if (!(matrix.MyPostionHorizontal == 0) &&
                this.matrix.Matrix[matrix.MyPostionHorizontal - 1][matrix.MyPostionVertical] == '-')
            {
                matrix.MyPostionHorizontal--;
                moveCount++;
                return true;
            }

            return false;
        }

        #endregion
    }
}
