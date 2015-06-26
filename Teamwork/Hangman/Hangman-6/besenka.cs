using System;

namespace Proekt_KPK
{
    class besenka
    {
		// hahaha, izpih edno kilo rakiya vcera i poznavam veche vsichki dumi4ki ot pyrvi puyt, muahahahahahahaaaaaaaa




        static string RandomizeAWord(string[] arr)
        {
            Random rand = new Random();

            int r = rand.Next(0, arr.Length);

            return arr[r];
        }   
        static void Main(string[] args)
        {
            string[] words = 
            {
                "computer", "programmer" , "software" , "debugger" , "compiler" , "developer" , "algorithm",
                "array" , "method" , "variable"
            };

            int l = 0;
            int m = 5;
            string word = RandomizeAWord(words);
            string dashWord = new String('-', word.Length);
            while (l < word.Length && m > 0)
            {
                string input = " ";
                bool incorrectInput = false;
                Console.WriteLine("The word to be guessed is:{0}", dashWord);
                int bukvata = 0;



                while ((bukvata < 'a' || bukvata > 'z') && (bukvata < 'A' || bukvata > 'Z'))
                {
                    if (incorrectInput)
                    {
                        Console.WriteLine("You've entered incorrect input!");
                    }
                      
                    Console.Write("Input a letter:");
                    input = Console.ReadLine();
                    bukvata = input[0];
                    if ((bukvata >= 'A' && bukvata <= 'Z') && bukvata != 0)
                    {
                        bukvata += 32;
                    }
                    incorrectInput = true;
                }
                  
                incorrectInput = false;
                bool isMatch = false;

                char[] tempArr = dashWord.ToCharArray();
                for (int i = 0; i < word.Length; i++)
                {
                    if (bukvata == word[i])
                    {
                        tempArr[i] = word[i];
                        isMatch = true;
                          
                        l++;
                    }
                }



                dashWord = new string(tempArr);

                if (isMatch)
                { Console.WriteLine("Good job! You revealed {0} of letters and your remaining errors is:{1}", l, m);
                }
                else
                {
                    m--;
                    Console.WriteLine("Sorry there are no unrevealed letters \"{0}\"). Your health is now {1}", (char)bukvata, m);
                }
            }

            if (m == 0)
            {
                Console.WriteLine("You lost the game. Try again.");
            }
            else
            {
                Console.WriteLine("You guessed the word \"{0}\" and you won. Congratulations!" , word);
            }
        }
    }
}