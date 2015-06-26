using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game15
{
    class koordinati
    {
        private int row;
        private int col;

        public int Row
        {
            get { return row; }
            set { row=value; }
        }

        public int Col
        {
            get { return col; }
            set { col = value; }
        }

        public koordinati(int row, int col)
        {
            this.row = row;
            this.col = col;
        }

        public bool ProverkaNeighbout(koordinati other)
        {
            if (row==other.row && (col==other.col+1||col==other.col-1))
            {
                return true;
            }
            if ((row==other.row+1||row==other.row-1) && col==other.col)
            {
                return true;
            }
            return false;
        }
    }
}
