using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BattleField
{
    class Methods
    {
        //tuk e magiqta!!!!
        //we got the POWER
        public static void NapylniMasiva(int n, int rows, int cols, String[,] workField)
        {
            int count = 0;
            Random randomNumber = new Random();
            int randomPlaceI;
            int randomPlaceJ;
            int minPercent = Convert.ToInt32(0.15 * (n * n));
            int maxPercent = Convert.ToInt32(0.30 * (n * n));
            int countMines = randomNumber.Next(minPercent, maxPercent);

            while (count <= countMines)
            {

                randomPlaceI = randomNumber.Next(0, n);
                randomPlaceJ = randomNumber.Next(0, n);
                randomPlaceI += 2;
                randomPlaceJ = 2 * randomPlaceJ + 2;

                while (workField[randomPlaceI, randomPlaceJ] != " " && workField[randomPlaceI, randomPlaceJ] != "-")
                {

                    randomPlaceI = randomNumber.Next(0, n);
                    randomPlaceJ = randomNumber.Next(0, n);
                    randomPlaceI += 2;
                    randomPlaceJ = 2 * randomPlaceJ + 2;

                }

                String randomDigit = Convert.ToString(randomNumber.Next(1, 6));
                workField[randomPlaceI, randomPlaceJ] = randomDigit;
                workField[randomPlaceI, randomPlaceJ + 1] = " ";
                count++;
            }
        }


        public static void PrintArray(int rows, int cols, String[,] workField)
        {

            for (int i = 0; i < rows; i++)
            {

                for (int j = 0; j < cols; j++)


                    Console.Write(workField[i, j]);
                Console.WriteLine();

            }

        }

        public static void vremeEIgrachaDaDeistva(int n, int rows, int cols, String[,] workField, int countPlayed)
        {
            countPlayed++;
            Console.WriteLine("Please enter coordinates: ");
            String xy = Console.ReadLine();
            int x = int.Parse(xy.Substring(0, 1));
            int y = int.Parse(xy.Substring(2, 1));

            while ((x < 0 || x > (n - 1)) && (y < 0 || y > (n - 1)))
            {
                Console.WriteLine("Invalid move !");
                Console.WriteLine("Please enter coordinates: ");
                xy = Console.ReadLine();
                x = int.Parse(xy.Substring(0, 1));
                y = int.Parse(xy.Substring(2, 1));

            }

            x += 2;
            y = 2 * y + 2;

            while (workField[x, y] == "-" || workField[x, y] == "X")
            {
                Console.WriteLine("Invalid move! ");
                Console.WriteLine("Please enter coordinates: ");
                xy = Console.ReadLine();
                x = int.Parse(xy.Substring(0, 1));
                y = int.Parse(xy.Substring(2, 1));

                while ((x < 0 || x > (n - 1)) && (y < 0 || y > (n - 1)))
                {
                    Console.WriteLine("Invalid move !");
                    Console.WriteLine("Please enter coordinates: ");
                    xy = Console.ReadLine();
                    x = int.Parse(xy.Substring(0, 1));
                    y = int.Parse(xy.Substring(2, 1));

                }

                x += 2;
                y = 2 * y + 2;

            }


            int hitCoordinate = Convert.ToInt32(workField[x, y]);
            switch (hitCoordinate)
            {
                case 1: HitOne(x, y, rows, cols, workField); break;
                case 2: PrasniDvama(x, y, rows, cols, workField); break;
                case 3: HitThree(x, y, rows, cols, workField); break;
                case 4: HitFour(x, y, rows, cols, workField); break;
                case 5: HitFive(x, y, rows, cols, workField); break;
            }

            PrintArray(rows, cols, workField);
            if (!Krai(rows, cols, workField))
            {
                vremeEIgrachaDaDeistva(n, rows, cols, workField, countPlayed);
            }
            else
            {
                Console.WriteLine("Game over. Detonated mines: " + countPlayed);
            }

        }


        public static void HitOne(int x, int y, int rows, int cols, String[,] workField)
        {
            workField[x, y] = "X";
            if (x - 1 > 1 && y - 2 > 1)
            {
                workField[x - 1, y - 2] = "X";
            }
            if (x - 1 > 1 && y < cols - 2)
            {
                workField[x - 1, y + 2] = "X";
            }
            if (x < rows - 1 && y < cols - 2)
            {
                workField[x + 1, y + 2] = "X";
            }
            if (x < rows - 1 && y - 2 > 1)
            {
                workField[x + 1, y - 2] = "X";
            }


        }

        public static void PrasniDvama(int x, int y, int rows, int cols, String[,] workField)
        {
            workField[x, y] = "X";
            HitOne(x, y, rows, cols, workField);
            if (y - 2 > 1)
            {
                workField[x, y - 2] = "X";
            }
            if (y < cols - 2)
            {
                workField[x, y + 2] = "X";
            }
            if (x - 1 > 1)
            {
                workField[x - 1, y] = "X";
            }
            if (x < rows - 1)
            {
                workField[x + 1, y] = "X";
            }

        }


        public static void HitThree(int x, int y, int rows, int cols, String[,] workField)
        {
            PrasniDvama(x, y, rows, cols, workField);
            if (x - 2 > 1)
            {
                workField[x - 2, y] = "X";
            }
            if (x < rows - 2)
            {
                workField[x + 2, y] = "X";
            }
            if (y - 4 > 1)
            {
                workField[x, y - 4] = "X";
            }
            if (y == 18)
            {
                workField[x, y + 2] = "X";

            }
            else if (y == 20)
            {
                workField[x, y] = "X";
            }
            else
            {
                if (y < cols - 3)
                {
                    workField[x, y + 4] = "X";
                }
            }
        }

        public static void HitFour(int x, int y, int rows, int cols, String[,] workField)
        {
            HitThree(x, y, rows, cols, workField);
            if (x - 2 > 1 && y - 2 > 1)
            {
                workField[x - 2, y - 2] = "X";
            }
            if (x - 1 > 1 && y - 4 > 1)
            {
                workField[x - 1, y - 4] = "X";
            }
            if (x - 2 > 1 && y < cols - 2)
            {
                workField[x - 2, y + 2] = "X";
            }


            if (x < rows - 1 && y - 4 > 1)
            {
                workField[x + 1, y - 4] = "X";
            }
            if (x < rows - 2 && y - 2 > 1)
            {
                workField[x + 2, y - 2] = "X";
            }

            if (x < rows - 2 && y < cols - 2)
            {
                workField[x + 2, y + 2] = "X";
            }

            if (y == 18)
            {
                if (x - 1 > 1)
                {
                    workField[x - 1, y + 2] = "X";
                }

                if (x < rows - 1)
                {
                    workField[x + 1, y + 2] = "X";
                }
            }

            else if (y == 20)
            {
                if (x - 1 > 1)
                {
                    workField[x - 1, y] = "X";
                }

                if (x < rows - 1)
                {
                    workField[x + 1, y] = "X";
                }
            }
            else
            {

                if (x - 1 > 1 && y < cols - 3)
                {
                    workField[x - 1, y + 4] = "X";
                }

                if (x < rows - 1 && y < cols - 3)
                {
                    workField[x + 1, y + 4] = "X";
                }

            }

        }

        public static void HitFive(int x, int y, int rows, int cols, String[,] poleZaRabota)
        {
            HitFour(x, y, rows, cols, poleZaRabota);
            if (x - 2 > 1 && y - 4 > 1)
            {
                poleZaRabota[x - 2, y - 4] = "X";
            }

            if (x < rows - 2 && y - 4 > 1)
            {
                poleZaRabota[x + 2, y - 4] = "X";
            }

            if (y == 18)
            {
                if (x < rows - 2)
                {
                    poleZaRabota[x + 2, y + 2] = "X";
                }
                if (x - 2 > 1)
                {
                    poleZaRabota[x - 2, y + 2] = "X";
                }
            }
            else if (y == 20)
            {
                if (x < rows - 2)
                {
                    poleZaRabota[x + 2, y] = "X";
                }
                if (x - 2 > 1)
                {
                    poleZaRabota[x - 2, y] = "X";
                }

            }
            else
            {
                if (x < rows - 2 && y < cols - 3)
                {
                    poleZaRabota[x + 2, y + 4] = "X";
                }
                if (x - 2 > 1 && y < cols - 3)
                {
                    poleZaRabota[x - 2, y + 4] = "X";
                }
            }
        }

        public static bool Krai(int rows, int cols, String[,] Полето)
        {
            bool край = true;
            for (int i = 2; i < rows; i++)
            {
                for (int j = 2; j < cols; j++)
                {
                    if (Полето[i, j] == "1" || Полето[i, j] == "2" || Полето[i, j] == "3" || Полето[i, j] == "4" || Полето[i, j] == "5")
                    {
                        край = false;
                        break;
                    }
                }
            }
            return край;

        }


    }
}
