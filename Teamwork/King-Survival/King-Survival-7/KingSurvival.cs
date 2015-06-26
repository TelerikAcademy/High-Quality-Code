using System;

namespace KingSurvival
{
    class kingg
    {
        int x;
        int y;

        public kingg()
        {
            this.x = 0;
            this.y = 0;
        }
        public kingg(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        public int X
        {
            get { return x; }
            set { x = value; }
        }
        public int Y
        {
            get { return y; }
            set { y = value; }
        }
    }
    class paww
    {
        //tova e klasa Peshka, koito zadava peshak s koordinati X i Y

        int x;
        int y;

        public paww()
        {
            this.x = 0;
            this.y = 0;
        }
        public paww(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        public int X
        {
            get { return x; }
            set { x = value; }
        }
        public int Y
        {
            get { return y; }
            set { y = value; }
        }

    }

    class KingSurvival
    {
        static int size = 8;
        static kingg car = new kingg(4, 7);

        static paww peshkaA = new paww(1, 0);
        
        static paww peshkaB = new paww(3, 0);
        
        static paww peshkaC = new paww(5, 0);
        
        static paww peshkaD = new paww(7, 0);
        
        static bool flag = true;

        public static bool IsKingTurn
        {
            get
            {
                return flag;
            }
        }

        public static paww PeshkaD
        {
            get
            {
                return peshkaD;
            }
            set
            {
                peshkaD = value;
            }
        }

        public static paww PeshkaC
        {
            get
            {
                return peshkaC;
            }
            set
            {
                peshkaC = value;
            }
        }

        public static paww PeshkaB
        {
            get
            {
                return peshkaB;
            }
            set
            {
                peshkaB = value;
            }
        }

        public static paww PeshkaA
        {
            get
            {
                return peshkaA;
            }
            set
            {
                peshkaA = value;
            }
        }

        public static kingg Car
        {
            get
            {
                return car;
            }
            set
            {
                car = value;
            }
        }

        public static int Size
        {
            get
            {
                return size;
            }
        }

        void Print(char[,] matrix)
        {
            Console.Clear();
            
            for (int i = 0; i < size; i++)
            
            {
            
                for (int j = 0; j < size; j++)
                
                {
                
                    Console.Write("{0,2}", matrix[i, j]);
                }


               
                Console.WriteLine("");
           
            }
        }

        static void Try(int dirX, int dirY, char[,] __m)
        {

            if (car.X + dirX < 0 || car.X + dirX > size - 1)
            {
                Console.WriteLine("Invalid Move!");
                Console.WriteLine("**Press a key to continue**");
                Console.ReadKey();
                flag = true;
                return;
            }

            if (car.Y + dirY < 0 || car.Y + dirY > size - 1)
            {
                Console.WriteLine("Invalid Move!");
                Console.WriteLine("**Press a key to continue**");
                Console.ReadKey();
                flag = true;
                return;
            }
            if (__m[car.Y + dirY, car.X + dirX] == 'A') 
            {
                __m[car.Y + dirY, car.X + dirX] = 'K';
                __m[peshkaA.Y, peshkaA.X] = '-';
            }
            if (__m[car.Y + dirY, car.X + dirX] == 'B')
            {
                __m[car.Y + dirY, car.X + dirX] = 'K';
                __m[peshkaB.Y, peshkaB.X] = '-';
            }
            if (__m[car.Y + dirY, car.X + dirX] == 'C')
            {
                __m[car.Y + dirY, car.X + dirX] = 'K';
                __m[peshkaC.Y, peshkaC.X] = '-';
            }
            if (__m[car.Y + dirY, car.X + dirX] == 'D')
            {
                __m[car.Y + dirY, car.X + dirX] = 'K';
                __m[peshkaD.Y, peshkaD.X] = '-';
            }
            __m[car.Y, car.X] = '-';
            __m[car.Y + dirY, car.X + dirX] = 'K';
            car.Y += dirY;
            car.X += dirX;
            return;
        }
        //abe tuka sym gi napravil edni... ama raboti
        //kvo kat sa 4 metoda
        static bool PawnAMove(int dirX, int dirY, char[,] matrix)
        {
            //sledvat mnogo proverki
            if (peshkaA.X + dirX < 0 || peshkaA.X + dirX > size - 1)
            {
                Console.WriteLine("Invalid Move!");
                Console.WriteLine("**Press a key to continue**");
                Console.ReadKey();
                flag = false;
                return false;
                
            }

            if (peshkaA.Y + dirY < 0 || peshkaA.Y + dirY > size - 1)
            {
                Console.WriteLine("Invalid Move!");
                Console.WriteLine("**Press a key to continue**");
                Console.ReadKey();
                flag = false;
                return false;
            }
            if (matrix[peshkaA.Y + dirY, peshkaA.X + dirX] == 'K')
            {
                Console.WriteLine("Pawn`s win!");
                return true;
            }
            if (matrix[peshkaA.Y + dirY, peshkaA.X + dirX] == 'D' || matrix[peshkaA.Y + dirY, peshkaA.X + dirX] == 'B'
                                                             || matrix[peshkaA.Y + dirY, peshkaA.X + dirX] == 'C')
            {
                Console.WriteLine("Invalid Move!");
                Console.WriteLine("**Press a key to continue**");
                Console.ReadKey();
                flag = false;
                return false;
            }

            //ako ne grymne do momenta znachi e validen hoda
           
            matrix[peshkaA.Y, peshkaA.X] = '-';
            matrix[peshkaA.Y + dirY, peshkaA.X + dirX] = 'A';
            peshkaA.Y += dirY;
            peshkaA.X += dirX;
            return false;
        }
        static bool PawnBMove(int dirX, int dirY, char[,] matrix)
        {//za dokumentaciq pregledai PawnAMove
            if (peshkaB.X + dirX < 0 || peshkaB.X + dirX > size - 1)
            {
                Console.WriteLine("Invalid Move!");
                Console.WriteLine("**Press a key to continue**");
                Console.ReadKey();
                flag = false;
                return false;
            }

            if (peshkaB.Y + dirY < 0 || peshkaB.Y + dirY > size - 1)
            {
                Console.WriteLine("Invalid Move!");
                Console.WriteLine("**Press a key to continue**");
                Console.ReadKey();
                flag = false;
                return false;
            }
            if (matrix[peshkaB.Y + dirY, peshkaB.X + dirX] == 'K')
            {
                Console.WriteLine("Pawn`s win!");
                return true;
            }

            if (matrix[peshkaB.Y + dirY, peshkaB.X + dirX] == 'A' || matrix[peshkaB.Y + dirY, peshkaB.X + dirX] == 'C' 
                || matrix[peshkaB.Y + dirY, peshkaB.X + dirX] == 'D')
            {
                Console.WriteLine("Invalid Move!");
                Console.WriteLine("**Press a key to continue**");
                Console.ReadKey();
                flag = false;
                return false;
            }
            matrix[peshkaB.Y, peshkaB.X] = '-';
            matrix[peshkaB.Y + dirY, peshkaB.X + dirX] = 'B';
            peshkaB.Y += dirY;
            peshkaB.X += dirX;
            return false;
        }
        static bool PawnCMove(int dirX, int dirY, char[,] matrix)
        {//za dokumentaciq pregledai PawnAMove
            if (peshkaC.X + dirX < 0 || peshkaC.X + dirX > size - 1)
            {
                Console.WriteLine("Invalid Move!");
                Console.WriteLine("**Press a key to continue**");
                Console.ReadKey();
                flag = false;
                return false;
            }
            if (peshkaC.Y + dirY < 0 || peshkaC.Y + dirY > size - 1)
            {
                Console.WriteLine("Invalid Move!");
                Console.WriteLine("**Press a key to continue**");
                Console.ReadKey();
                flag = false;
                return false;
            }
            if (matrix[peshkaC.Y + dirY, peshkaC.X + dirX] == 'K')
            {
                Console.WriteLine("Pawn`s win!");
                return true;
            }
            if (matrix[peshkaC.Y + dirY, peshkaC.X + dirX] == 'A' || matrix[peshkaC.Y + dirY, peshkaC.X + dirX] == 'B'
                || matrix[peshkaC.Y + dirY, peshkaC.X + dirX] == 'D')
            {
                Console.WriteLine("Invalid Move!");
                Console.WriteLine("**Press a key to continue**");
                Console.ReadKey();
                flag = false;
                return false;
            }

            matrix[peshkaC.Y, peshkaC.X] = '-';
            matrix[peshkaC.Y + dirY, peshkaC.X + dirX] = 'C';
            peshkaC.Y += dirY;
            peshkaC.X += dirX;
            return false;
        }
        static bool PawnDMove(int dirX, int dirY, char[,] matrix)
        {//za dokumentaciq pregledai PawnAMove
            if (peshkaD.Y + dirY < 0 || peshkaD.Y + dirY > size - 1)
            {
                Console.WriteLine("Invalid Move!");
                Console.WriteLine("**Press a key to continue**");
                Console.ReadKey();
                flag = false;
                return false;
            }

            if (peshkaD.X + dirX < 0 || peshkaD.X + dirX > size - 1)
            {
                Console.WriteLine("Invalid Move!");
                Console.WriteLine("**Press a key to continue**");
                Console.ReadKey();
                flag = false;
                return false;
            }
            if (matrix[peshkaD.Y + dirY, peshkaD.X + dirX] == 'K')
            {
                Console.WriteLine("Pawn`s win!");
                return true;
            }
            if (matrix[peshkaD.Y + dirY, peshkaD.X + dirX] == 'A' || matrix[peshkaD.Y + dirY, peshkaD.X + dirX] == 'B'
                                                             || matrix[peshkaD.Y + dirY, peshkaD.X + dirX] == 'C')
            {
                Console.WriteLine("Invalid Move!");
                Console.WriteLine("**Press a key to continue**");
                Console.ReadKey();
                flag = false;
                return false;
            }

            matrix[peshkaD.Y, peshkaD.X] = '-';
            matrix[peshkaD.Y + dirY, peshkaD.X + dirX] = 'D';
            peshkaD.Y += dirY;
            peshkaD.X += dirX;
            return false;
        }

        static void Main()
        {
            char[,] m = new char[,]   {{'+','-','+','-','+','-','+','-'},
                                            {'-','+','-','+','-','+','-','+'},
                                            {'+','-','+','-','+','-','+','-'},
                                            {'-','+','-','+','-','+','-','+'},
                                            {'+','-','+','-','+','-','+','-'},
                                            {'-','+','-','+','-','+','-','+'},
                                            {'+','-','+','-','+','-','+','-'},
                                            {'-','+','-','+','-','+','-','+'}};

            m[peshkaA.Y, peshkaA.X] = 'A'; m[peshkaD.Y, peshkaD.X] = 'D';
            m[peshkaB.Y, peshkaB.X] = 'B';m[peshkaC.Y, peshkaC.X] = 'C';
            m[car.Y, car.X] = 'K';
            (new KingSurvival()).Print(m);
            bool flag2 = false;

            flag2 = Play(m, flag2);
            if (flag2)
            {
                Console.WriteLine("Pawn`s win!");
            }
            else
            {
                Console.WriteLine("King`s win!");
            }
        }
  
        private static bool Play(char[,] m, bool flag2)
        {
            while (car.Y > 0 && car.Y < size && !flag2)
            {
                flag = true;
                while (flag)
                {
                    flag = false;

                    (new KingSurvival()).Print(m);
                    Console.Write("King`s Turn:");
                    string direction = Console.ReadLine();
                    if (direction == "")
                    {
                        flag = true;
                        continue;
                    }

                    direction = direction.ToUpper();

                    switch (direction)
                    {
                        case "KUL":
                            {
                                Try(-1, -1, m);
                                break;
                            }
                        case "KUR":
                            {
                                Try(1, -1, m);
                                break;
                            }
                        case "KDL":
                            {
                                Try(-1, 1, m);
                                break;
                            }
                        case "KDR":
                            {
                                Try(1, 1, m);
                                break;
                            }
                        default:
                            {
                                flag = true;
                                Console.WriteLine("Invalid input!");
                                Console.WriteLine("**Press a key to continue**");
                                Console.ReadKey();
                                break;
                            }
                    }
                }
                while (!flag)
                {
                    flag = true;
                    (new KingSurvival()).Print(m);
                    Console.Write("Pawn`s Turn:");
                    string dd = Console.ReadLine();
                    if (dd == "")
                    {
                        flag = false;
                        continue;
                    }

                    dd = dd.ToUpper();

                    switch (dd)
                    {
                        case "ADR":
                            {
                                flag2 = PawnAMove(1, 1, m);
                                break;
                            }
                        case "ADL":
                            {
                                flag2 = PawnAMove(-1, 1, m);
                                break;
                            }
                        case "BDL":
                            {
                                flag2 = PawnBMove(-1, 1, m);
                                break;
                            }
                        case "BDR":
                            {
                                flag2 = PawnBMove(1, 1, m);
                                break;
                            }
                        case "CDL":
                            {
                                flag2 = PawnCMove(-1, 1, m);
                                break;
                            }
                        case "CDR":
                            {
                                flag2 = PawnCMove(1, 1, m);
                                break;
                            }
                        case "DDR":
                            {
                                flag2 = PawnDMove(1, 1, m);
                                break;
                            }
                        case "DDL":
                            {
                                flag2 = PawnDMove(-1, 1, m);
                                break;
                            }
                        default:
                            {
                                flag = false;
                                Console.WriteLine("Invalid input!");
                                Console.WriteLine("**Press a key to continue**");
                                Console.ReadKey();
                                break;
                            }
                    }
                    (new KingSurvival()).Print(m);
                }
            }
            return flag2;
        }
    }
}

        