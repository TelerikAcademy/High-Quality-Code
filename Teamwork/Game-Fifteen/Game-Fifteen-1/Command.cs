using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameFifteenProject
{
    static class Command
    {
        private enum Commands { restart, top, exit };

        public static string CommandType(string input)
        {
            string inputToLower = input.ToLower();
            string output;

            if (inputToLower == Commands.exit.ToString() || inputToLower == Commands.restart.ToString() || inputToLower == Commands.top.ToString())
            {
                output = inputToLower;
            }
            else
            {
                throw new ArgumentException("Invalid Command!");
            }

            return output;
        }

    }
}
