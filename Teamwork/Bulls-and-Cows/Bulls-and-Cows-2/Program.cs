using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bikove
{
    class Program
    {
	// ne szm sigurna dali raboti,ama e testvano 100% vcera do 3 4asa sutrinta
        public const string ScoresFile = "scores.txt";
        public const string WelcomeMessage = "Welcome to “Bulls and Cows” game. Please try to guess my secret 4-digit number.\nUse 'top' to view the top scoreboard, 'restart' to start a new game and 'help' to cheat and 'exit' to quit the game.";
        public const string WrongNumberMessage = "Wrong number!";
        public const string InvalidCommandMessage = "Incorrect guess or command!";
        public const string NumberGuessedWithoutCheats = "Congratulations! You guessed the secret number in {0} {1}.\nPlease enter your name for the top scoreboard: ";
        public const string NumberGuessedWithCheats = "Congratulations! You guessed the secret number in {0} {1} and {2} {3}.\nYou are not allowed to enter the top scoreboard.";
        public const string GoodBuyMessage = "Good bye!";

        static void Main(string[] args)
        {
            BullsAndCowsNumber bullsAndCowsNumber = new BullsAndCowsNumber();
            Scoreboard scoreBoard = new Scoreboard(ScoresFile);
            Console.WriteLine(WelcomeMessage);
            while (true)
            {
                Console.Write("Enter your guess or command: ");
                string command = Console.ReadLine();
                if (command == "exit")
                {
                    Console.WriteLine(GoodBuyMessage);
                    break;
                }
                switch (command)
                {
                    case "top":
                        {
                            Console.Write(scoreBoard);
                            break;
                        }
                    case "restart":
                        {
                            Console.WriteLine();
                            Console.WriteLine(WelcomeMessage);
                            bullsAndCowsNumber = new BullsAndCowsNumber();
                            break;
                        }
                    case "help":
                        {
                            Console.WriteLine("The number looks like {0}.", bullsAndCowsNumber.GetCheat());
                            break;
                        }
                    default:
                        {
                            try
                            {
                                rezultat guessResult = bullsAndCowsNumber.TryToGuess(command);
                                if (guessResult.Bulls == 4)
                                {
                                    if (bullsAndCowsNumber.cheats == 0)
                                    {
                                        Console.Write(NumberGuessedWithoutCheats, bullsAndCowsNumber.GuessesCount, bullsAndCowsNumber.GuessesCount == 1 ? "attempt" : "attempts");
                                        string name = Console.ReadLine();
                                        scoreBoard.AddScore(name, bullsAndCowsNumber.GuessesCount);
                                    }
                                    else
                                    {
                                        Console.WriteLine(NumberGuessedWithCheats,
                                            bullsAndCowsNumber.GuessesCount, bullsAndCowsNumber.GuessesCount == 1 ? "attempt" : "attempts",
                                            bullsAndCowsNumber.cheats, bullsAndCowsNumber.cheats == 1? "cheat" : "cheats");
                                    }
                                    Console.Write(scoreBoard);
                                    Console.WriteLine();
                                    Console.WriteLine(WelcomeMessage);
                                    bullsAndCowsNumber = new BullsAndCowsNumber();
                                }
                                else
                                {
                                    Console.WriteLine("{0} {1}", WrongNumberMessage, guessResult);
                                }
                            }
                            catch (ArgumentException)
                            {
                                Console.WriteLine(InvalidCommandMessage);
                            }
                            break;
                        }
                }
            }
            scoreBoard.SaveToFile(ScoresFile);
        }
    }
}
