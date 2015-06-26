using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace BattleFieldNamespace
{
    class BattleField
    {
        
        
        //tova e igrata
        //znam che vsichko e na edno ama taka e po lesno

        public Boolean proverka(int inputNumber) 
        {
            if ((inputNumber<1)||(inputNumber>10)) return false;
            else return true;
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
                    readThings, out readNumber
                    ))) { readNumber = -1; } 
               
            }
            while (!(proverka(readNumber)));

            return readNumber;

            ;
        }
        
        string[,] Field; 
        int n;
        
        public void CreateBattleTable()
        { 
            n=ReadCellsNumber();

            
            Field = new string[n,n];
              for (int i=0 ; i <= n-1 ; i++)

                for (int j = 0; j <= n-1; j++)
                { Field[i,j]="-";
                } 
        }

        private static int RandomNumber(int min, int max)
        {
            Random random = new Random();
            return Convert.ToInt32(random.Next(min,max));
        }

        int countOfNumberedCells = 0;

        public void FillInTheFields()
        {
            
            int row;
            int column;
            while (countOfNumberedCells+1 <= 0.3 *n*n) 
            {
                row = RandomNumber(0, n-1);
                column = RandomNumber(0, n-1);
                
            if (Field[row,column]=="-")
            {
                Field[row, column] = Convert.ToString(RandomNumber(1,5));
                countOfNumberedCells++;

            if (countOfNumberedCells>=
                0.15*n*n) 
                     {
                         int stopFilling = RandomNumber(0, 1);
                         if (stopFilling == 1) { break; }; 
            
                     };



              }
             ;
            }
            
        }

        int killedNumbers = 0;

        public void BombOne(int row,int column)
        {
            Field[row, column] = "X"; killedNumbers++;
            if ((row - 1 >= 0) && (column - 1 >= 0)) 
            {
                if ((Field[row - 1, column - 1] != "X") && (Field[row - 1, column - 1] != "-")) killedNumbers++; Field[row - 1, column - 1] = "X";
            };

            if ((row + 1 <= n - 1) && (column - 1 >= 0))
            {
                if ((Field[row + 1, column - 1] != "X") && (Field[row + 1, column - 1] != "-")) killedNumbers++; Field[row + 1, column - 1] = "X";
            };

            if ((row - 1 >= 0) && (column + 1 <= n - 1))
            {
                if ((Field[row - 1, column + 1] != "X") && (Field[row - 1, column + 1] != "-")) killedNumbers++; Field[row - 1, column + 1] = "X";
            };

            if ((row + 1 <= n - 1) && (column + 1 <= n - 1))
            {
                if ((Field[row + 1, column + 1] != "X") && (Field[row + 1, column + 1] != "-")) killedNumbers++; Field[row + 1, column + 1] = "X";
            };

        }

        public void BombTwo(int row, int column)
        {
            BombOne(row, column);

            if (row - 1 >= 0)
            {
                if ((Field[row - 1, column ] != "X") && (Field[row - 1, column] != "-")) killedNumbers++; Field[row - 1, column] = "X";
            };

            if (column - 1 >= 0)
            {
                if ((Field[row , column - 1] != "X") && (Field[row , column - 1] != "-")) killedNumbers++; Field[row , column - 1] = "X";
            };

            if (column + 1 <= n - 1)
            {
                if ((Field[row , column + 1] != "X") && (Field[row , column + 1] != "-")) killedNumbers++; Field[row , column + 1] = "X";
            };

            if (row + 1 <= n - 1)
            {
                if ((Field[row + 1, column] != "X") && (Field[row + 1, column] != "-")) killedNumbers++; Field[row + 1, column] = "X";
            };


        }

        public void BombThree(int row,int column)
        {
            BombTwo(row, column);
            
            if (row - 2 >= 0)
            {
                if ((Field[row - 2, column] != "X") && (Field[row - 2, column] != "-")) killedNumbers++; Field[row - 2, column] = "X";
            };

            if (column - 2 >= 0)
            {
                if ((Field[row, column - 2] != "X") && (Field[row, column - 2] != "-")) killedNumbers++; Field[row, column - 2] = "X";
            };

            if (column + 2 <= n - 1)
            {
                if ((Field[row, column + 2] != "X") && (Field[row, column + 2] != "-")) killedNumbers++; Field[row, column + 2] = "X";
            };

            if (row + 2 <= n - 1)
            {
                if ((Field[row + 2, column] != "X") && (Field[row + 2, column] != "-")) killedNumbers++; Field[row + 2, column] = "X";
            };

        }

        public void NekaGyrmi4(int row,int column)
        {
            BombThree(row, column);

            if ((row - 1 >= 0) && (column - 2 >= 0))
            {
                if ((Field[row - 1, column - 2] != "X") && (Field[row - 1, column - 2] != "-")) killedNumbers++; Field[row - 1, column - 2] = "X";
            };

            if ((row + 1 <= n - 1) && (column - 2 >= 0))
            {
                if ((Field[row + 1, column - 2] != "X") && (Field[row + 1, column - 2] != "-")) killedNumbers++; Field[row + 1, column - 2] = "X";
            };

            if ((row - 2 >= 0) && (column - 1 >= 0))
            {
                if ((Field[row - 2, column - 1] != "X") && (Field[row - 2, column - 1] != "-")) killedNumbers++; Field[row - 2, column - 1] = "X";
            };

            if ((row + 2 <= n - 1) && (column - 1 >= 0))
            {
                if ((Field[row + 2, column - 1] != "X") && (Field[row + 2, column - 1] != "-")) killedNumbers++; Field[row + 2, column - 1] = "X";
            };
            //

            if ((row - 1 >= 0) && (column + 2 <= n-1))
            {
                if ((Field[row - 1, column + 2] != "X") && (Field[row - 1, column + 2] != "-")) killedNumbers++; Field[row - 1, column + 2] = "X";
            };

            if ((row + 1 <= n - 1) && (column + 2 <= n-1))
            {
                if ((Field[row + 1, column + 2] != "X") && (Field[row + 1, column + 2] != "-")) killedNumbers++; Field[row + 1, column + 2] = "X";
            };

            if ((row - 2 >= 0) && (column + 1 <= n-1))
            {
                if ((Field[row - 2, column + 1] != "X") && (Field[row - 2, column + 1] != "-")) killedNumbers++; Field[row - 2, column + 1] = "X";
            };

            if ((row + 2 <= n - 1) && (column + 1 <= n-1))
            {
                if ((Field[row + 2, column + 1] != "X") && (Field[row + 2, column + 1] != "-")) killedNumbers++; Field[row + 2, column + 1] = "X";
            };
            
        }

        public void BombFive(int row,int column)
        {
            NekaGyrmi4(row, column);

            if ((row - 2 >= 0) && (column - 2 >= 0))
            {
                if ((Field[row - 2, column - 2] != "X") && (Field[row - 2, column - 2] != "-")) killedNumbers++; Field[row - 2, column - 2] = "X";
            };

            if ((row + 2 <= n - 1) && (column - 2 >= 0))
            {
                if ((Field[row + 2, column - 2] != "X") && (Field[row + 2, column - 2] != "-")) killedNumbers++; Field[row + 2, column - 2] = "X";
            };

            if ((row - 2 >= 0) && (column + 2 <= n - 1))
            {
                if ((Field[row - 2, column + 2] != "X") && (Field[row - 2, column + 2] != "-")) killedNumbers++; Field[row - 2, column + 2] = "X";
            };

            if ((row + 2 <= n - 1) && (column + 2 <= n - 1))
            {
                if ((Field[row + 2, column + 2] != "X") && (Field[row + 2, column + 2] != "-")) killedNumbers++; Field[row + 2, column + 2] = "X";
            };
        }
        
        public void InvalidMove()
        {
            Console.WriteLine("Invalid Move!");
            Console.WriteLine();
        }

        public void ViewTable()
        {
            Console.Write("   ");
            for (int k = 0; k <= n - 1; k++) { Console.Write(k + " "); }
            Console.WriteLine();
            Console.Write("   ");
            for (int k = 0; k <= n - 1; k++) { Console.Write("--"); }
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
        }

        int izgyrmqniBombi = 0;

        public void MineCell(int row,int column)
        {
            int cellNumber;

            if ((Field[row, column] == "X") || ((Field[row, column]) == "-"))  cellNumber=0;
            else  cellNumber = Convert.ToInt32(Field[row, column]);
            switch (cellNumber)
            {
                case 1: { BombOne(row, column); ViewTable(); izgyrmqniBombi++; break; };
                case 2: { BombTwo(row, column); ViewTable(); izgyrmqniBombi++; break; };
                case 3: { BombThree(row, column); ViewTable(); izgyrmqniBombi++; break; };
                case 4: { NekaGyrmi4(row, column); ViewTable(); izgyrmqniBombi++; break; };
                case 5: { BombFive(row, column); ViewTable(); izgyrmqniBombi++; break; };

                default: { InvalidMove(); break; };
            }
        }

        public bool Over()
        {
            if (killedNumbers == countOfNumberedCells) return true;
            else return false;
        }

        public bool OutOfAreaCoordinates(int row,int column)
        {
            if ((row >= 0) && (row <= n - 1) && (column >= 0) && (column <= n - 1))
            {
                return false;
            }
            return true;
        }

        public void GameSession()
        {
            CreateBattleTable();
            FillInTheFields();
            ViewTable();
           
            while (!(Over()))
            {
                Console.Write("Please Enter Coordinates : ");


                string inputRowAndColumn = Console.ReadLine();
                string[] rowAndColumnSplit = inputRowAndColumn.Split(' ');
                int row ;
                int column ;
                
                if ((rowAndColumnSplit.Length)<=0) { row= - 1;column = -1;}
                else
                {
                if (!(int.TryParse(rowAndColumnSplit[0],out row))) row = -1;
                if (!(int.TryParse(rowAndColumnSplit[1],out column))) column = -1;
                }
                
                if ((OutOfAreaCoordinates(row, column))) 
                
                {
                    Console.WriteLine("This Move Is Out Of Area."); }
                    else 
                {  
                    MineCell(row,column);
                };
            }



            Console.WriteLine("Game Over.Detonated Mines {0}",izgyrmqniBombi);

        } static void Main(string[] args)
        {

            BattleField BF=new BattleField();




            BF.GameSession();
             
            
        
        }
    }
}
