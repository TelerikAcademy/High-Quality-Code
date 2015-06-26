using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BalloonsPops
{
    class GameBoard
    {
        char[,] gb = new char[25, 8];
        int count = 0;
        int broya4 = 50;
        public int ShootCounter
        {
            get
            {
                return count;


            }
        }
        public int RemainingBaloons
        {
            get
            {
                return broya4;
            }
        }
        public void GenerateNewGame()
        {
            Console.WriteLine("Welcome to “Balloons Pops” game. Please try to pop the balloons. Use 'top' to view the top scoreboard, 'restart' to start a new game and 'exit' to quit the game.");
            broya4 = 50;
            FillBlankGameBoard();
            Random random = new Random();
            Coordinates c = new Coordinates();
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    c.X = i;
                    c.Y = j;


                    AddNewBaloonToGameBoard(c, (char)(random.Next(1, 5) + (int)'0'));
                }
            }
        }
        private void AddNewBaloonToGameBoard(Coordinates c, char value)
        {
            int xPosition, yPosition;
            xPosition = 4 + c.X * 2;
            yPosition = 2 + c.Y;
            gb[xPosition, yPosition] = value;
        }
        private char get(Coordinates c)
        {
            int xPosition, yPosition;
            if (c.X < 0 || c.Y < 0 || c.X > 9 || c.Y > 4) return 'e';
            xPosition = 4 + c.X * 2;


            yPosition = 2 + c.Y;
            return gb[xPosition, yPosition];
        }
        private void FillBlankGameBoard()
        {
            //printing blank spaces
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 25; j++)
                {

                    gb[j, i] = ' ';
                }
            }

            //printing firs row
            for (int i = 0; i < 4; i++)
            {
                gb[i, 0] = ' ';
            }

            char counter = '0';


            for (int i = 4; i < 25; i++)
            {
                if ((i % 2 == 0) && counter <= '9') gb[i, 0] = (char)counter++;
                else gb[i, 0] = ' ';
            }

            //printing second row
            for (int i = 3; i < 24; i++)
            {
                gb[i, 1] = '-';
            }


            //printing left game board wall
            counter = '0';

            for (int i = 2; i < 8; i++)
            {
                if (counter <= '4')
                {
                    gb[0, i] = counter++;
                    gb[1, i] = ' ';


                    gb[2, i] = '|';
                    gb[3, i] = ' ';
                }
            }

            //printing down game board wall
            for (int i = 3; i < 24; i++)
            {
                gb[i, 7] = '-';
            }

            //printing right game board wall
            for (int i = 2; i < 7; i++)
            {
                gb[24, i] = '|';
            }
        }

        public void PrintGameBoard()
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 25; j++)
                {


                    Console.Write(gb[j, i]);
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        public void Shoot(Coordinates c)
        {
            char currentBaloon;
            currentBaloon = get(c);
            Coordinates tempCoordinates = new Coordinates();

            if (currentBaloon < '1' || currentBaloon > '4')
            {
                Console.WriteLine("Illegal move: cannot pop missing ballon!");return;
            }



            AddNewBaloonToGameBoard(c, '.');
            broya4--;

            tempCoordinates.X = c.X - 1;
            tempCoordinates.Y = c.Y;
            while (currentBaloon == get(tempCoordinates))
            {
                AddNewBaloonToGameBoard(tempCoordinates, '.');
                broya4--;
                tempCoordinates.X--;
            }

            tempCoordinates.X = c.X + 1; tempCoordinates.Y = c.Y;
            while (currentBaloon == get(tempCoordinates))
            {
                AddNewBaloonToGameBoard(tempCoordinates, '.');
                broya4--;
                tempCoordinates.X++;
            }

            tempCoordinates.X = c.X;
            tempCoordinates.Y = c.Y - 1;
            while (currentBaloon == get(tempCoordinates))
            {


                AddNewBaloonToGameBoard(tempCoordinates, '.');
                broya4--;
                tempCoordinates.Y--;
            }

            tempCoordinates.X = c.X;
            tempCoordinates.Y = c.Y + 1;
            while (currentBaloon == get(tempCoordinates))
            {
                AddNewBaloonToGameBoard(tempCoordinates, '.');
                broya4--;
                tempCoordinates.Y++;
            }

            count++;
            LandFlyingBaloons();
        }

        private void Swap(Coordinates c, Coordinates c1)
        {
            char tmp = get(c);
            AddNewBaloonToGameBoard(c, get(c1));
            AddNewBaloonToGameBoard(c1, tmp);


        }

        private void LandFlyingBaloons()
        {
            Coordinates c = new Coordinates();
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j <= 4; j++)
                {
                    c.X = i;
                    c.Y = j;
                    if (get(c) == '.')
                    {
                        for (int k = j; k > 0; k--)
                        {
                            Coordinates tempCoordinates = new Coordinates();
                            Coordinates tempCoordinates1 = new Coordinates();
                            tempCoordinates.X = i;
                            tempCoordinates.Y = k;
                            tempCoordinates1.X = i;
                            tempCoordinates1.Y = k - 1;
                            Swap(tempCoordinates, tempCoordinates1);
                        }
                    }
                }


            }
        }

        public bool ReadInput(out bool IsCoordinates, ref Coordinates coordinates, ref Command command)
        {
            Console.Write("Enter a row and column: ");
            string consoleInput = Console.ReadLine();

            coordinates = new Coordinates();
            command = new Command();

            if (Command.TryParse(consoleInput, ref command))
            {
                IsCoordinates = false;
                return true;
            }
            else if (Coordinates.TryParse(consoleInput, ref coordinates))
            {
                IsCoordinates = true;
                return true;
            }


            else
            {
                IsCoordinates = false;
                return false;
            }
        }
    }



}
