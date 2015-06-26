using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hangman
{
    class Word
    {
        private string w;
        private System.Text.StringBuilder PrintedWord = new System.Text.StringBuilder();

        public void SetPlayedWord(string theWord)
        {
            this.w = theWord;
        }

        public string GetPlayedWord()
        {
            return this.w;
        }

        public void SetPrintedWord(System.Text.StringBuilder theWord)
        {
            this.PrintedWord = theWord;
        }

        public string GetPrintedWord()
        {
            return this.PrintedWord.ToString();
        }

        public bool Isletter(char Theletter)
        {
            if (char.ToLower(Theletter) >= 'a' && char.ToLower(Theletter) <= 'z')
                return true;
            else
                return false;
        }

        public bool CheckForLetter(char TheLetter)
        {
            if (w.Contains(char.ToLower(TheLetter)))
            {
                return true;
            }
            else return false;
        }

        public string WriteTheLetter(char TheLetter)
        {

            for (int WordLenght = 0; WordLenght < w.Length - 1; WordLenght++)
            {
                if (this.w.IndexOf(char.ToLower(TheLetter), WordLenght) >= 0)
                {
                    this.PrintedWord[this.w.IndexOf(char.ToLower(TheLetter), WordLenght) * 2] = TheLetter;
                }
            }

            return PrintedWord.ToString();
        }

        public int NumberOfInput(char TheLetter)
        {
            int Number = 0;
            for (int WordLenght = 0; WordLenght < w.Length; WordLenght++)
            {
                if (this.w[WordLenght].Equals(char.ToLower(TheLetter))) 
                Number++;
            }
            return Number;
        }
    }
}

