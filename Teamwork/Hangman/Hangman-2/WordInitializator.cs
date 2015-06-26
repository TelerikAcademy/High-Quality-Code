using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hangman
{

	// kojto mu se padne tozi kod da go opravya, moze da mi prati pozdravi na bate_goshko86@abv.bg. hahahaha@!@@!

    public class WordInitializator
    {
        //public string Word{get; set;}
        public static bool flag = false;
        public static int num1 = 0;
        static int num2 = 0;
        public static char[] allGuessedLettersOrderedByPositionInTheWord;//= new int[this.Word.Length];

        public static void BegginingOfTheGameInitialization(string word)
        {
            Console.WriteLine("Welcome to “Hangman” game. Please try to guess my secret word.");
            Console.WriteLine("Use 'top' to view the top scoreboard, 'restart' to start a new game,'help' to cheat and 'exit' to quit the game.");
            allGuessedLettersOrderedByPositionInTheWord = new char[word.Length];

            StringBuilder hiddenWord = new StringBuilder();

            for (int i = 0; i < word.Length; i++)
            {
                allGuessedLettersOrderedByPositionInTheWord[i] = '$';
                hiddenWord.Append("_ ");                
            }
            Console.WriteLine();
            Console.WriteLine("The secret word is: ");
            Console.WriteLine(hiddenWord);


            Console.WriteLine();
        }
        public static void RevealGuessedLetters(string word) // helper of the next function
        {
            StringBuilder partiallyHiddenWord = new StringBuilder();
            
            for (int i = 0; i < word.Length; i++)
            {
                if (allGuessedLettersOrderedByPositionInTheWord[i].Equals('$'))
                    partiallyHiddenWord.Append("_ ");
                else
                    partiallyHiddenWord.Append(allGuessedLettersOrderedByPositionInTheWord[i].ToString() + " ");
            }
            Console.WriteLine(partiallyHiddenWord);
        }
        
        public static void InitializationAfterTheGuess(string word, char charSupposed)
        {
            StringBuilder wordInitailized = new StringBuilder();
            int numberOfTheAppearancesOfTheSupposedChar = 0;
            if (allGuessedLettersOrderedByPositionInTheWord.Contains<char>(charSupposed))
                    {
                        Console.WriteLine("You have already revelaed the letter {0}", charSupposed);
                        return;
                    }
            for (int i = 0; i < word.Length; i++)
            {
                if (word[i].Equals(charSupposed))
                {                                     
                    allGuessedLettersOrderedByPositionInTheWord[i] = word[i];
                    numberOfTheAppearancesOfTheSupposedChar++;                    
                }
            }


            if (numberOfTheAppearancesOfTheSupposedChar == 0)
            {
                Console.WriteLine("Sorry! There are no unrevealed letters {0}", charSupposed);
                num2++;
            }
            else
            {
                Console.WriteLine("Good job! You revealed {0} letters.", numberOfTheAppearancesOfTheSupposedChar);
                num1 += numberOfTheAppearancesOfTheSupposedChar;
            }
            Console.WriteLine();
            if (num1 == word.Length) //check if the word is guessed
            {
                EndOfTheGameInitialization(word);
                CommandExecuter.Restart();

            }
            Console.WriteLine("The secret word is:");
            RevealGuessedLetters(word);
           

        }
        //clear()
        public static void EndOfTheGameInitialization(string word)
        {
            Console.WriteLine("You won with {0} mistakes.", num2);
            RevealGuessedLetters(word);
            Console.WriteLine();
            int positionOfTheFirstFreePositionInTheScoereboard = 4;
            for (int i = 0; i < 4; i++)
                if (CommandExecuter.scoreboard[i] == null)
                {
                    positionOfTheFirstFreePositionInTheScoereboard = i;
                    break;
                }

            if ((CommandExecuter.scoreboard[positionOfTheFirstFreePositionInTheScoereboard] == null //for free position
                  || num2 <= CommandExecuter.scoreboard[positionOfTheFirstFreePositionInTheScoereboard].NumberOfMistakes)//when the 4th pos is not free)
                  && flag == false)
                {

                    Console.WriteLine("Please enter your name for the top scoreboard:");
                    string playerName = Console.ReadLine();
                    CommandExecuter.PlayerMistakes newResult = new CommandExecuter.PlayerMistakes(playerName, num2);
                    CommandExecuter.scoreboard[positionOfTheFirstFreePositionInTheScoereboard] = newResult;
                    for (int i = positionOfTheFirstFreePositionInTheScoereboard; i > 0; i--)
                        if (CommandExecuter.scoreboard[i].Compare(CommandExecuter.scoreboard[i-1]) < 0)
                        {
                            //swap
                            CommandExecuter.PlayerMistakes temp = CommandExecuter.scoreboard[i];
                            CommandExecuter.scoreboard[i] =  CommandExecuter.scoreboard[i-1];
                            CommandExecuter.scoreboard[i-1] = temp;
                        }
                }
            num1 = 0;
            num2 = 0;




            flag = false;
            
        }
        //scoreboard a[5] s 5 rezultata
    }
}
