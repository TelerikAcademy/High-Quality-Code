using System;

namespace BattleField
{
    class Battlefield
    {
        //poLeto za biTka


        private char[,] gameField;
        public Battlefield()
        {
            gameField = null;
        }
        public void Start()
        {

            Console.WriteLine(@"Welcome to ""Battle Field"" game. ");
            int size = 0;
            string readBuffer = null;


            Console.Write("Enter battle field size: n=");
            readBuffer = Console.ReadLine();

            while (!int.TryParse(readBuffer, out size))
            {
                Console.WriteLine("Wrong format!");
                Console.Write("Enter battle field size: n=");

            }

            if (size > 10 || size <= 0)
            { Start(); }
            else{

                gameField = GameServices.GenerateField(size);
                StartInteraction();
            }
        }

        private void StartInteraction()
        {
            string readBuffer = null;
            int blownMines = 0;
            for (int i = 0; i < 50; i++)
                Console.WriteLine();


            while (GameServices.ContainsMines(gameField))
            {
                GameServices.PokajiMiRezultata(gameField);
                Console.Write("Please enter coordinates: ");
                readBuffer = Console.ReadLine();
                Mine mineToBlow = 
                    
                    
                    GameServices.ExtractMineFromString(readBuffer);

                while (mineToBlow == null)
                {
                    Console.Write("Please enter coordinates: ");
                    readBuffer = Console.ReadLine();
                    mineToBlow = GameServices.ExtractMineFromString(readBuffer);
                }

                if (!GameServices.IsValidMove(gameField, mineToBlow.X, mineToBlow.Y))
                {
                    Console.WriteLine("Invalid move!");
                    continue;
                }

                GameServices.Гърми(gameField, mineToBlow);
                blownMines++;
            }

            GameServices.PokajiMiRezultata(gameField);
            Console.WriteLine("Game over. Detonated mines: {0}", blownMines);
        }
    }
}
