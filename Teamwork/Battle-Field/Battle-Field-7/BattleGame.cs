using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BattleFieldNamespace
{
    class BattleGame
    {
        int counter = 0;

        int n;

        private static int daj_chislo(int min, int max)
        {
            Random random = new Random();
            return Convert.ToInt32(random.Next(min, max));
        }

        string[,] Field;

        public void BombTwo(int row, int column)
        {
            BombOne(row, column);

            if (row - 1 >= 0)
            {
                if ((Field[row - 1, column] != "X") && (Field[row - 1, column] != "-"))
                    killedNumbers++;
                Field[row - 1, column] = "X";
            }
            ;

            if (column - 1 >= 0)
            {
                if ((Field[row, column - 1] != "X") && (Field[row, column - 1] != "-"))
                    killedNumbers++;
                Field[row, column - 1] = "X";
            }
            ;

            if (column + 1 <= n - 1)
            {
                if ((Field[row, column + 1] != "X") && (Field[row, column + 1] != "-"))
                    killedNumbers++;
                Field[row, column + 1] = "X";
            }
            ;

            if (row + 1 <= n - 1)
            {
                if ((Field[row + 1, column] != "X") && (Field[row + 1, column] != "-"))
                    killedNumbers++;
                Field[row + 1, column] = "X";
            }
            ;
        }

        public void NekaGyrmi4(int row, int column)
        {
            BombThree(row, column);

            if ((row - 1 >= 0) && (column - 2 >= 0))
            {
                if ((Field[row - 1, column - 2] != "X") && (Field[row - 1, column - 2] != "-"))
                    killedNumbers++;
                Field[row - 1, column - 2] = "X";
            }
            ;

            if ((row + 1 <= n - 1) && (column - 2 >= 0))
            {
                if ((Field[row + 1, column - 2] != "X") && (Field[row + 1, column - 2] != "-"))
                    killedNumbers++;
                Field[row + 1, column - 2] = "X";
            }
            ;

            if ((row - 2 >= 0) && (column - 1 >= 0))
            {
                if ((Field[row - 2, column - 1] != "X") && (Field[row - 2, column - 1] != "-"))
                    killedNumbers++;
                Field[row - 2, column - 1] = "X";
            }
            ;

            if ((row + 2 <= n - 1) && (column - 1 >= 0))
            {
                if ((Field[row + 2, column - 1] != "X") && (Field[row + 2, column - 1] != "-"))
                    killedNumbers++;
                Field[row + 2, column - 1] = "X";
            }
            ;
            //

            if ((row - 1 >= 0) && (column + 2 <= n - 1))
            {
                if ((Field[row - 1, column + 2] != "X") && (Field[row - 1, column + 2] != "-"))
                    killedNumbers++;
                Field[row - 1, column + 2] = "X";
            }
            ;

            if ((row + 1 <= n - 1) && (column + 2 <= n - 1))
            {
                if ((Field[row + 1, column + 2] != "X") && (Field[row + 1, column + 2] != "-"))
                    killedNumbers++;
                Field[row + 1, column + 2] = "X";
            }
            ;

            if ((row - 2 >= 0) && (column + 1 <= n - 1))
            {
                if ((Field[row - 2, column + 1] != "X") && (Field[row - 2, column + 1] != "-"))
                    killedNumbers++;
                Field[row - 2, column + 1] = "X";
            }
            ;

            if ((row + 2 <= n - 1) && (column + 1 <= n - 1))
            {
                if ((Field[row + 2, column + 1] != "X") && (Field[row + 2, column + 1] != "-"))
                    killedNumbers++;
                Field[row + 2, column + 1] = "X";
            }
            ;
        }

        public bool check2()
        {
            if (killedNumbers == counter)
                return true;
            else
                return false;
        }

        public bool check(int row, int column)
        {
            if ((row >= 0) && (row <= n - 1) && (column >= 0) && (column <= n - 1))
            {
                return false;
            }
            return true;
        }

        public void MineCell(int row, int column)
        {
            int cellNumber;

            if ((Field[row, column] == "X") || ((Field[row, column]) == "-"))
                cellNumber = 0;
            else
                cellNumber = Convert.ToInt32(Field[row, column]);
            switch (cellNumber)
            {
                case 1:
                    {
                        BombOne(row, column);
                        Console.Write("   ");
                        for (int k = 0; k <= n - 1; k++)
                        {
                            Console.Write(k + " ");
                        }
                        Console.WriteLine();
                        Console.Write("   ");
                        for (int k = 0; k <= n - 1; k++)
                        {
                            Console.Write("--");
                        }
                        Console.WriteLine();

                        for (int i = 0; i <= n - 1; i++)
                        {
                            Console.Write(i + "| ");
                            for (int j = 0; j <= n - 1; j++)
                            {
                                Console.Write(Field[i, j] + " ");
                            }

                            Console.WriteLine();

                            Console.WriteLine();
                        }
                        izgyrmqniBombi++;
                        break;
                    }
                    ;
                case 2:
                    {
                        BombTwo(row, column);
                        Console.Write("   ");
                        for (int k = 0; k <= n - 1; k++)
                        {
                            Console.Write(k + " ");
                        }
                        Console.WriteLine();
                        Console.Write("   ");
                        for (int k = 0; k <= n - 1; k++)
                        {
                            Console.Write("--");
                        }
                        Console.WriteLine();

                        for (int i = 0; i <= n - 1; i++)
                        {
                            Console.Write(i + "| ");
                            for (int j = 0; j <= n - 1; j++)
                            {
                                Console.Write(Field[i, j] + " ");
                            }

                            Console.WriteLine();

                            Console.WriteLine();
                        }
                        izgyrmqniBombi++;
                        break;
                    }
                    ;
                case 3:
                    {
                        BombThree(row, column);
                        Console.Write("   ");
                        for (int k = 0; k <= n - 1; k++)
                        {
                            Console.Write(k + " ");
                        }
                        Console.WriteLine();
                        Console.Write("   ");
                        for (int k = 0; k <= n - 1; k++)
                        {
                            Console.Write("--");
                        }
                        Console.WriteLine();

                        for (int i = 0; i <= n - 1; i++)
                        {
                            Console.Write(i + "| ");
                            for (int j = 0; j <= n - 1; j++)
                            {
                                Console.Write(Field[i, j] + " ");
                            }

                            Console.WriteLine();

                            Console.WriteLine();
                        }
                        izgyrmqniBombi++;
                        break;
                    }
                    ;
                case 4:
                    {
                        NekaGyrmi4(row, column);
                        Console.Write("   ");
                        for (int k = 0; k <= n - 1; k++)
                        {
                            Console.Write(k + " ");
                        }
                        Console.WriteLine();
                        Console.Write("   ");
                        for (int k = 0; k <= n - 1; k++)
                        {
                            Console.Write("--");
                        }
                        Console.WriteLine();

                        for (int i = 0; i <= n - 1; i++)
                        {
                            Console.Write(i + "| ");
                            for (int j = 0; j <= n - 1; j++)
                            {
                                Console.Write(Field[i, j] + " ");
                            }

                            Console.WriteLine();

                            Console.WriteLine();
                        }
                        izgyrmqniBombi++;
                        break;
                    }
                    ;
                case 5:
                    {
                        BombFive(row, column);
                        Console.Write("   ");
                        for (int k = 0; k <= n - 1; k++)
                        {
                            Console.Write(k + " ");
                        }
                        Console.WriteLine();
                        Console.Write("   ");
                        for (int k = 0; k <= n - 1; k++)
                        {
                            Console.Write("--");
                        }
                        Console.WriteLine();

                        for (int i = 0; i <= n - 1; i++)
                        {
                            Console.Write(i + "| ");
                            for (int j = 0; j <= n - 1; j++)
                            {
                                Console.Write(Field[i, j] + " ");
                            }

                            Console.WriteLine();

                            Console.WriteLine();
                        }
                        izgyrmqniBombi++;
                        break;
                    }
                    ;

                default:
                    {
                        Console.WriteLine("Invalid Move!");
                        Console.WriteLine();
                        break;
                    }
                    ;
            }
        }

        int izgyrmqniBombi = 0;

        public void BombOne(int row, int column)
        {
            Field[row, column] = "X";
            killedNumbers++;
            if ((row - 1 >= 0) && (column - 1 >= 0)) 
            {
                if ((Field[row - 1, column - 1] != "X") && (Field[row - 1, column - 1] != "-"))
                    killedNumbers++;
                Field[row - 1, column - 1] = "X";
            }
            ;

            if ((row + 1 <= n - 1) && (column - 1 >= 0))
            {
                if ((Field[row + 1, column - 1] != "X") && (Field[row + 1, column - 1] != "-"))
                    killedNumbers++;
                Field[row + 1, column - 1] = "X";
            }
            ;

            if ((row - 1 >= 0) && (column + 1 <= n - 1))
            {
                if ((Field[row - 1, column + 1] != "X") && (Field[row - 1, column + 1] != "-"))
                    killedNumbers++;
                Field[row - 1, column + 1] = "X";
            }
            ;

            if ((row + 1 <= n - 1) && (column + 1 <= n - 1))
            {
                if ((Field[row + 1, column + 1] != "X") && (Field[row + 1, column + 1] != "-"))
                    killedNumbers++;
                Field[row + 1, column + 1] = "X";
            }
            ;
        }

        public int ReadCellsNumber()
        {
            string readThings;
            int readNumber;
            do
            {
                Console.Write("Please Enter Valid Size Of The Field.n=");
                readThings = Console.ReadLine();

                if (!(Int32.TryParse(
                    readThings, out readNumber)))
                {
                    readNumber = -1;
                }
            }
            while (!(proverka(readNumber)));

            return readNumber;

            ;
        }

        public Boolean proverka(int inputNumber) 
        {
            if ((inputNumber < 1) || (inputNumber > 10))
                return false;
            else
                return true;
        }

        public void Init()
        {
            int i;
            int j;
            while (counter + 1 <= 0.3 * n * n) 
            {
                i = daj_chislo(0, n - 1);
                j = daj_chislo(0, n - 1);
                 
                if (Field[i, j] == "-")
                {
                    Field[i, j] = Convert.ToString(daj_chislo(1, 5));
                    counter++;

                    if (counter >=
                        0.15 * n * n) 
                    {
                        int flag = daj_chislo(0, 1);
                        if (flag == 1)
                        {
                            break;
                        }
                        ; 
                    }
                    ;
                }
                ;
            }
        }

        int killedNumbers = 0;

        public void BombThree(int row, int column)
        {
            BombTwo(row, column);
             
            if (row - 2 >= 0)
            {
                if ((Field[row - 2, column] != "X") && (Field[row - 2, column] != "-"))
                    killedNumbers++;
                Field[row - 2, column] = "X";
            }
            ;

            if (column - 2 >= 0)
            {
                if ((Field[row, column - 2] != "X") && (Field[row, column - 2] != "-"))
                    killedNumbers++;
                Field[row, column - 2] = "X";
            }
            ;

            if (column + 2 <= n - 1)
            {
                if ((Field[row, column + 2] != "X") && (Field[row, column + 2] != "-"))
                    killedNumbers++;
                Field[row, column + 2] = "X";
            }
            ;

            if (row + 2 <= n - 1)
            {
                if ((Field[row + 2, column] != "X") && (Field[row + 2, column] != "-"))
                    killedNumbers++;
                Field[row + 2, column] = "X";
            }
            ;
        }

        public void BombFive(int row, int column)
        {
            NekaGyrmi4(row, column);

            if ((row - 2 >= 0) && (column - 2 >= 0))
            {
                if ((Field[row - 2, column - 2] != "X") && (Field[row - 2, column - 2] != "-"))
                    killedNumbers++;
                Field[row - 2, column - 2] = "X";
            }
            ;

            if ((row + 2 <= n - 1) && (column - 2 >= 0))
            {
                if ((Field[row + 2, column - 2] != "X") && (Field[row + 2, column - 2] != "-"))
                    killedNumbers++;
                Field[row + 2, column - 2] = "X";
            }
            ;

            if ((row - 2 >= 0) && (column + 2 <= n - 1))
            {
                if ((Field[row - 2, column + 2] != "X") && (Field[row - 2, column + 2] != "-"))
                    killedNumbers++;
                Field[row - 2, column + 2] = "X";
            }
            ;

            if ((row + 2 <= n - 1) && (column + 2 <= n - 1))
            {
                if ((Field[row + 2, column + 2] != "X") && (Field[row + 2, column + 2] != "-"))
                    killedNumbers++;
                Field[row + 2, column + 2] = "X";
            }
            ;
        }

        public void Start()
        {
            n = ReadCellsNumber();

            Field = new string[n, n];
            for (int i = 0; i <= n - 1; i++)

                for (int j = 0; j <= n - 1; j++)
                {
                    Field[i, j] = "-";
                }
            Init();
            Console.Write("   ");
            for (int k = 0; k <= n - 1; k++)
            {
                Console.Write(k + " ");
            }
            Console.WriteLine();
            Console.Write("   ");
            for (int k = 0; k <= n - 1; k++)
            {
                Console.Write("--");
            }
            Console.WriteLine();

            for (int i = 0; i <= n - 1; i++)
            {
                Console.Write(i + "| ");
                for (int j = 0; j <= n - 1; j++)
                {
                    Console.Write(Field[i, j] + " ");
                }

                Console.WriteLine();

                Console.WriteLine();
            }
            
            while (!(check2()))
            {
                Console.Write("Please Enter Coordinates : ");

                string inputRowAndColumn = Console.ReadLine();
                string[] rowAndColumnSplit = inputRowAndColumn.Split(' ');
                int row ;
                int column ;
                 
                if ((rowAndColumnSplit.Length) <= 0)
                {
                    row = - 1;
                    column = -1;
                }
                else
                {
                    if (!(int.TryParse(rowAndColumnSplit[0], out row)))
                        row = -1;
                    if (!(int.TryParse(rowAndColumnSplit[1], out column)))
                        column = -1;
                }
                 
                if ((check(row, column))) 
                {
                    Console.WriteLine("This Move Is Out Of Area.");
                }
                else 
                { 
                    MineCell(row, column);
                }
                ;
            }

            Console.WriteLine("Game Over.Detonated Mines {0}", izgyrmqniBombi);
        }
    }
}
