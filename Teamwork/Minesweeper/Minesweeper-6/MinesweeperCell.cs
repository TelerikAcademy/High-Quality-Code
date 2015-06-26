using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MinesweeperProject
{
    class MinesweeperCell
    {
        private char val = '?';
        private bool revealed = false;
        //constructors
        public MinesweeperCell(char val, bool revealed)
        {
            this.Value = val;
            this.Revealed = revealed;
        }
        public MinesweeperCell()
        {
            this.Value = ' ';
            this.Revealed = false;
        }
        //properties
        public char VisibleValue
        {
            get
            {
                char result;

                if (revealed == false)// if not revealed then return ? else actual value
                    result = '?';
                else
                    result = val;

                return result;
            }
        }
        public char Value
        { 
            get
            {
                return val;
            }
            set
            {
                val = value;
            }
        }
        public bool Revealed 
        { 
            get
            {
                return revealed;
            } 
            set
            {
                revealed = value;
            }
        }
        //methods
        public void Reveal()
        {
            this.Revealed = true;
        }
    }
}
