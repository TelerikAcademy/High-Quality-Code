using System;

class besenica
{
	// besenicata e egati tupata igra! ujasssssssssssss, spasete me ot besiloto!

    private string wordToGuess;
    private char[] guessedLetters;
    private int mistackes;
    private bool helpUsed;
    public besenica() 
    {
        ReSet();
    }



    public void ReSet()
    {
        this.wordToGuess = IzberiRandomWord();
        guessedLetters = new char[wordToGuess.Length];




        for (int i = 0; i < wordToGuess.Length; i++)
        {
            guessedLetters[i] = '_';
        }
        mistackes = 0;
        helpUsed = false;
    }

    public int Mistackes
    {
        get{return mistackes;}
    }
    public bool HelpUsed 
    {
        get { return helpUsed; }
    }
    public char RevealALetter() 
    {
        char toReturnt = char.MinValue;
        for (int i = 0; i < guessedLetters.Length; i++)
        {
            if (guessedLetters[i] == '_') 
            {
                guessedLetters[i] = wordToGuess[i];
                toReturnt = wordToGuess[i];
                helpUsed = true;
                break;
            }
        }
        return toReturnt;
    }


    public int NumberOccuranceOfLetter(char letter) 
    {
        int count = 0;
        for (int i = 0; i < wordToGuess.Length; i++)
        {
            if (wordToGuess[i] == letter) 
            {
                guessedLetters[i] = letter;
                count++;
            }
        }
        if (count == 0) { mistackes++; }
        return count;
    }

    public void PrintCurrentProgress() 
    {
        Console.Write("The secret word is: ");
        for (int i = 0; i < guessedLetters.Length; i++)
        {
            Console.Write("{0} ", guessedLetters[i]);
        }
        Console.WriteLine();
    }

    public bool isOver() 
    {
        for (int i = 0; i < guessedLetters.Length; i++)
        {
            if (guessedLetters[i] == '_') 
            {
     
				
				return false;
            }
        }
        return true;
    }


    private string[] words = {"computer", "programmer", "software", "debugger","compiler", "developer", "algorithm",
                                      "array", "method", "variable" };

    private Random randomGenerator = new Random();

    private string IzberiRandomWord()
    {




        int choice = randomGenerator.Next(words.Length);

        return words[choice];
    }


}
