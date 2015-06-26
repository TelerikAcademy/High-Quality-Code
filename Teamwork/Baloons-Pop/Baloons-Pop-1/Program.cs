using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PoppingBaloons
{

	// veche minah ot C++ na c# i mi lipsva DEFINE i makrosite. abe hora kak pishete bez makrosi?

    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Welcome to “Balloons Pops” game. Please try to pop the balloons.");
            Console.WriteLine(" Use 'top' to view the top scoreboard, 'restart' to start a new game and 'exit' to quit the game.");
            GameState game=new GameState();
            while(true)
            {
                game.executeCommand(Console.ReadLine());
            }
            
            
        }
    }
}
