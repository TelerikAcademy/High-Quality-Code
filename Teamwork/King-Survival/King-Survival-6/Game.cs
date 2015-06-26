using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KingSurvivalGame
{
    class Game : BasicGame
    {
        protected static char[,] field = 
        {
            { 'U', 'L', ' ', ' ', '0', ' ', '1', ' ', '2', ' ', '3', ' ', '4', ' ', '5', ' ', '6', ' ', '7', ' ', ' ', 'U', 'R' },
            { ' ', ' ', ' ', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', ' ', ' ', ' ' },
            { '0', ' ', '|', ' ', 'A', ' ', ' ', ' ', 'B', ' ', ' ', ' ', 'C', ' ', ' ', ' ', 'D', ' ', ' ', ' ', '|', ' ', '0' },
            { '1', ' ', '|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|', ' ', '1' },
            { '2', ' ', '|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|', ' ', '2' },
            { '3', ' ', '|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|', ' ', '3' },
            { '4', ' ', '|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|', ' ', '4' },
            { '5', ' ', '|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|', ' ', '5' },
            { '6', ' ', '|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|', ' ', '6' },
            { '7', ' ', '|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', 'K', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|', ' ', '7' },
            { ' ', ' ', '|', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '|', ' ', ' ' },
            { 'D', 'L', ' ', ' ', '0', ' ', '1', ' ', '2', ' ', '3', ' ', '4', ' ', '5', ' ', '6', ' ', '7', ' ', ' ', 'D', 'R' },
        };

        protected static int[,] posPaws = 
        {
            { 2, 4 }, { 2, 8 }, { 2, 12 }, { 2, 16 }
        };

        protected static int[] posKing = { 9, 10 };

        protected static bool[,] pMoves = 
        {
            { true, true }, { true, true }, { true, true }, { true, true }
        };

        protected static bool[] kMoves = { true, true, true, true };

        static int[] CheckNextPownPosition(int[] currentCoordinates, char checkDirection, char currentPawn)
        {
            int[] displasmentDownLeft = { 1, -2 };
            int[] displasmentDownRight = { 1, 2 };
            int[] newCoords = new int[2];
            if (checkDirection == 'L')
            {
                newCoords[0] = currentCoordinates[0] + displasmentDownLeft[0];
                newCoords[1] = currentCoordinates[1] + displasmentDownLeft[1];
                if (proverka(newCoords) && field[newCoords[0], newCoords[1]] == ' ')
                {
                    char sign = field[currentCoordinates[0], currentCoordinates[1]];
                    field[currentCoordinates[0], currentCoordinates[1]] = ' ';
                    field[newCoords[0], newCoords[1]] = sign;
                    counter++;
                    switch (currentPawn)
                    {
                        case 'A':
                            pMoves[0, 0] = true;
                            pMoves[0, 1] = true;
                            break;
                        case 'B':
                            pMoves[1, 0] = true;
                            pMoves[1, 1] = true;
                            break;
                        case 'C':
                            pMoves[2, 0] = true;
                            pMoves[2, 1] = true;
                            break;
                        case 'D':
                            pMoves[3, 0] = true;
                            pMoves[3, 1] = true;
                            break;
                        default:
                            Console.WriteLine("ERROR!");
                            break;
                    }

                    return newCoords;
                }
                else
                {
                    /* switch (currentPawn)
                    {
                    case 'A':
                    pawnExistingMoves[0, 0] = false;
                    break;
                    case 'B':
                    pawnExistingMoves[1, 0] = false;
                    break;
                    case 'C':
                    pawnExistingMoves[2, 0] = false;
                    break;
                    case 'D':
                    pawnExistingMoves[3, 0] = false;
                    break;
                    default:
                    Console.WriteLine("ERROR!");
                    break;
                    }*/
                    bool allAreFalse = true;
                    switch (currentPawn)
                    {
                        case 'A':
                            pMoves[0, 0] = false;
                            /*for (int i = 0; i < 2; i++)
                            {
                            if (pawnExistingMoves[0,i] == true)
                            {
                            allAreFalse = false;
                            }
                            }*/
                            break;
                        case 'B':
                            pMoves[1, 0] = false;
                            /*for (int i = 0; i < 2; i++)
                            {
                            if (pawnExistingMoves[1, i] == true)
                            {
                            allAreFalse = false;
                            }
                            }*/
                            break;
                        case 'C':
                            pMoves[2, 0] = false;
                            /*for (int i = 0; i < 2; i++)
                            {
                            if (pawnExistingMoves[2, i] == true)
                            {
                            allAreFalse = false;
                            }
                            }*/
                            break;
                        case 'D':
                            pMoves[3, 0] = false;
                            /*for (int i = 0; i < 2; i++)
                            {
                            if (pawnExistingMoves[3, i] == true)
                            {
                            allAreFalse = false;
                            }
                            }*/
                            break;
                        default:
                            Console.WriteLine("ERROR!");
                            break;
                    }
                    for (int i = 0; i < 4; i++)
                    {
                        for (int j = 0; j < 2; j++)
                        {
                            if (pMoves[i, j] == true)
                            {
                                allAreFalse = false;
                            }
                        }
                    }
                    if (allAreFalse)
                    {
                        gameIsFinished = true;
                        Console.WriteLine("King wins!");
                        gameIsFinished = true;
                        return null;
                    }
                    Console.WriteLine("You can't go in this direction! ");
                    return null;
                }
            }
            else
            {
                newCoords[0] = currentCoordinates[0] + displasmentDownRight[0];
                newCoords[1] = currentCoordinates[1] + displasmentDownRight[1];
                if (proverka(newCoords) && field[newCoords[0], newCoords[1]] == ' ')
                {
                    char sign = field[currentCoordinates[0], currentCoordinates[1]];
                    field[currentCoordinates[0], currentCoordinates[1]] = ' ';
                    field[newCoords[0], newCoords[1]] = sign;
                    counter++;
                    switch (currentPawn)
                    {
                        case 'A':
                            pMoves[0, 0] = true;
                            pMoves[0, 1] = true;
                            break;
                        case 'B':
                            pMoves[1, 0] = true;
                            pMoves[1, 1] = true;
                            break;
                        case 'C':
                            pMoves[2, 0] = true;
                            pMoves[2, 1] = true;
                            break;
                        case 'D':
                            pMoves[3, 0] = true;
                            pMoves[3, 1] = true;
                            break;
                        default:
                            Console.WriteLine("ERROR!");
                            break;
                    }
                    return newCoords;
                }
                else
                {
                    /*   switch (currentPawn)
                    {
                    case 'A':
                    pawnExistingMoves[0, 1] = false;
                    break;
                    case 'B':
                    pawnExistingMoves[1, 1] = false;
                    break;
                    case 'C':
                    pawnExistingMoves[2, 1] = false;
                    break;
                    case 'D':
                    pawnExistingMoves[3, 1] = false;
                    break;
                    default:
                    Console.WriteLine("ERROR!");
                    break;
                    }*/
                    bool allAreFalse = true;
                    switch (currentPawn)
                    {
                        case 'A':
                            pMoves[0, 1] = false;
                            /*for (int i = 0; i < 2; i++)
                            {
                            if (pawnExistingMoves[0, i] == true)
                            {
                            allAreFalse = false;
                            }
                            }*/
                            break;
                        case 'B':
                            pMoves[1, 1] = false;
                            /*for (int i = 0; i < 2; i++)
                            {
                            if (pawnExistingMoves[1, i] == true)
                            {
                            allAreFalse = false;
                            }
                            }*/
                            break;
                        case 'C':
                            pMoves[2, 1] = false;
                            /*for (int i = 0; i < 2; i++)
                            {
                            if (pawnExistingMoves[2, i] == true)
                            {
                            allAreFalse = false;
                            }
                            }*/
                            break;
                        case 'D':
                            pMoves[3, 1] = false;
                            /*for (int i = 0; i < 2; i++)
                            {
                            if (pawnExistingMoves[3, i] == true)
                            {
                            allAreFalse = false;
                            }
                            }*/
                            break;
                        default:
                            Console.WriteLine("ERROR!");
                            break;
                    }
                      
                    for (int i = 0; i < 4; i++)
                    {
                        for (int j = 0; j < 2; j++)
                        {
                            if (pMoves[i, j] == true)
                            {
                                allAreFalse = false;
                            }
                        }
                    }

                    if (allAreFalse)
                    {
                        gameIsFinished = true;
                        Console.WriteLine("King wins!");
                        gameIsFinished = true;
                        return null;
                    }
                    Console.WriteLine("You can't go in this direction! ");
                    return null;
                }
            }
        }

        static int[] checkNextKingPosition(int[] currentCoordinates, char firstDirection, char secondDirection)
        {
            int[] displasmentDownLeft = { 1, -2 };
            int[] displasmentDownRight = { 1, 2 };
            int[] displasmentUpLeft = { -1, -2 };
            int[] displasmentUpRight = { -1, 2 };
            int[] newCoords = new int[2];

            if (firstDirection == 'U')
            {
                if (secondDirection == 'L')
                {
                    newCoords[0] = currentCoordinates[0] + displasmentUpLeft[0];
                    newCoords[1] = currentCoordinates[1] + displasmentUpLeft[1];
                    if (proverka(newCoords) && field[newCoords[0], newCoords[1]] == ' ')
                    {
                        char sign = field[currentCoordinates[0], currentCoordinates[1]];
                        field[currentCoordinates[0], currentCoordinates[1]] = ' ';
                        field[newCoords[0], newCoords[1]] = sign;
                        counter++;
                        for (int i = 0; i < 4; i++)
                        {
                            kMoves[i] = true;
                        }
                        checkForKingExit(newCoords[0]);
                        return newCoords;
                    }
                    else
                    {
                        kMoves[0] = false;
                        bool allAreFalse = true;
                        for (int i = 0; i < 4; i++)
                        {
                            if (kMoves[i] == true)
                            {
                                allAreFalse = false; 
                            }
                        }
                        if (allAreFalse)
                        {
                            gameIsFinished = true;
                            Console.WriteLine("King loses!");
                            return null;
                        }
                        Console.WriteLine("You can't go in this direction! ");
                        return null;
                    }
                }
                else
                {
                    newCoords[0] = currentCoordinates[0] + displasmentUpRight[0];
                    newCoords[1] = currentCoordinates[1] + displasmentUpRight[1];
                    if (proverka(newCoords) && field[newCoords[0], newCoords[1]] == ' ')
                    {
                        char sign = field[currentCoordinates[0], currentCoordinates[1]];
                        field[currentCoordinates[0], currentCoordinates[1]] = ' ';
                        field[newCoords[0], newCoords[1]] = sign;
                        counter++;
                        for (int i = 0; i < 4; i++)
                        {
                            kMoves[i] = true;
                        }
                        checkForKingExit(newCoords[0]);
                        return newCoords;
                    }
                    else
                    {
                        kMoves[1] = false;
                        bool allAreFalse = true;
                        for (int i = 0; i < 4; i++)
                        {
                            if (kMoves[i] == true)
                            {
                                allAreFalse = false;
                            }
                        }
                        if (allAreFalse)
                        {
                            gameIsFinished = true;
                            Console.WriteLine("King loses!");
                            return null;
                        }
                        Console.WriteLine("You can't go in this direction! ");
                        return null;
                    }
                }
            }
            else
            {
                if (secondDirection == 'L')
                {
                    newCoords[0] = currentCoordinates[0] + displasmentDownLeft[0];
                    newCoords[1] = currentCoordinates[1] + displasmentDownLeft[1];
                    if (proverka(newCoords) && field[newCoords[0], newCoords[1]] == ' ')
                    {
                        char sign = field[currentCoordinates[0], currentCoordinates[1]];
                        field[currentCoordinates[0], currentCoordinates[1]] = ' ';
                        field[newCoords[0], newCoords[1]] = sign;
                        counter++;
                        for (int i = 0; i < 4; i++)
                        {
                            kMoves[i] = true;
                        }
                        checkForKingExit(newCoords[0]);
                        return newCoords;
                    }
                    else
                    {
                        kMoves[2] = false;
                        bool allAreFalse = true;
                        for (int i = 0; i < 4; i++)
                        {
                            if (kMoves[i] == true)
                            {
                                allAreFalse = false;
                            }
                        }
                        if (allAreFalse)
                        {
                            gameIsFinished = true;
                            Console.WriteLine("King loses!");
                            return null;
                        }
                        Console.WriteLine("You can't go in this direction! ");
                        return null;
                    }
                }
                else
                {
                    newCoords[0] = currentCoordinates[0] + displasmentDownRight[0];
                    newCoords[1] = currentCoordinates[1] + displasmentDownRight[1];
                    if (proverka(newCoords) && field[newCoords[0], newCoords[1]] == ' ')
                    {
                        char sign = field[currentCoordinates[0], currentCoordinates[1]];
                        field[currentCoordinates[0], currentCoordinates[1]] = ' ';
                        field[newCoords[0], newCoords[1]] = sign;
                        counter++;
                        for (int i = 0; i < 4; i++)
                        {
                            kMoves[i] = true;
                        }
                        checkForKingExit(newCoords[0]);
                        return newCoords;
                    }
                    else
                    {
                        kMoves[3] = false;
                        bool allAreFalse = true;
                        for (int i = 0; i < 4; i++)
                        {
                            if (kMoves[i] == true)
                            {
                                allAreFalse = false;
                            }
                        }
                        if (allAreFalse)
                        {
                            gameIsFinished = true;
                            Console.WriteLine("King loses!");
                            return null;
                        }
                        Console.WriteLine("You can't go in this direction! ");
                        return null;
                    }
                }
                // checkForKingExit();
            }
        }

        protected static bool gameIsFinished = false;

        static void checkForKingExit(int currentKingXAxe)
        {
            if (currentKingXAxe == 2)
            {
                Console.WriteLine("End!");
                Console.WriteLine("King wins in {0} moves!", counter / 2);
                gameIsFinished = true;
            }
        }

        protected static void PokajiDyskata()
        {
            //tova printira prazen red na konzolata
            Console.WriteLine();
            //tuka kato cqlo si pravq nekvi shareniiki
            for (int row = 0; row < field.GetLength(0); row++)
            {
                for (int col = 0; col < field.GetLength(1); col++)
                {
                    int[] coordinates = { row, col };
                    bool isCellIn = proverka(coordinates);
                    if (isCellIn)
                    {
                        if (row % 2 == 0)
                        {
                            if (col % 4 == 0)
                            {
                                Console.Write(field[row, col]);
                            }
                            else if (col % 2 == 0)
                            {
                                Console.Write(field[row, col]);
                            }
                            else if (col % 2 != 0)
                            {
                                Console.Write(field[row, col]);
                            }
                        }
                        else if (col % 4 == 0)
                        {
                            Console.Write(field[row, col]);
                        }
                        else if (col % 2 == 0)
                        {
                            Console.Write(field[row, col]);
                        }
                        else if (col % 2 != 0)
                        {
                            Console.Write(field[row, col]);
                        }
                    }
                    else
                    {
                        Console.Write(field[row, col]);  
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        protected static bool proverkaIProcess(string checkedInput)
        {
            bool commandNameIsOK = proverka2(checkedInput);
            if (commandNameIsOK)
            {
                char startLetter = checkedInput[0];
                switch (startLetter)
                {
                    case 'A':

                        if (checkedInput[2] == 'L')
                        {
                            int[] oldCoordinates = new int[2];
                            oldCoordinates[0] = posPaws[0, 0];

                            oldCoordinates[1] = posPaws[0, 1];

                            int[] coords = new int[2];
                            coords = CheckNextPownPosition(oldCoordinates, 'L', 'A');
                            if (coords != null)
                            {
                                posPaws[0, 0] = coords[0];
                                posPaws[0, 1] = coords[1];
                            }
                        }
                        else 
                        {
                            //=='D'
                            int[] oldCoordinates = new int[2];
                            oldCoordinates[0] = posPaws[0, 0];

                            oldCoordinates[1] = posPaws[0, 1];
                            int[] coords = new int[2];

                            coords = CheckNextPownPosition(oldCoordinates, 'R', 'A');
                            if (coords != null)
                            {
                                posPaws[0, 0] = coords[0];

                                posPaws[0, 1] = coords[1];
                            }
                        }
                        return true;
                      
                    case 'B':
                        if (checkedInput[2] == 'L')
                        {
                            int[] oldCoordinates = new int[2];
                            oldCoordinates[0] = posPaws[1, 0];
                            oldCoordinates[1] = posPaws[1, 1];

                            int[] coords = new int[2];

                            coords = CheckNextPownPosition(oldCoordinates, 'L', 'B');
                            if (coords != null)
                            {
                                posPaws[1, 0] = coords[0];

                                posPaws[1, 1] = coords[1];
                            }
                        }
                        else 
                        {
                            //=='D'
                            int[] oldCoordinates = new int[2];

                            oldCoordinates[0] = posPaws[1, 0];

                            oldCoordinates[1] = posPaws[1, 1];

                            int[] coords = new int[2];
                            coords = CheckNextPownPosition(oldCoordinates, 'R', 'B');
                            if (coords != null)
                            {
                                posPaws[1, 0] = coords[0];

                                posPaws[1, 1] = coords[1];
                            }
                        }
                        return true;

                    case 'C':
                        if (checkedInput[2] == 'L')
                        {
                            int[] oldCoordinates = new int[2];
                            oldCoordinates[0] = posPaws[2, 0];

                            oldCoordinates[1] = posPaws[2, 1];
                            int[] coords = new int[2];
                            coords = CheckNextPownPosition(oldCoordinates, 'L', 'C');
                            if (coords != null)
                            {
                                posPaws[2, 0] = coords[0];
                                posPaws[2, 1] = coords[1];
                            }
                        }
                        else 
                        {
                            //=='D'
                            int[] oldCoordinates = new int[2];
                            oldCoordinates[0] = posPaws[2, 0];
                            oldCoordinates[1] = posPaws[2, 1];
                            int[] coords = new int[2];
                            coords = CheckNextPownPosition(oldCoordinates, 'R', 'C');
                            if (coords != null)
                            {
                                posPaws[1, 0] = coords[0];
                                posPaws[1, 1] = coords[1];
                            }
                        }
                        return true;
                          
                    case 'D':
                        if (checkedInput[2] == 'L')
                        {
                            int[] oldCoordinates = new int[2];
                            oldCoordinates[0] = posPaws[3, 0];
                            oldCoordinates[1] = posPaws[3, 1];
                            int[] coords = new int[2];
                            coords = CheckNextPownPosition(oldCoordinates, 'L', 'D');
                            if (coords != null)
                            {
                                posPaws[3, 0] = coords[0];
                                posPaws[3, 1] = coords[1];
                            }
                        }
                        else 
                        {
                            //=='D'
                            int[] oldCoordinates = new int[2];
                            oldCoordinates[0] = posPaws[3, 0];
                            oldCoordinates[1] = posPaws[3, 1];
                            int[] coords = new int[2];
                            coords = CheckNextPownPosition(oldCoordinates, 'R', 'D');
                            if (coords != null)
                            {
                                posPaws[3, 0] = coords[0];
                                posPaws[3, 1] = coords[1];
                            }
                        }
                        return true;

                    case 'K':
                        if (checkedInput[1] == 'U')
                        {
                            if (checkedInput[2] == 'L')
                            {
                                int[] oldCoordinates = new int[2];
                                oldCoordinates[0] = posKing[0];
                                oldCoordinates[1] = posKing[1];
                                int[] coords = new int[2];
                                coords = checkNextKingPosition(oldCoordinates, 'U', 'L');
                                if (coords != null)
                                {
                                    posKing[0] = coords[0];
                                    posKing[1] = coords[1];
                                }
                            }
                            else
                            {
                                int[] oldCoordinates = new int[2];
                                oldCoordinates[0] = posKing[0];
                                oldCoordinates[1] = posKing[1];
                                int[] coords = new int[2];
                                coords = checkNextKingPosition(oldCoordinates, 'U', 'R');
                                if (coords != null)
                                {
                                    posKing[0] = coords[0];
                                    posKing[1] = coords[1];
                                }
                            }
                            return true;
                        }
                        else
                        {
                            //=KD_
                            if (checkedInput[2] == 'L')
                            {
                                int[] oldCoordinates = new int[2];
                                oldCoordinates[0] = posKing[0];
                                oldCoordinates[1] = posKing[1];
                                int[] coords = new int[2];
                                coords = checkNextKingPosition(oldCoordinates, 'D', 'L');
                                if (coords != null)
                                {
                                    posKing[0] = coords[0];
                                    posKing[1] = coords[1];
                                }
                            }
                            else
                            {
                                //==KDD
                                int[] oldCoordinates = new int[2];
                                oldCoordinates[0] = posKing[0];
                                oldCoordinates[1] = posKing[1];
                                int[] coords = new int[2];
                                coords = checkNextKingPosition(oldCoordinates, 'D', 'R');
                                if (coords != null)
                                {
                                    posKing[0] = coords[0];
                                    posKing[1] = coords[1];
                                }
                            }
                            return true;
                        }
                    default:
                        Console.WriteLine("Sorry, there are some errors, but I can't tell you anything! You broked my program!");
                        return false;
                }
            }
            else
            {
                return false;//message is from other
            }
        }
    }
}
