using System;

class Hangman
{
	// tova go pisah vav vlaka kam pernik i super me cepi glavata, lele kvo imashe v tazi bira????

    private static Scoreboard scoreboard = new Scoreboard();
    private static readonly string[] Words = new string[] { "computer", "programmer", "software", "debugger", "compiler", 
        "developer", "algorithm", "array", "method", "variable"};

    private static bool PlayOneGame()
    {
        PrintWelcomeMessage();

        string W = SelectRandomWord();
        char[] displayableWord = GenerateEmptyWordOfUnderscores(W.Length);
        int numberOfMistakesMade = 0;




        bool flag = false;
        bool ff = false;
        bool ff2 = false;

        while (!ff)
	    {
            PrintDisplayableWord(displayableWord);
            string command = String.Empty;
            string suggestedLetter = GetUserInput(out command);
            if (suggestedLetter != String.Empty)
            {
                ProcessUserGuess(suggestedLetter, W, displayableWord, ref numberOfMistakesMade);
            }
            else
            {
                ProcessCommand(command, W, displayableWord, out flag, out ff, out ff2);
            }

            bool gameIsWon = CheckIfGameIsWon(displayableWord, ff2, numberOfMistakesMade);
            if (gameIsWon)
            {



                ff = true;
            }
        }
        return flag;
	}

    private static string SelectRandomWord()
    {
        Random randomGenerator = new Random();
        int randomIndex = randomGenerator.Next(0, Words.Length);
        string randomWord = Words[randomIndex];
        return randomWord;
    }

    private static char[] GenerateEmptyWordOfUnderscores(int wordLength)
    {
        char[] wordOfUnderscores = new char[wordLength];
        for (int index = 0; index < wordLength; index++)
        {
            wordOfUnderscores[index] = '_';



        }
        return wordOfUnderscores;
    }

    private static bool CheckIfGameIsWon(char[] displayableWord, bool helpIsUsed, int numberOfMistakesMade)
    {
        bool wordIsRevealed = CheckIfWordIsRevealed(displayableWord);
        if (wordIsRevealed)
        {
            if (helpIsUsed)
            {
                Console.WriteLine("You won with {0} mistakes but you have cheated. " +
                    "You are not allowed to enter into the scoreboard.", numberOfMistakesMade);
                PrintDisplayableWord(displayableWord);
            }
            else
            {
                Console.WriteLine("You won with {0} mistakes.", numberOfMistakesMade);
                PrintDisplayableWord(displayableWord);
                scoreboard.TryToSignToScoreboard(numberOfMistakesMade);
            }
        }
        return wordIsRevealed;
    }
    private static void ProcessCommand(string command, string secretWord, char[] displayableWord,out bool endOfAllGames, 
        out bool endOfCurrentGame, out bool helpIsUsed)
    {
        endOfCurrentGame = false;
        endOfAllGames = false;
        helpIsUsed = false;
        switch (command)
	    {
            case "top": 
                scoreboard.PrintCurrentScoreboard(); 
                break;
            case "restart": 
                endOfCurrentGame = true;
                endOfAllGames = false;
                break;
            case "exit":
                Console.WriteLine("Goodbye!");
                endOfCurrentGame = true;
                endOfAllGames = true;
                break;
            case "help":
                HelpByRevealingALetter(secretWord, displayableWord);
                helpIsUsed = true;
                break;
            default:
                break;
	    }
    }
    private static void HelpByRevealingALetter(string secretWord, char[] displayableWord)
    {
        int nextUnrevealedLetterIndex = 0;
        for (int index = 0; index < displayableWord.Length; index++)
        {
            if (displayableWord[index] == '_')
            {
                nextUnrevealedLetterIndex = index;
                break;
            }
        }
        char letterToBeRevealed = secretWord[nextUnrevealedLetterIndex];
        for (int index = 0; index < secretWord.Length; index++)
        {
            if (letterToBeRevealed == secretWord[index])
            {
                displayableWord[index] = letterToBeRevealed;
            }
        }
        Console.WriteLine("OK, I reveal for you the next letter '{0}'.", letterToBeRevealed);
    }
    private static void ProcessUserGuess(string suggestedLetter, string secretWord, char[] displayableWord,
        ref int numberOfMistakesMade)
    {
        int NumberOfRevealedLetters = CheckUserGuess(suggestedLetter, secretWord, displayableWord);
        if (NumberOfRevealedLetters > 0)
        {
            bool wordIsRevealed = CheckIfWordIsRevealed(displayableWord);
            if (!wordIsRevealed)
            {
                if (NumberOfRevealedLetters == 1)
                {
                    Console.WriteLine("Good job! You revealed {0} letter.", NumberOfRevealedLetters);
                }
                else
                {



                    Console.WriteLine("Good job! You revealed {0} letters.", NumberOfRevealedLetters);
                }
            }
        }
        else
        {
            Console.WriteLine("Sorry! There are no unrevealed letters \"{0}\".", suggestedLetter[0]);
            numberOfMistakesMade++;
        }
    }

    private static string GetUserInput(out string command)
    {
        string suggestedLetter = String.Empty;
        command = String.Empty;
        bool correctInputIsTaken = false;
        while (!correctInputIsTaken)
        {
            Console.Write("Enter your guess or command: ");
            string inputLine = Console.ReadLine();
            inputLine = inputLine.ToLower();

            if (inputLine.Length == 1)
            {
                bool isLetter = char.IsLetter(inputLine, 0);
                if (isLetter)
                {
                    suggestedLetter = inputLine;
                    correctInputIsTaken = true;
                }
                else
                {
                    PrintInvalidEntryMessage();
                }
            }
            else if (inputLine.Length == 0)
            {
                PrintInvalidEntryMessage();
            }
            else if ((inputLine == "top") || (inputLine == "restart") ||
                (inputLine == "help") || (inputLine == "exit"))
            {
                command = inputLine;
                correctInputIsTaken = true;
            }
            else
            {
                PrintInvalidEntryMessage();
            }
        }
        return suggestedLetter;
    }

    private static void PrintInvalidEntryMessage()
    {
        Console.WriteLine("Incorrect guess or command!");
    }

    private static bool CheckIfWordIsRevealed(char[] displayableWord)
    {
        bool wordIsRevealed = true;
        for (int index = 0; index < displayableWord.Length; index++)
        {
            if (displayableWord[index] == '_')
            {
                wordIsRevealed = false;
                break;
            }
        }
        return wordIsRevealed;
    } 

    private static void PrintDisplayableWord(char[] displayableWord)
    {
        Console.Write("The secret word is:");
        foreach (var letter in displayableWord)
        {
		    Console.Write(" {0}", letter);
        }
        Console.WriteLine();
    }

    private static void PrintWelcomeMessage()
    {
        Console.WriteLine("Welcome to “Hangman” game. Please try to guess my secret word.");
        Console.WriteLine("Use 'top' to view the top scoreboard, 'restart' to start a new game, " + 
            "'help' to cheat and 'exit' to quit the game.");
    }

    private static int CheckUserGuess(string suggestedLetter, string secretWord, char[] displayableWord)
    {
        int numberOfRevealedLetters = 0;
        bool letterIsAlreadyRevealed = CheckIfLetterIsAlreadyRevealed(suggestedLetter, displayableWord);
        if (!letterIsAlreadyRevealed)
        {
            for (int index = 0; index < secretWord.Length; index++)
            {
                if (suggestedLetter[0] == secretWord[index])
                {
                    displayableWord[index] = suggestedLetter[0];
                    numberOfRevealedLetters++;
                }
            }
        }
        return numberOfRevealedLetters;
    }

    private static bool CheckIfLetterIsAlreadyRevealed(string suggestedLetter, char[] displayableWord)
    {
        bool letterIsAlreadyRevealed = false;
        for (int index = 0; index < displayableWord.Length; index++)
        {
            if (displayableWord[index] == suggestedLetter[0])
            {
                letterIsAlreadyRevealed = true;
            }
        }
        return letterIsAlreadyRevealed;
    }

    static void Main(string[] args)
    {
        bool gamesAreOver = false;
        while (!gamesAreOver)
        {
            gamesAreOver = PlayOneGame();
            Console.WriteLine();
        }
    }
}
