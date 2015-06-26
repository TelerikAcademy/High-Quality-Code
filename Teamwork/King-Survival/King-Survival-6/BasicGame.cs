using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KingSurvivalGame
{
    class BasicGame
    {
        protected static int[,] edges = 
        {
            { 2, 4 }, { 2, 18 }, { 9, 4 }, { 9, 18 }
        };

        protected static int counter = 0;

        protected static string[] validKingInputs = { "KUL", "KUR", "KDL", "KDR" };

        protected static string[] validAPawnInputs = { "ADL", "ADR" };

        protected static string[] validBPawnInputs = { "BDL", "BDR" };

        protected static string[] validCPawnInputs = { "CDL", "CDR" };

        protected static string[] validDPawnInputs = { "DDL", "DDR" };

        protected static bool proverka(int[] positionCoodinates)
        {
            int positonRow = positionCoodinates[0];
            bool isRowInBoard = (positonRow >= edges[0, 0]) && (positonRow <= edges[3, 0]);
            int positonCol = positionCoodinates[1];
            bool isColInBoard = (positonCol >= edges[0, 1]) && (positonCol <= edges[3, 1]);
            return isRowInBoard && isColInBoard;
        }

        protected static bool proverka2(string checkedString)
        {
            if (counter % 2 == 0)
            {
                int[] equal = new int[4];
                for (int i = 0; i < validKingInputs.Length; i++)
                {
                    string reference = validKingInputs[i];
                    int result = checkedString.CompareTo(reference);
                    if (result != 0)
                    {
                        equal[i] = 0;
                    }
                    else
                    {
                        equal[i] = 1;
                    }
                }
                bool hasAnEqual = false;
                for (int i = 0; i < 4; i++)
                {
                    if (equal[i] == 1)
                    {
                        hasAnEqual = true;
                    }
                }
                if (!hasAnEqual)
                {
                    Console.WriteLine("Invalid command name!");
                }
                return hasAnEqual;
            }
            else
            {
                char startLetter = checkedString[0];
                int[] equal = new int[2];
                bool hasAnEqual = false;
                switch (startLetter)
                {
                    case 'A':
                        for (int i = 0; i < validAPawnInputs.Length; i++)
                        {
                            string reference = validAPawnInputs[i];
                            int result = checkedString.CompareTo(reference);
                            if (result != 0)
                            {
                                equal[i] = 0;
                            }
                            else
                            {
                                equal[i] = 1;
                            }
                        }
                        for (int i = 0; i < 2; i++)
                        {
                            if (equal[i] == 1)
                            {
                                hasAnEqual = true;
                            }
                        }
                        if (!hasAnEqual)
                        {
                            Console.WriteLine("Invalid command name!");
                        }
                        return hasAnEqual;
                           
                    case 'B':
                        for (int i = 0; i < validBPawnInputs.Length; i++)
                        {
                            string reference = validBPawnInputs[i];
                            int result = checkedString.CompareTo(reference);
                            if (result != 0)
                            {
                                equal[i] = 0;
                            }
                            else
                            {
                                equal[i] = 1;
                            }
                        }
                        for (int i = 0; i < 2; i++)
                        {
                            if (equal[i] == 1)
                            {
                                hasAnEqual = true;
                            }
                        }
                        if (!hasAnEqual)
                        {
                            Console.WriteLine("Invalid command name!");
                        }
                        return hasAnEqual;
                    case 'C':
                        for (int i = 0; i < validCPawnInputs.Length; i++)
                        {
                            string reference = validCPawnInputs[i];
                            int result = checkedString.CompareTo(reference);
                            if (result != 0)
                            {
                                equal[i] = 0;
                            }
                            else
                            {
                                equal[i] = 1;
                            }
                        }
                        for (int i = 0; i < 2; i++)
                        {
                            if (equal[i] == 1)
                            {
                                hasAnEqual = true;
                            }
                        }
                        if (!hasAnEqual)
                        {
                            Console.WriteLine("Invalid command name!");
                        }
                        return hasAnEqual;

                    case 'D':
                        for (int i = 0; i < validDPawnInputs.Length; i++)
                        {
                            string reference = validDPawnInputs[i];
                            int result = checkedString.CompareTo(reference);
                            if (result != 0)
                            {
                                equal[i] = 0;
                            }
                            else
                            {
                                equal[i] = 1;
                            }
                        }
                        for (int i = 0; i < 2; i++)
                        {
                            if (equal[i] == 1)
                            {
                                hasAnEqual = true;
                            }
                        }
                        if (!hasAnEqual)
                        {
                            Console.WriteLine("Invalid command name!");
                        }
                        return hasAnEqual;
                       
                    default:
                        Console.WriteLine("Invalid command name!");
                        return false;
                //    break;
                }
            }
            return true;
        }
    }
}
