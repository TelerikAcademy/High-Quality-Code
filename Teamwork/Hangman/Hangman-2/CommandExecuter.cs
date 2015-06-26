using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hangman
{
    public class CommandExecuter
    {
        public class PlayerMistakes
        {
            public string PlayerName { get; set; }
            public int NumberOfMistakes { get; set; }
            public PlayerMistakes(string playerName, int numberOfMistakes)
            {
                this.PlayerName = playerName;
                this.NumberOfMistakes = numberOfMistakes;
            }
            public int Compare(PlayerMistakes otherPlayer)
            {
                if (this.NumberOfMistakes <= otherPlayer.NumberOfMistakes)
                    return -1;
                else
                    return 1;// the newer one replaces the older



            }

        }
        public static PlayerMistakes [] scoreboard  = new PlayerMistakes[5];

        public static void RevealTheNextLetter(string word)
        {
            char firstUnrevealedLetter='$';
            
            for (int i = 0; i < word.Length; i++)
                if (WordInitializator.allGuessedLettersOrderedByPositionInTheWord[i] .Equals('$'))
                {
                    firstUnrevealedLetter = word[i];
                    break;
                }
            Console.WriteLine("OK, I reveal for you the next letter {0}.", firstUnrevealedLetter );
            WordInitializator.InitializationAfterTheGuess (word, firstUnrevealedLetter);
            //flag - not in the chart
            WordInitializator.flag = true;
                


        }
        public static void Restart()
        {
            Console.WriteLine();
            string word = WordSelector.SelectRandomWord();
            //Console.WriteLine(word);
            WordInitializator.BegginingOfTheGameInitialization(word);
            WordGuesser wg = new WordGuesser() { Word = word };
            while (WordInitializator.num1 < word.Length && WordGuesser.IsExited == false)
                wg.GuessLetter();


        }
        public static void TopResults()
        {
            Console.WriteLine();
            for (int i = 0; i < 5; i++)


                if(scoreboard[i] != null)
                    Console.WriteLine("{0}. {1} ---> {2}", i+1, scoreboard[i].PlayerName, scoreboard[i].NumberOfMistakes);
            Console.WriteLine();
        }
        public static void Exit()
        {
            Console.WriteLine("Good bye!");
            WordGuesser.IsExited = true;
            
            return;
        }

    }
}
