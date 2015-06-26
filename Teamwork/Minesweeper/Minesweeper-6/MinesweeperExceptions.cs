using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MinesweeperProject
{
    class InvalidCellException : Exception
    {
        public InvalidCellException()
            : base("Invalid cell!")
        {
        }
        public InvalidCellException(string message)
            : base(message)
        {
        }
    }

    class IllegalMoveException : Exception
    {
        public IllegalMoveException()
            : base("Illegal move!")
        {
        }

        public IllegalMoveException(string message)
            : base(message)
        {
        }
    }

    class CommandUnknownException : Exception
    {
        public CommandUnknownException()
            : base("Command unknown!")
        {
        }

        public CommandUnknownException(string message)
            : base(message)
        {
        }
    }


}

