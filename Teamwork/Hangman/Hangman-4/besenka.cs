using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HangMan
{

	// bolime glavata. vcera pih egati gadnoto vino. nikoga poveche vino i vodka, obeshtavammmmmmm@@$#$%#&^#
    class besenka
    {
        static ScoreBoardPosition[] scoreBoard = new ScoreBoardPosition[5];
        static private Random random = new Random();
        static private string[] words = {"computer", "programmer", "software", "debugger", "compiler", 
                                            "developer", "algorithm", "array", "method", "variable"};
        private string currentWord;
        private char[] PlayersWord;
        private bool cheated;
        int mistakes;
        int lettersLeft;

        public besenka() 
        {
            int wordNumber = random.Next(0, 10);
            this.currentWord = words[wordNumber];
            this.PlayersWord = new char[currentWord.Length];
            for (int i = 0; i < PlayersWord.Length; i++)
            {
                PlayersWord[i] = '_';
            }
            this.cheated = false;
            this.mistakes = 0;
            this.lettersLeft = PlayersWord.Length;
            for (int i = 0; i < 5; i++)
            {
                scoreBoard[i] = new ScoreBoardPosition(string.Empty, 999);
            }
        }

        public void printWord() 
        {
            Console.WriteLine();
            Console.Write("The secret word is:");
            foreach (var letter in PlayersWord)
            {
                Console.Write(letter+" ");
            }
            Console.WriteLine();
        }
        public void help ()
        {
            int toBeRevealed;
            toBeRevealed=Array.IndexOf(PlayersWord, '_');
            PlayersWord[toBeRevealed] = currentWord[toBeRevealed];
            this.cheated = true;
        }
        public bool Guess(char letter) 
        {
            int guessed = 0;
            for (int i = 0; i < currentWord.Length; i++)
            {
                if (currentWord[i] == letter && PlayersWord[i]=='_') 
                {
                    guessed++;
                    PlayersWord[i] = letter;
                }
            }
            if (guessed > 0)
            {
                this.lettersLeft = this.lettersLeft - guessed;
                Console.WriteLine("you guessed {0} letters", guessed);
                if (this.lettersLeft == 0)
                {
                    return true;
                }
            }
            else 
            {
                Console.WriteLine("letter not found");
                this.mistakes++;
            }
            return false;
        }
        public void End() 
        {
            Console.WriteLine("Congratulations! You guessed the word");
            if (this.cheated == false)
            {
                for (int i = 0; i < 5; i++)
                {
                    if (scoreBoard[i].Name==string.Empty || this.mistakes < scoreBoard[i].Mistakes)
                    {
                        Console.WriteLine("Congratulations! You made the scoreboard");
                        Console.Write("Enter your name: ");
                        string playersName = Console.ReadLine();
                        if (scoreBoard[i].Name == string.Empty)
                        {
                            scoreBoard[i].Name = playersName;
                            scoreBoard[i].Mistakes = this.mistakes;



                        }
                        else
                        {
                            scoreBoard[4].Name = playersName;
                            scoreBoard[4].Mistakes = this.mistakes;
                        }
                        Array.Sort(scoreBoard);
                        return;
                    }
                }
            }
            else 
            {
                Console.WriteLine("You cheated");
            }
        }

        public void ShowScoreboard() 
        {
            Console.WriteLine();
            for (int i = 0; i < scoreBoard.Length; i++)
            {
                if (scoreBoard[i] != default(ScoreBoardPosition))
                {


                    Console.WriteLine("{0} --> {1} - {2} mistakes", i+1, scoreBoard[i].Name, scoreBoard[i].Mistakes);
                }
            }
            Console.WriteLine();
        }

        public void restart() 
        {
            int wordNumber = random.Next(0, 11);
            this.currentWord = words[wordNumber];
            this.PlayersWord = new char[currentWord.Length];
            for (int i = 0; i < PlayersWord.Length; i++)
            {
                PlayersWord[i] = '_';
            }
            this.cheated = false;
            this.mistakes = 0;
            this.lettersLeft = PlayersWord.Length;
        }
    }
}
