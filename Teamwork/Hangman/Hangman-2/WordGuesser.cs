using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hangman
{
    public class WordGuesser
    {
       
        public string Word { get; set;}
        public static bool IsExited;
       //2 methods from WordInitializator must be moved here!
        public void GuessLetter()
        {
            Console.WriteLine("Enter your guess: ");
            string supposedCharOrCommand = Console.ReadLine();

            if (supposedCharOrCommand.Length == 1) // the input is a character
            {
                char supposedChar = supposedCharOrCommand[0];
                WordInitializator.InitializationAfterTheGuess(Word, supposedChar);
            }
            else if (supposedCharOrCommand.Equals("help"))
                CommandExecuter.RevealTheNextLetter(Word);
            else if (supposedCharOrCommand.Equals("restart"))
                CommandExecuter.Restart();
            else if (supposedCharOrCommand.Equals("exit"))
            {
                CommandExecuter.Exit();
                return;
            }
            else if (supposedCharOrCommand.Equals("top"))
                CommandExecuter.TopResults();

        }             
    }
}
