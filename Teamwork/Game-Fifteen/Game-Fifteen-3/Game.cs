using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameFifteen
{
   public class Poziciq
   {//tova pazi poziciqta
      public int Row { get; set; }
      public int Column { get; set; }

      public Poziciq(int row, int column)
      {
         Row = row;
         Column = column;
      }
   }

   public class GameFifteen
   {
      private static void Generatematricata(string[,] matrica)
      {
         Random rnd = new Random();
         List<int> used = new List<int>();
         bool isFilled = false ;

         matrica[rnd.Next(4),rnd.Next(4)] = " ";

         for (int i = 0; i < 4; i++)
         {
            for (int j = 0; j < 4; j++)
            {

               isFilled = false;
               do
               {
                  int number = rnd.Next(1, 16);

                  if (matrica[i, j] == " ")
                  {
                     isFilled = true;
                  }
                  if (matrica[i, j] == null)
                  {
                     if (!used.Contains(number))
                     {
                        matrica[i, j] = number.ToString();
                        isFilled = true;
                        used.Add(number);
                     }
                  }

               }
               while (isFilled == false);
            }
         }
      }

      private static void Drawmatrica(string[,] matrica)
      {
         Console.WriteLine("  - - - - - -");

         for (int i = 0; i < 4; i++)
         {
            for (int j = 0; j < 4; j++)
            {
               if (j == 0)
               {
                  Console.Write("| {0,2} ", matrica[i, j]);
               }
               else if (j == 3)
               {
                  Console.WriteLine("{0,2} |", matrica[i, j]);
               }
               else
               {
                  Console.Write("{0,2} ", matrica[i, j]);
               }
            }
         }

         Console.WriteLine("  - - - - - -");
      }

      private static bool proverka(string[,] matrica)
      {
         int counter = 1;

         for (int i = 0; i < 4; i++)
         {
            for (int j = 0; j < 4; j++)
            {
               if (matrica[i, j] != counter.ToString())
               {
                  if (counter == 15 && matrica[i, j] == " ")
                  {
                     return true;
                  }
                  else
                  {
                     return false;
                  }
               }

               counter++;
            }
         }

         return true;

      
      }

      private static Poziciq findPrazno(string[,] matrica)
      {
         Poziciq result = new Poziciq(-1,-1);
         for (int i = 0; i < 4; i++)
         {
            for (int j = 0; j < 4; j++)
            {
               if (matrica[i,j] == " ")
               {
                   result = new Poziciq(i, j);
               }
            }
         }

         return result;
      }

      private static void ChangeAndDraw(string[,] matrica,int rowToChange,int columnToChange,int row,int column,string input)
      {
          matrica[rowToChange, columnToChange] = input;
          matrica[row, column] = " ";
          Drawmatrica(matrica);
      }

      private static Poziciq FindCurrentElement(string[,] matrica, string input)
      {
         for (int i = 0; i < 4; i++)
         {
               for (int j = 0; j < 4; j++)
               {
                  if (matrica[i, j] == input)
                  {
                     return new Poziciq(i, j);
                  }
               }
         }
         Console.WriteLine("Cheat ! Illegal command ! !");
         return null ;
      }

      static void Main(string[] argumentite)
      {
         string[,] matrica = new string[4, 4];
         int moves = 0;

         Console.WriteLine("Welcome to the game \"15\". Please try to arrange the numbers " +
             "sequentially .\nUse 'top' to view the top scoreboard, 'restart' to start a new " +
             "game and 'exit' \nto quit the game.\n\n\n"); 

         Generatematricata(matrica);
         Drawmatrica(matrica);

         while (!proverka(matrica))
         {
            Console.Write("Enter a number to move : ");
            string вход = Console.ReadLine();
            bool празно = false ;
           

            int rowEmptySpace = findPrazno(matrica).Row;
            int columnEmptySpace = findPrazno(matrica).Column;

            if (вход == "exit")
            {
               Console.WriteLine("Good bye !");
            }

            if (вход == "restart")
            {
               Console.WriteLine("Here is your new matrica, have a good play : \n\n\n");
               matrica = new string[4, 4];
               Generatematricata(matrica);
               Drawmatrica(matrica);
               moves = 0;
               continue;
            }

            if (вход == "top")
            {
               for (int i = 0; i < 5; i++)
               {
                  Console.WriteLine("Name : {0} , moves : {1} ", TopScores.igrachi[i], TopScores.hodove[i]);
               }
               continue;

            }

            if (FindCurrentElement(matrica, вход) == null)
            {
               continue;
            }

            int rowCurrentElement = FindCurrentElement(matrica, вход).Row;
            int columnCurrentElement = FindCurrentElement(matrica, вход).Column;

            

           

            for (int i = 0; i < 4; i++)
            {
               if (i == 0)
               {
                  if (rowCurrentElement - 1 < 0)
                  {
                     continue;
                  }
                  else
                  {
                     if (matrica[rowCurrentElement - 1, columnCurrentElement] == " ")
                     {
                        ChangeAndDraw(matrica, rowCurrentElement - 1, columnCurrentElement, rowCurrentElement, columnCurrentElement, вход);
                        празно = true;
                        moves++;
                     }
                  }
               }
               if (i == 1)
               {
                  if (rowCurrentElement + 1 > 3)
                  {
                     continue;
                  }
                  else
                  {
                     if (matrica[rowCurrentElement + 1, columnCurrentElement] == " ")
                     {
                        ChangeAndDraw(matrica, rowCurrentElement + 1, columnCurrentElement, rowCurrentElement, columnCurrentElement, вход);
                        празно = true;
                        moves++;
                     }
                  }
               }
               if (i == 2)
               {
                  if (columnCurrentElement - 1 < 0)
                  {
                     continue;
                  }
                  else
                  {
                     if (matrica[rowCurrentElement, columnCurrentElement - 1] == " ")
                     {
                        ChangeAndDraw(matrica, rowCurrentElement, columnCurrentElement - 1, rowCurrentElement, columnCurrentElement, вход);
                        празно = true;
                        moves++;
                     }
                  }
               }
               if (i == 3)
               {//tuka ne sym siguren kakvo e tova ama raboti!


                  if (columnCurrentElement + 1 > 3)
                  {


                     continue;
                  }


                  else

                  {

                     if (matrica[rowCurrentElement, columnCurrentElement + 1] == " ")
                     {
                      
                         ChangeAndDraw(matrica, rowCurrentElement, columnCurrentElement + 1, rowCurrentElement, columnCurrentElement, вход);
                        празно = true;
                        moves++;

                     }

                  }

               }

            }

            if ( ! 
                празно )
            {

               Console.WriteLine("Cheat ! Illegal command ! !");
            }

            }


         Console.WriteLine("Your result is {0} moves !", moves);

         for ( int i = 0 ; i < 5 ; i ++ )
         
         
         {  if (TopScores.hodove[i] > moves)
            {
               Console.WriteLine("Congratulations, you have just putted a new record");
               Console.Write("Please enter your name : ");
          
             TopScores.hodove[i] = moves ;
             
             TopScores.igrachi[i] = Console.ReadLine();
            }
         }
            

          }
      }
}
    

        

        
      
   

