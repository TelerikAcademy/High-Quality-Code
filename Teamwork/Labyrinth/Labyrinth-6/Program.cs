using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EscapeFromLabyrinth
{
	// kakyv prekrasen proleten den - den za bygove i losh kod
	// chestito na kasmetliyata, popadnal na tazi boza!
    class Program
    {
        public static void Main(string[] args)
        {
            string welcomeMessage = "Welcome to “Labirinth” game. Please try to escape. Use 'top' to view the top scoreboard, 'restart' to start a new game and 'exit' to quit the game.";
            Labyrinth game = new Labyrinth();
            game.InitializeLabyrinth();
            Console.WriteLine(welcomeMessage);
            game.ShowLabyrinth();
            game.Move();
        }
    }
}
