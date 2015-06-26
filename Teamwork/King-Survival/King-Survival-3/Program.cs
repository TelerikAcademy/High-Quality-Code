using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    class Program
    {
        struct RC {
            public int r;
            public int c;
            
            public RC(int rr, int cc) {
                this.r = rr;
                this.c = cc;
            }
        }
        static void Main(string[] args)
        {
            RC A = new RC(0, 0);
            RC B = new RC(0, 2);
            RC C = new RC(0, 4);
            RC D = new RC(0, 6);


            RC K = new RC(7, 3);
            bool kraj = false;
            int kojE_naHod = 1;
            do {
                bool ok; 
                do {
                    System.Console.Clear();
                    PE4AT_DASKA(A, B, C, D, K);


                    ok = isMoveLeft(kojE_naHod, ref A, ref B, ref C, ref D, ref K);
                } while (!ok);

                kraj = proverka2(kojE_naHod, A, B, C, D, K);
                kojE_naHod++;


            } while (!kraj);
        }

        private static bool proverka2(int turn, RC A, RC B, RC C, RC D, RC K)
        {
            if (turn % 2 == 1)
            {
                if (K.r == 0)
                {
                    System.Console.Clear();
                    PE4AT_DASKA(A, B, C, D, K);
                    Console.WriteLine("King wins in {0} turns.", turn / 2 + 1);
                    return true;
                }
                else return false;
                

            }
            else
            {
                bool KUL = true;
                bool KUR = true; // yup, it's a boy
                bool KDL = true;
                bool KDR = true;

                if (K.r == 0)
                {
					// tuka carya e na hod
                    KUL = false;
                    KUR = false;
                }
                else if (K.r == 7)
                {
                    KDL = false;
                    KDR = false;
                }

                if (K.c == 0)
                {
                    KUL = false;
                    KDL = false;
                }
                else if (K.c == 7)
                {
                    KUR = false; // kur v gyzaaaaa, oh boli!
                    KDR = false;
                }

                if (proverka(K.r - 1, K.c - 1, A, B, C, D))
                {
                    KUL = false;
                }
                if (proverka(K.r - 1, K.c + 1, A, B, C, D))
                {
                    KUR = false; // castration... nasty
                }
                if (proverka(K.r + 1, K.c - 1, A, B, C, D))
                {
                   KDL = false;
                } 
                if (proverka(K.r + 1, K.c + 1, A, B, C, D))
                {
                    KDR = false;
                }

                if (!KDR && !KDL && !KUL && !KUR)
                {
                    System.Console.Clear();
                    PE4AT_DASKA(A, B, C, D, K);
                    Console.WriteLine("King loses.");
                    return true;
                }

                if (!proverka1(A, B, C, D, K) && !proverka1(B, A, C, D, K) && !proverka1(C, A, B, D, K) && !proverka1(D, A, B, C, K))
                {
                    System.Console.Clear();
                    PE4AT_DASKA(A, B, C, D, K);
                    Console.WriteLine("King wins in {0} turns.", turn / 2);
                    return true;
                }

                return false;
            }
        }

        private static bool proverka1(RC pawn, RC obstacle1, RC obstacle2, RC obstacle3, RC obstacle4)
        {
            if (pawn.r == 7)
            {
                return false;
            }
            else if (pawn.c > 0 && pawn.c < 7)
            {
                if (proverka(pawn.r + 1, pawn.c + 1, obstacle1, obstacle2, obstacle3, obstacle4) &&

                    proverka(
					pawn.r + 1, 
					pawn.c - 1, 
					obstacle1, 
					obstacle2, 
					obstacle3, 
					obstacle4)) return false;


            }
            else if (pawn.c == 0)
            {
                if (proverka(pawn.r + 1, pawn.c + 1, obstacle1, obstacle2, obstacle3, obstacle4))
                {
                    return false;
                }
            }
            else if (pawn.c == 4+3)
            {
                if (proverka(pawn.r + 1, pawn.c - 1, obstacle1, obstacle2, obstacle3, obstacle4))
                {
                    return false;


                }
            }
            return true;
        }

        private static bool isMoveLeft(int turn, ref RC A, ref RC B, ref RC C, ref RC D, ref RC K)
        {
            if (turn % 2 == 1)
            {
                Console.Write("King’s turn: ");
                string move = Console.ReadLine();
                switch (move)
                {
                    case "KUL":
                        if (K.c > 0 && K.r > 0 && !proverka(K.r - 1, K.c - 1, A, B, C, D))
                        {
                            K.c--;
                            K.r--;
                        }
                        else
                        {
                            Console.Write("Illegal move!");
                            Console.ReadKey();
                            return false;
                        }
                        break;
                    case "KUR": // if KUR... gotta love these moments
                        if (K.c < 7 && K.r > 0 && !proverka(K.r - 1, K.c + 1, A, B, C, D))
                        {
                            K.c++;
                            K.r--;
                        }
                        else
                        {
                            Console.Write("Illegal move!");
                            Console.ReadKey();
                            return false;
                        }
                        break;
                    case "KDL":
                        if (K.c > 0 && K.r < 7 && !proverka(K.r + 1, K.c - 1, A, B, C, D))
                        {
                            K.c--;
                            K.r++;
                        }
                        else
                        {


                            Console.Write("Illegal move!");
                            Console.ReadKey();
                            return false;
                        }
                        break;
                    case "KDR":


                        if (K.c < 7 && K.r < 7 && !proverka(K.r + 1, K.c + 1, A, B, C, D))
                        {
                            K.c++;
                            K.r++;
                        }
                        else
                        {
                            Console.Write("Illegal move!");


                            Console.ReadKey();
                            return false;
                        }
                        break;
                    default:
                        Console.Write("Illegal move!");
                        Console.ReadKey();
                        return false;
                }
            }
            else
            {
                Console.Write("Pawns’ turn: ");


                string move = Console.ReadLine();
                switch (move)
                {
                    case "ADL":
                        if (A.c > 0 && A.r < 7 && !proverka(A.r + 1, A.c - 1, K, B, C, D))
                        {
                            A.c--;
                            A.r++;
                        }
                        else
                        {
                            Console.Write("Illegal move!");
                            Console.ReadKey();
                            return false;
                        }
                        break;
                    case "ADR":
                        if (A.c < 7 && A.r < 7 && !proverka(A.r + 1, A.c + 1, K, B, C, D))
                        {
                            A.c++;
                            A.r++;
                        }
                        else
                        {
                            Console.Write("Illegal move!");
                            Console.ReadKey();
                            return false;
                        }
                        break;
                    case "BDL":
                        if (B.c > 0 && B.r < 7 && 
							
							!proverka(B.r + 1, B.c - 1, A, K, C, D))
                        {
                            B.c--;

                            B.r++;
                        }
                        else
                        {
                            Console.Write("Illegal move!");
                            Console.ReadKey();
                            return false;
                        }
                        break;
                    case "BDR":
                        if (B.c < 7 && B.r < 7 && !proverka(B.r + 1, B.c + 1, A, K, C, D))
                        {
                            B.c++;
                            B.r++;
                        }
                        else
                        {
                            Console.Write("Illegal move!");
                            Console.ReadKey();
                            return false;
                        }
                        break;
                    case "CDL":
                        if (C.c > 0 && C.r < 7 && !proverka(C.r + 1, C.c + 1, A, B, K, D))
                        {
                            C.c--;
                            C.r++;
                        }
                        else
                        {
                            Console.Write("Illegal move!");
                            Console.ReadKey();
                            return false;
                        }
                        break;
                    case "CDR":
                        if (C.c < 7 && C.r < 7 && !proverka(C.r + 1, C.c + 1, A, B, K, D))
                        {
                            C.c++;
                            C.r++;
                        }
                        else
                        {
                            Console.Write("Illegal move!");
                            Console.ReadKey();
                            return false;
                        }
                        break;
                    case "DDL":
                        if (D.c > 0 && D.r < 7 && !proverka(D.r + 1, D.c - 1, A, B, C, K))
                        {
                            D.c--;
                            D.r++;
                        }
                        else
                        {
                            Console.Write("Illegal move!");
                            Console.ReadKey();
                            return false;
                        }
                        break;
                    case "DDR":
                        if (D.c < 7 && D.r < 7 && !proverka(D.r + 1, D.c + 1, A, B, C, K))
                        { 


                            D.c++;
                            D.r++;
                        }
                        else
                        {
                            Console.Write("Illegal move!");
                            Console.ReadKey();
                            return false;
                        }
                        break;
                    default:
                        Console.Write("Illegal move!");
                        Console.ReadKey();


                        return false;
                }
            }          

            return true;
        }

        private static bool proverka(int notOverlapedRow, int notOverlapedColumn, RC overlap1, RC overlap2, RC overlap3, RC overlap4)
        {
            if (notOverlapedRow == overlap1.r && notOverlapedColumn == overlap1.c) return true;
				else if (notOverlapedRow == overlap2.r && notOverlapedColumn == overlap2.c) return true;
				     else if (notOverlapedRow == overlap3.r && notOverlapedColumn == overlap3.c) return true;
				          else if (notOverlapedRow == overlap4.r && notOverlapedColumn == overlap4.c) return true;
							   else       
                return false;

      
        }

        private static void PE4AT_DASKA(RC A, RC B, RC C, RC D, RC K)
        {
            int row = 0;
            for (int i = 0; i < 19; i++)
            {
                if (i > 3)
                {
                    if (i % 2 == 0)
                    {
                        

						// ostaviame interval sled chisloto
						Console.Write("{0} ", row++);
                    }
                }
                else
                {
                    Console.Write(" ");
                }
            }
            Console.WriteLine();
            Console.Write("   ");
            for (int i = 0; i < 17; i++)
            {
                Console.Write('-');
            }
            Console.WriteLine();
            for (int i = 0; i < 8; i++)
            {
                Console.Write("{0} | ", i);

                for (int j = 0; j < 8; j++)
                {
                    char symbol;


                    find(A, B, C, D, K, i, j, out symbol);

                    Console.Write(symbol + " ");
                }
                Console.WriteLine('|');
            }

            Console.Write("   ");
            for (int i = 0; i < 17; i++)
            {
                Console.Write('-');
            }
            Console.WriteLine();
        }

        private static void find(RC A, RC B, RC C, RC D, RC K, int i, int j, out char symbol)
        {
            if (A.r == i && A.c == j)
            {
                symbol = 'A';
            }
            else if (B.r == i && B.c == j)
            {
                symbol = 'B';
            }
            else if (C.r == i && C.c == j)
            {
                symbol = 'C';
            }
            else if (D.r == i && D.c == j)
            {
                symbol = 'D';
            }
            else if (K.r == i && K.c == j)
            {
                symbol = 'K';
            }
            else if ((i + j) % 2 == 0)
            {
                symbol = '+';
            }
            else
            {
                symbol = '-';
            }
        }
    }
}
