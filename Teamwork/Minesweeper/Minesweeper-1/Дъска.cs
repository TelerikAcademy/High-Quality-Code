using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mini
{

    class Дъска
    {
        private const int SizeX = 5;
        private const int SizeY = 10;
        private const int numberOfMines = 15;

        private char[,] display;
        private bool[,] hasMine;
        private bool[,] shown;
        private int[,] numberOfNeighbourMines;
        internal int RevealedCells { get; set; }
    
        public Дъска()
        {
            display = new char[SizeX, SizeY];
            hasMine = new bool[SizeX, SizeY];
            shown = new bool[SizeX, SizeY];
            numberOfNeighbourMines = new int[SizeX, SizeY];
            InitializeBoardForDisplay();
            PutMines();
        }

        private void PutMines()
        {
            Random generator = new Random();

            int actualNumberOfMines = 0;
            while (actualNumberOfMines < numberOfMines)
            {
                if(PlaceMine(generator.Next(SizeX), generator.Next(SizeY)))
                    actualNumberOfMines++;
            }
        }

        internal bool proverka(int x, int y)
        {
            return 0 <= x && x < SizeX && 0 <= y && y < SizeY;
        }

        private bool PlaceMine(int x, int y)
        {
            if (proverka(x, y) && !hasMine[x, y])
            {
                hasMine[x, y] = true;
                for (int xx = -1; xx <= 1; xx++)
                    for (int yy = -1; yy <= 1; yy++)
                    {
                        if (((xx != 0) || (yy != 0)) && proverka(x + xx, y + yy))
                            numberOfNeighbourMines[x + xx, y + yy]++;
                    }
                return true;
            }
            return false;
        }

        private void InitializeBoardForDisplay()
        {
            for (int i = 0; i < SizeX; i++)
                for (int j = 0; j < SizeY; j++)
                    display[i, j] = '?';
        }

        internal void Display()
        {

            for (int i = 0; i < 4; i++)
                Console.Write(" ");
            for (int i = 0; i < SizeY; i++)
                Console.Write(i + " ");
            Console.WriteLine();
            for (int i = 0; i < 4; i++)
                Console.Write(" ");
            for (int i = 0; i < 2*SizeY; i++)
                Console.Write('-');
            Console.WriteLine();
            for (int i = 0; i < SizeX; i++)
            {
                Console.Write(i + " | ");
                for (int j = 0; j < SizeY; j++)
                    Console.Write(display[i, j] + " ");
                Console.WriteLine("|");
            }
            for (int i = 0; i < 4; i++)
                Console.Write(" ");
            for (int i = 0; i < 2 * SizeY; i++)
                Console.Write("-");
            Console.WriteLine();
        }

        internal bool proverka3(int x, int y)
        {
            return hasMine[x, y];
        }

        internal void RevealBlock(int x, int y)
        {
            display[x, y] = Convert.ToChar(numberOfNeighbourMines[x, y].ToString());
            RevealedCells++;
            shown[x, y] = true;
            if (display[x, y] == '0')
            {
                for(int xx = -1; xx <= 1; xx++)
                    for (int yy = -1; yy <= 1; yy++)
                    {
                        int newX = x + xx;
                        int newY = y + yy;
                        if (proverka(newX, newY) && shown[newX, newY] == false)
                            RevealBlock(newX, newY);
                    }
            }
        }

        internal void Край(int x, int y)
        {
            for (int i = 0; i < SizeX; i++)
                for (int j = 0; j < SizeY; j++)
                {
                    if (!shown[i, j])
                        display[i, j] = '-';
                    if (hasMine[i, j])
                        display[i, j] = '*';
                }
        }

        internal bool proverka2(int x, int y)
        {
            return shown[x, y];
        }
    }
}
