using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Labyrinth
{
    class Cell
    {
        public const char CELL_EMPTY_VALUE = '-';
        public const char CELL_WALL_VALUE = 'X';
        public int Row { get; set; }
        public int Col { get; set; }
        public char ValueChar { get; set; }

        public Cell(int row, int col, char value)
        {
            this.Row = row;
            this.Col = col;
            this.ValueChar = value;
        }

        public bool IsEmpty()
        {
            if(this.ValueChar == CELL_EMPTY_VALUE)
            {
                return true;
            }
            return false;
        }
    }
}
