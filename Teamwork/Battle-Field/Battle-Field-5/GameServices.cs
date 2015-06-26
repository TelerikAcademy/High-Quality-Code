using System;
using System.Collections.Generic;

namespace BattleField
{
    public class GameServices
    {
        // tova e klasa v koito se pravqt magiite
        private static readonly Random rand = new Random();
        private const double LOWERBOUNDMINES = 0.15;
        private const double UPPERBOUNTMINES = 0.3;
        
        public static char[,] GenerateField(int size)
        {
            char[,] field = new char[size, size];
            int minesCount = DetermineMineCount(size);

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    field[i, j] = '-';
                }
            }

            List<Mine> mines = new List<Mine>();
            for (int i = 0; i < minesCount; i++)
            {
                int mineX = rand.Next(0, size);
                int mineY = rand.Next(0, size);
                Mine newMine = new Mine() { X = mineX, Y = mineY };

                if (GameServices.Contains(mines, newMine))
                {
                    i--;
                    continue;
                }

                int mineType = rand.Next('1', '6');
                field[mineX, mineY] = Convert.ToChar(mineType);
            }

            return field;
        }

        private static int DetermineMineCount(int size)
        {
            double fields = (double)size * size;
            int lowBound = (int)(LOWERBOUNDMINES * fields);
            int upperBound = (int)(UPPERBOUNTMINES * fields);

            return rand.Next(lowBound, upperBound);
        }

        private static bool Contains(List<Mine> list, Mine mine)
        {
            //abe tui e malko typo napraveno ama pyk bachka
            foreach (Mine mina in list)
            {
                if (mina.X == mine.X && mina.Y == mine.Y)
                {
                    return true;
                }
            }

            return false;
        }

        public static bool ContainsMines(char[,] field)
        {
            for (int i = 0; i < field.GetLength(0); i++)
            {
                for (int j = 0; j < field.GetLength(1); j++)
                {
                    if (field[i, j] != '-' && field[i, j] != 'X')
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        private static bool VPoletoLiE(char[,] field, int x, int y)
        {
            if (x < 0 || y < 0 || x >= field.GetLength(0) || y >= field.GetLength(1))
            {
                return false;
            }

            return true;
        }

        public static void Гърми(char[,] field, Mine mine)
        {
            char mineType = field[mine.X, mine.Y];

            switch (mineType)
            {
                case '1':
                    {
                        ExplodeOne(field, mine);
                    }
                    break;
                case '2':
                    {
                        ExplodeTwo(field, mine);
                    }
                    break;
                case '3':
                    {
                        ExplodeThree(field, mine);
                    }
                    break;
                case '4':
                    {
                        ExplodeFour(field, mine);
                    }
                    break;
                case '5':
                    {
                        ExplodeFive(field, mine);
                    }
                    break;
            }
        }

        private static void ExplodeOne(char[,] field, Mine mine)
        {
            Mine URcorner = new Mine() { X = mine.X - 1, Y = mine.Y - 1 };
            Mine ULcorner = new Mine() { X = mine.X - 1, Y = mine.Y + 1 };
            Mine DRcorner = new Mine() { X = mine.X + 1, Y = mine.Y - 1 };
            Mine DLcorner = new Mine() { X = mine.X + 1, Y = mine.Y + 1 };

            if (VPoletoLiE(field, mine.X, mine.Y))
            {
                field[mine.X, mine.Y] = 'X';
            }

            if (VPoletoLiE(field, URcorner.X, URcorner.Y))
            {
                field[URcorner.X, URcorner.Y] = 'X';
            }

            if (VPoletoLiE(field, ULcorner.X, ULcorner.Y))
            {
                field[ULcorner.X, ULcorner.Y] = 'X';
            }

            if (VPoletoLiE(field, DRcorner.X, DRcorner.Y))
            {
                field[DRcorner.X, DRcorner.Y] = 'X';
            }

            if (VPoletoLiE(field, DLcorner.X, DLcorner.Y))
            {
                field[DLcorner.X, DLcorner.Y] = 'X';
            }
        }

        private static void ExplodeTwo(char[,] field, Mine mine)
        {
            for (int i = mine.X - 1; i <= mine.X+1; i++)
            {
                for (int j = mine.Y - 1; j <= mine.Y+1; j++)
                {
                    if(VPoletoLiE(field, i,j))
                    {
                        field[i, j] = 'X';
                    }
                }
            }
        }

        private static void ExplodeThree(char[,] field, Mine mine)
        {
            ExplodeTwo(field, mine);
            Mine Up = new Mine() { X = mine.X - 2, Y = mine.Y };
            Mine Down = new Mine() { X = mine.X + 2, Y = mine.Y };
            Mine Left = new Mine() { X = mine.X, Y = mine.Y - 2 };
            Mine Right = new Mine() { X = mine.X, Y = mine.Y + 2 };

            if (VPoletoLiE(field, Up.X, Up.Y))
            {
                field[Up.X, Up.Y] = 'X';
            }

            if (VPoletoLiE(field, Down.X, Down.Y))
            {
                field[Down.X, Down.Y] = 'X';
            }

            if (VPoletoLiE(field, Left.X, Left.Y))
            {
                field[Left.X, Left.Y] = 'X';
            }

            if (VPoletoLiE(field, Right.X, Right.Y))
            {
                field[Right.X, Right.Y] = 'X';
            }
        }

        private static void ExplodeFour(char[,] field, Mine mine)
        {
            for (int i = mine.X - 2; i <= mine.X + 2; i++)
            {
                for (int j = mine.Y - 2; j <= mine.Y + 2; j++)
                {
                    bool UR = i == mine.X - 2 && j == mine.Y - 2;
                    bool UL = i == mine.X - 2 && j == mine.Y + 2;
                    bool DR = i == mine.X + 2 && j == mine.Y - 2;
                    bool DL = i == mine.X + 2 && j == mine.Y + 2;

                    if (UR) continue;
                    if (UL) continue;
                    if (DR) continue;
                    if (DL) continue;

                    if (VPoletoLiE(field, i, j))
                    {
                        field[i, j] = 'X';
                    }
                }
            }

        }

        private static void ExplodeFive(char[,] field, Mine mine)
        {
            for (int i = mine.X - 2; i <= mine.X + 2; i++)
            {
                for (int j = mine.Y - 2; j <= mine.Y + 2; j++)
                {
                    if (VPoletoLiE(field, i, j))
                    {
                        field[i, j] = 'X';
                    }
                }
            }
        }

        public static bool IsValidMove(char[,] field, int x, int y)
        {
            if (!VPoletoLiE(field, x, y))
            {
                return false;
            }
            if (field[x, y] == 'X' || field[x, y] == '-')
            {
                return false;
            }

            return true;
        }

        public static void PokajiMiRezultata(char[,] field)
        {
            Console.Write("   ");
            int size = field.GetLength(0);
            for (int i = 0; i < size; i++)
            {
                Console.Write("{0} ", i);
            }
            Console.WriteLine();
            Console.Write("   ");
            for (int i = 0; i < size*2; i++)
            {
                Console.Write("-");
            }
            Console.WriteLine();

            for (int i = 0; i < size; i++)
            {
                Console.Write("{0} |", i);
                for (int j = 0; j < size; j++)
                {
                    Console.Write("{0} ", field[i,j]);
                }
                Console.WriteLine();
            }
        }

        public static Mine ExtractMineFromString(string line)
        {
            if (line == null || line.Length < 3 || !line.Contains(" "))
            {
                Console.WriteLine("Invalid index!");
                return null;
            }

            string[] splited = line.Split(' ');

            int x = 0;
            int y = 0;

            if (!int.TryParse(splited[0], out x))
            {
                Console.WriteLine("Invalid index!");
                return null;
            }

            if (!int.TryParse(splited[1], out y))
            {
                Console.WriteLine("Invalid index!");
                return null;
            }

            return new Mine() { X = x, Y = y };
        }
    }
}
