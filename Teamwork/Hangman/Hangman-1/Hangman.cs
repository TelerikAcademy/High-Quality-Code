using System;

class Hangman
{
    static void Main()
    {
        ScoreBoard scoreBoard = new ScoreBoard();
        besenica game = new besenica();
        Console.WriteLine("Welcome to “Hangman” game. Please try to guess my secret word.");
        string command = null;
        do
        {
            Console.WriteLine();
            game.PrintCurrentProgress();
            if (game.isOver())
            {
                if (game.HelpUsed)
                {
                    Console.WriteLine("You won with {0} mistake(s) but you have cheated." +
                        " You are not allowed to enter into the scoreboard.", game.Mistackes);
                }
                else
                {
                    if (scoreBoard.GetWorstTopScore() <= game.Mistackes)
                    {
                        Console.WriteLine("You won with {0} mistake(s) but you score did not enter in the scoreboard",
                            game.Mistackes);
                    }
                    else
                    {
                        Console.Write("Please enter your name for the top scoreboard: ");
                        string name = Console.ReadLine();
                        scoreBoard.AddNewScore(name, game.Mistackes);
                        scoreBoard.Print();
                    }
                }
                game.ReSet();
            }
            else
            {
                Console.Write("Enter your guess: ");
                command = Console.ReadLine();
                command.ToLower();
                if (command.Length == 1)
                {
                    int occuranses = game.NumberOccuranceOfLetter(command[0]);
                    if (occuranses == 0)
                    {
                        Console.WriteLine("Sorry! There are no unrevealed letters “{0}”.", command[0]);
                    }
                    else
                    {
                        Console.WriteLine("Good job! You revealed {0} letter(s).", occuranses);
                    }
                }
                else
                {
                    ExecuteCommand(command, scoreBoard, game);
                }
            }
        } while (command != "exit");
    }

    static void ExecuteCommand(string command, ScoreBoard scoreBoard, besenica game) 
    {
        switch (command)
        {
            case "top":
                {
                    scoreBoard.Print();
                }
                break;
            case "help":
                {
                    char revealedLetter = game.RevealALetter();
                    Console.WriteLine("OK, I reveal for you the next letter '{0}'.", revealedLetter);
                }
                break;
            case "restart":
                {
                    scoreBoard.ReSet();
                    Console.WriteLine("\nWelcome to “Hangman” game. Please try to guess my secret word.");
                    game.ReSet();
                }
                break;
            case "exit":
                {
                    Console.WriteLine("Good bye!");
                    return;
                } break;
            default:
                {
                    Console.WriteLine("Incorrect guess or command!");
                }
                break;
        }
    }
}