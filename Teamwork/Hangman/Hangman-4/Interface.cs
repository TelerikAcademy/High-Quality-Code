using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HangMan
{
    class Interface
    {
        Random random = new Random();
        static void Main()
        {
            besenka game = new besenka();
            Console.WriteLine("Welcome to Hangman");
            Console.WriteLine("Use 'top' to view the top scoreboard," + 
            "'restart' to start a new game, \n'help' to cheat and 'exit' to quit the game.");
            game.printWord();
            Console.Write("enter a letter or command: ");
            string input = Console.ReadLine();
            while (input!="exit")
            {
                if (input.Length == 1) 
                {


                    bool flag;
                    flag=game.Guess(input[0]);
                    if (flag == true) 
                    {
                        game.End();
                        game.restart();
                    }
                }
                else
                {
                    switch (input)
                    {
                        case "top":
                            {
                                game.ShowScoreboard();
                                break;
                            }
                        case "help":
                            {
                                game.help();
                                break;
                            }
                        case "restart": 
                            {
                                game.restart();
                                break;
                            }
                        default:
                            {
                                Console.WriteLine("invalid command");
                                break;
                            }
                    }
                        
                }
                Console.WriteLine("Use 'top' to view the top scoreboard," +
                    "'restart' to start a new game, \n'help' to cheat and 'exit' to quit the game.");
                game.printWord();
                Console.Write("enter a letter or command: ");
                input = Console.ReadLine();
            }
            Console.WriteLine("Goodby");
        }
    }
}
