using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CarqIPeshkite;

namespace KingSurvival
{
    class Game
    {
        static int size = 8;
        static Car car = new Car(4, 7);


        
        static Peshka peshkaA = new Peshka(1, 0);
        
        static Peshka peshkaB = new Peshka(3, 0);
        
        static Peshka peshkaC = new Peshka(5, 0);
        
        static Peshka peshkaD = new Peshka(7, 0);
        
        static bool isKingTurn = true;


        
        static void Print(char[,] matrix)
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
        static void KingMove(int dirX, int dirY, char[,] matrica)
        {

            if (car.X + dirX < 0 || car.X + dirX > size - 1)
            {
                Console.WriteLine("Invalid Move!");
                Console.WriteLine("**Press a key to continue**");
                Console.ReadKey();
                isKingTurn = true;
                return;
            }

            if (car.Y + dirY < 0 || car.Y + dirY > size - 1)
            {
                Console.WriteLine("Invalid Move!");
                Console.WriteLine("**Press a key to continue**");
                Console.ReadKey();
                isKingTurn = true;
                return;
            }
            if (matrica[car.Y + dirY, car.X + dirX] == 'A') 
            {
                matrica[car.Y + dirY, car.X + dirX] = 'K';
                matrica[peshkaA.Y, peshkaA.X] = '-';
            }
            if (matrica[car.Y + dirY, car.X + dirX] == 'B')
            {
                matrica[car.Y + dirY, car.X + dirX] = 'K';
                matrica[peshkaB.Y, peshkaB.X] = '-';
            }
            if (matrica[car.Y + dirY, car.X + dirX] == 'C')
            {
                matrica[car.Y + dirY, car.X + dirX] = 'K';
                matrica[peshkaC.Y, peshkaC.X] = '-';
            }
            if (matrica[car.Y + dirY, car.X + dirX] == 'D')
            {
                matrica[car.Y + dirY, car.X + dirX] = 'K';
                matrica[peshkaD.Y, peshkaD.X] = '-';
            }
            matrica[car.Y, car.X] = '-';
            matrica[car.Y + dirY, car.X + dirX] = 'K';
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
                isKingTurn = false;
                return false;
                
            }

            if (peshkaA.Y + dirY < 0 || peshkaA.Y + dirY > size - 1)
            {
                Console.WriteLine("Invalid Move!");
                Console.WriteLine("**Press a key to continue**");
                Console.ReadKey();
                isKingTurn = false;
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
                isKingTurn = false;
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
                isKingTurn = false;
                return false;
            }

            if (peshkaB.Y + dirY < 0 || peshkaB.Y + dirY > size - 1)
            {
                Console.WriteLine("Invalid Move!");
                Console.WriteLine("**Press a key to continue**");
                Console.ReadKey();
                isKingTurn = false;
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
                isKingTurn = false;
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
                isKingTurn = false;
                return false;
            }
            if (peshkaC.Y + dirY < 0 || peshkaC.Y + dirY > size - 1)
            {
                Console.WriteLine("Invalid Move!");
                Console.WriteLine("**Press a key to continue**");
                Console.ReadKey();
                isKingTurn = false;
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
                isKingTurn = false;
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
                isKingTurn = false;
                return false;
            }

            if (peshkaD.X + dirX < 0 || peshkaD.X + dirX > size - 1)
            {
                Console.WriteLine("Invalid Move!");
                Console.WriteLine("**Press a key to continue**");
                Console.ReadKey();
                isKingTurn = false;
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
                isKingTurn = false;
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
            char[,] matrica = new char[,]   {{'+','-','+','-','+','-','+','-'},
                                            {'-','+','-','+','-','+','-','+'},
                                            {'+','-','+','-','+','-','+','-'},
                                            {'-','+','-','+','-','+','-','+'},
                                            {'+','-','+','-','+','-','+','-'},
                                            {'-','+','-','+','-','+','-','+'},
                                            {'+','-','+','-','+','-','+','-'},
                                            {'-','+','-','+','-','+','-','+'}};

            
            matrica[peshkaA.Y, peshkaA.X] = 'A';
            matrica[peshkaB.Y, peshkaB.X] = 'B';
            matrica[peshkaC.Y, peshkaC.X] = 'C';
            matrica[peshkaD.Y, peshkaD.X] = 'D';
            matrica[car.Y, car.X] = 'K';
            Print(matrica);
            bool pobedaPeshki = false;

            while (car.Y > 0 && car.Y < size && !pobedaPeshki)
            {
                isKingTurn = true;
                while (isKingTurn)
                {
                    isKingTurn = false;

                    Print(matrica);
                    Console.Write("King`s Turn:");
                    string direction = Console.ReadLine();
                    if (direction == "")
                    {
                        isKingTurn = true;
                        continue;
                    }

                    direction = direction.ToUpper();

                    switch (direction)
                    {
                        case "KUL":
                            {
                                KingMove(-1, -1, matrica);
                                break;
                            }
                        case "KUR":
                            {
                                KingMove(1, -1, matrica);
                                break;
                            }
                        case "KDL":
                            {
                                KingMove(-1, 1, matrica);
                                break;
                            }
                        case "KDR":
                            {
                                KingMove(1, 1, matrica);
                                break;
                            }
                        default:
                            {
                                isKingTurn = true;
                                Console.WriteLine("Invalid input!");
                                Console.WriteLine("**Press a key to continue**");
                                Console.ReadKey();
                                break;
                            }

                    }
                }
                while (!isKingTurn)
                {
                    isKingTurn = true;
                    Print(matrica);
                    Console.Write("Pawn`s Turn:");
                    string direction = Console.ReadLine();
                    if (direction == "")
                    {
                        isKingTurn = false;
                        continue;
                    }

                    direction = direction.ToUpper();

                    switch (direction)
                    {
                        case "ADR":
                            {
                                pobedaPeshki= PawnAMove(1, 1, matrica);
                                break;
                            }
                        case "ADL":
                            {
                                pobedaPeshki = PawnAMove(-1, 1, matrica);
                                break;
                            }
                        case "BDL":
                            {
                                pobedaPeshki = PawnBMove(-1, 1, matrica);
                                break;
                            }
                        case "BDR":
                            {
                                pobedaPeshki = PawnBMove(1, 1, matrica);
                                break;
                            }
                        case "CDL":
                            {
                                pobedaPeshki = PawnCMove(-1, 1, matrica);
                                break;
                            }
                        case "CDR":
                            {
                                pobedaPeshki = PawnCMove(1, 1, matrica);
                                break;
                            }
                        case "DDR":
                            {
                              pobedaPeshki =   PawnDMove(1, 1, matrica);
                                break;
                            }
                        case "DDL":
                            {
                              pobedaPeshki = PawnDMove(-1, 1, matrica);
                                break;
                            }
                        default:
                            {
                                isKingTurn = false;
                                Console.WriteLine("Invalid input!");
                                Console.WriteLine("**Press a key to continue**");
                                Console.ReadKey();
                                break;
                            }
                    }
                    Print(matrica);
                }
            }
            if (pobedaPeshki)
            {
                Console.WriteLine("Pawn`s win!");
            }
            else
            {
                Console.WriteLine("King`s win!");
            }
        }
    }
}

        