using System;
using King;

// bachka, ne butaj!

namespace KingSurvivalGame
{
    class KingSurvivalGame : BaseGame
    {
        static bool check(int[] positionCoodinates)
        {
            int a = positionCoodinates[0];
            bool flag = (a >= ygliNaDyskata[0, 0]) && (a <= ygliNaDyskata[3, 0]);
            int b = positionCoodinates[1];
            bool flag2 = (b >= ygliNaDyskata[0, 1]) && (b <= ygliNaDyskata[3, 1]);
            return flag && flag2;
        }

        static void PokajiDyskata()
        {
            //tova printira prazen red na konzolata
            Console.WriteLine();
            //tuka kato cqlo si pravq nekvi shareniiki
            for (int row = 0; row < field.GetLength(0); row++)
            {
                for (int col = 0; col < field.GetLength(1); col++)
                {
                    int[] coordinates = { row, col };
                    bool isCellIn = check(coordinates);
                    if (isCellIn)
                    {
                        if (row  % 2 == 0)
                        {
                            if (col % 4 == 0 )
                            {
                                //i neka byde zelenina
                                Console.BackgroundColor = ConsoleColor.Green;
                                //tva go prai cherno
                                Console.ForegroundColor = ConsoleColor.Black;
                                //i stignaxme nai posle do printiraneto na elementa
                                Console.Write(field[row, col]);
                                Console.ResetColor();
                            }
                            else if (col % 2 == 0)
                            {
                                Console.BackgroundColor = ConsoleColor.Blue;
                                Console.ForegroundColor = ConsoleColor.Black;
                                Console.Write(field[row, col]);
                                Console.ResetColor();
                            }
                            else if (col % 2 != 0)
                            {
                                Console.Write(field[row, col]);
                            }
                        }
                        else if (col % 4 == 0)
                        {
                            Console.BackgroundColor = ConsoleColor.Blue;
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.Write(field[row, col]);
                            Console.ResetColor();
                        }
                        else if (col % 2 == 0)
	                    {
                            Console.BackgroundColor = ConsoleColor.Green;
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.Write(field[row, col]);
                            Console.ResetColor();
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
                Console.ResetColor();
            }
            Console.WriteLine();
        }

        static void START(int moveCounter)
        {
            if (flag3)
            {//igrata svyrshi
                Console.WriteLine("Game is finished!");
                return;
            }
            else
            {
                if (moveCounter % 2 == 0)
                {
                    PokajiDyskata();
                    ProcessKingSide();
                }
                else
                {
                    PokajiDyskata();
                    ProcessPawnSide();
                }
            }
            
        }

        static bool proverka2(string checkedString)
        {
            if (counter % 2 == 0)
            {
                int[] flag = new int[4];
                for (int i = 0; i < validKingInputs.Length; i++)
                {
                    string reference = validKingInputs[i];
                    int result = checkedString.CompareTo(reference);
                    if (result != 0)
                    {
                        flag[i] = 0;
                    }
                    else
                    {
                        flag[i] = 1;
                    }
                }
                bool hasAnEqual = false;
                for (int i = 0; i < 4; i++)
			    {
			        if (flag[i]==1)
	                {
		                hasAnEqual = true;
	                }
			    }
                if(!hasAnEqual)
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid command name!");
                    Console.ResetColor();
                }
                return hasAnEqual;
            }
            else
            {
                char startLetter = checkedString[0];
                int[] checker = new int[2];
                bool hasAnEqual = false;
                switch (startLetter)
                {
                    case 'A':
                        for (int i = 0; i < a.Length; i++)
                        {
                            string reference = a[i];
                            int result = checkedString.CompareTo(reference);
                            if (result != 0)
                            {
                                checker[i] = 0;
                            }
                            else
                            {
                                checker[i] = 1;
                            }
                        }
                        for (int i = 0; i < 2; i++)
			            {
			                if (checker[i]==1)
	                        {
		                        hasAnEqual = true;
	                        }
			            }
                        if(!hasAnEqual)
                        {
                            Console.BackgroundColor = ConsoleColor.Red;
                            Console.WriteLine("Invalid command name!");
                            Console.ResetColor();
                        }
                        return hasAnEqual;
                        
                    case 'B':
                        for (int i = 0; i < b.Length; i++)
                        {
                            string reference = b[i];
                            int result = checkedString.CompareTo(reference);
                            if (result != 0)
                            {
                                checker[i] = 0;
                            }
                            else
                            {
                                checker[i] = 1;
                            }
                        }
                        for (int i = 0; i < 2; i++)
			            {
			                if (checker[i]==1)
	                        {
		                        hasAnEqual = true;
	                        }
			            }
                        if(!hasAnEqual)
                        {
                            Console.BackgroundColor = ConsoleColor.Red;
                            Console.WriteLine("Invalid command name!");
                            Console.ResetColor();
                        }
                        return hasAnEqual;
                    case 'C':
                        for (int i = 0; i < c.Length; i++)
                        {
                            string reference = c[i];
                            int result = checkedString.CompareTo(reference);
                            if (result != 0)
                            {
                                checker[i] = 0;
                            }
                            else
                            {
                                checker[i] = 1;
                            }
                        }
                        for (int i = 0; i < 2; i++)
			            {
			                if (checker[i]==1)
	                        {
		                        hasAnEqual = true;
	                        }
			            }
                        if(!hasAnEqual)
                        {
                            Console.BackgroundColor = ConsoleColor.Red;
                            Console.WriteLine("Invalid command name!");
                            Console.ResetColor();
                        }
                        return hasAnEqual;

                    case 'D':
                        for (int i = 0; i < d.Length; i++)
                        {
                            string reference = d[i];
                            int result = checkedString.CompareTo(reference);
                            if (result != 0)
                            {
                                checker[i] = 0;
                            }
                            else
                            {
                                checker[i] = 1;
                            }
                        }
                        for (int i = 0; i < 2; i++)
			            {
			                if (checker[i]==1)
	                        {
		                        hasAnEqual = true;
	                        }
			            }
                        if(!hasAnEqual)
                        {
                            Console.BackgroundColor = ConsoleColor.Red;
                            Console.WriteLine("Invalid command name!");
                            Console.ResetColor();
                        }
                        return hasAnEqual;
                    
                    default:
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.WriteLine("Invalid command name!");
                        Console.ResetColor();
                        return false;
                    //    break;
                }
            }
            return true;
        }

        static bool proverkaIProcess(string checkedInput)
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
                            oldCoordinates[0] = poziciqPeshki[0,0];


                            oldCoordinates[1] = poziciqPeshki[0, 1];


                            int[] coords = new int[2];
                            coords = CheckNextPownPosition(oldCoordinates, 'L', 'A');
                            if (coords != null)
                            {

                                poziciqPeshki[0,0]= coords[0];
                                poziciqPeshki[0, 1] = coords[1];
                            }
                        }
                        else 
                        {
                            //=='D'
                            int[] oldCoordinates = new int[2];
                            oldCoordinates[0] = poziciqPeshki[0, 0];

                            oldCoordinates[1] = poziciqPeshki[0, 1];
                            int[] coords = new int[2];

                            coords = CheckNextPownPosition(oldCoordinates, 'R', 'A');
                            if (coords != null)
                            {
                                poziciqPeshki[0, 0] = coords[0];

                                poziciqPeshki[0, 1] = coords[1];
                            }
                        }
                        return true;
                    
                    case 'B':
                        if (checkedInput[2] == 'L')
                        {
                            int[] oldCoordinates = new int[2];
                            oldCoordinates[0] = poziciqPeshki[1,0];
                            oldCoordinates[1] = poziciqPeshki[1, 1];

                            int[] coords = new int[2];

                            coords = CheckNextPownPosition(oldCoordinates, 'L', 'B');
                            if (coords != null)
                            {


                                poziciqPeshki[1, 0] = coords[0];



                                poziciqPeshki[1, 1] = coords[1];

                            }
                        }
                        else 
                        {
                            //=='D'
                            int[] oldCoordinates = new int[2];

                            oldCoordinates[0] = poziciqPeshki[1, 0];



                            oldCoordinates[1] = poziciqPeshki[1, 1];

                            int[] coords = new int[2];
                            coords = CheckNextPownPosition(oldCoordinates, 'R', 'B');
                            if (coords != null)
                            {
                                poziciqPeshki[1, 0] = coords[0];


                                poziciqPeshki[1, 1] = coords[1];
                            }
                        }
                        return true;

                    case 'C':
                        if (checkedInput[2] == 'L')
                        {
                            int[] oldCoordinates = new int[2];
                            oldCoordinates[0] = poziciqPeshki[2,0];


                            oldCoordinates[1] = poziciqPeshki[2, 1];
                            int[] coords = new int[2];
                            coords = CheckNextPownPosition(oldCoordinates, 'L', 'C');
                            if (coords != null)
                            {
                                poziciqPeshki[2, 0] = coords[0];
                                poziciqPeshki[2, 1] = coords[1];
                            }
                        }
                        else 
                        {
                            //=='D'
                            int[] oldCoordinates = new int[2];
                            oldCoordinates[0] = poziciqPeshki[2, 0];
                            oldCoordinates[1] = poziciqPeshki[2, 1];
                            int[] coords = new int[2];
                            coords = CheckNextPownPosition(oldCoordinates, 'R', 'C');
                            if (coords != null)
                            {
                                poziciqPeshki[1, 0] = coords[0];
                                poziciqPeshki[1, 1] = coords[1];
                            }
                        }
                        return true;
                        
                    case 'D':
                        if (checkedInput[2] == 'L')
                        {
                            int[] oldCoordinates = new int[2];
                            oldCoordinates[0] = poziciqPeshki[3,0];
                            oldCoordinates[1] = poziciqPeshki[3, 1];
                            int[] coords = new int[2];
                            coords = CheckNextPownPosition(oldCoordinates, 'L', 'D');
                            if (coords != null)
                            {
                                poziciqPeshki[3, 0] = coords[0];
                                poziciqPeshki[3, 1] = coords[1];
                            }
                        }
                        else 
                        {
                            //=='D'
                            int[] oldCoordinates = new int[2];
                            oldCoordinates[0] = poziciqPeshki[3, 0];
                            oldCoordinates[1] = poziciqPeshki[3, 1];
                            int[] coords = new int[2];
                            coords = CheckNextPownPosition(oldCoordinates, 'R', 'D');
                            if (coords != null)
                            {
                                poziciqPeshki[3, 0] = coords[0];
                                poziciqPeshki[3, 1] = coords[1];
                            }
                        }
                        return true;

                    case 'K':
                        if (checkedInput[1] == 'U')
                        {
                            if (checkedInput[2] == 'L')
                            {
                                int[] oldCoordinates = new int[2];
                                oldCoordinates[0] = poziciqCar[0];
                                oldCoordinates[1] = poziciqCar[1];
                                int[] coords = new int[2];
                                coords = checkNextKingPosition(oldCoordinates, 'U', 'L');
                                if (coords != null)
                                {
                                    poziciqCar[0] = coords[0];
                                    poziciqCar[1] = coords[1];
                                }
                            }
                            else
                            {
                                int[] oldCoordinates = new int[2];
                                oldCoordinates[0] = poziciqCar[0];
                                oldCoordinates[1] = poziciqCar[1];
                                int[] coords = new int[2];
                                coords = checkNextKingPosition(oldCoordinates, 'U', 'R');
                                if (coords != null)
                                {
                                    poziciqCar[0] = coords[0];
                                    poziciqCar[1] = coords[1];
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
                                oldCoordinates[0] = poziciqCar[0];
                                oldCoordinates[1] = poziciqCar[1];
                                int[] coords = new int[2];
                                coords = checkNextKingPosition(oldCoordinates, 'D', 'L');
                                if (coords != null)
                                {
                                    poziciqCar[0] = coords[0];
                                    poziciqCar[1] = coords[1];
                                }
                            }
                            else
                            {
                                //==KDD
                                int[] oldCoordinates = new int[2];
                                oldCoordinates[0] = poziciqCar[0];
                                oldCoordinates[1] = poziciqCar[1];
                                int[] coords = new int[2];
                                coords = checkNextKingPosition(oldCoordinates, 'D', 'R');
                                if (coords != null)
                                {
                                    poziciqCar[0] = coords[0];
                                    poziciqCar[1] = coords[1];
                                }
                            }
                            return true;
                        }
                    default:
                        Console.WriteLine("Sorry, there are some errors, but I can't tell you anything! You broked my program!"); return false;
                }
            }
            else
            {
                return false;//message is from other
            }
        }
        
        static void ProcessKingSide()
        {
            bool isExecuted = false;
            while (!isExecuted)
            {
                Console.BackgroundColor = ConsoleColor.DarkGreen;
                Console.Write("Please enter king's turn: ");
                Console.ResetColor();
                string input = Console.ReadLine();
                if (input != null)
                {
                    input = input.ToUpper();//! input =
                    isExecuted = proverkaIProcess(input);
                }
                else
                {
                    isExecuted = false;
                    Console.BackgroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Please enter something!");
                    Console.ResetColor();
                }
            }
            START(counter);
        }
   
        static void ProcessPawnSide() 
        {
            bool isExecuted = false;
            while (!isExecuted)
            {
                Console.BackgroundColor = ConsoleColor.Blue;
                Console.Write("Please enter pawn's turn: ");
                Console.ResetColor();
                string input = Console.ReadLine();
                //input = input.Trim();
                if (input != null)//"/n")
                {
                   // Console.WriteLine(input);
                    //Console.WriteLine("hahah");
                    input = input.ToUpper();//! input =
                    isExecuted = proverkaIProcess(input);
                }
                else
                {
                    isExecuted = false;
                    Console.BackgroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Please enter something!");
                    Console.ResetColor();

                }
            }
            START(counter);
        }

        static void checkForKingExit(int currentKingXAxe)
        {
            if (currentKingXAxe == 2)
            {
                Console.WriteLine("End!");
                Console.WriteLine("King wins in {0} moves!", counter / 2);
                flag3 = true;
            }
        }

        static int[] CheckNextPownPosition(int[] currentCoordinates ,char checkDirection, char currentPawn)
        {
            int[] displasmentDownLeft = { 1, -2 };
            int[] displasmentDownRight = { 1, 2 };
            int[] newCoords = new int[2];
            if (checkDirection=='L')
            {
                newCoords[0] = currentCoordinates[0] + displasmentDownLeft[0];
                newCoords[1] = currentCoordinates[1] + displasmentDownLeft[1];
                if (check(newCoords) && field[newCoords[0], newCoords[1]] == ' ')
                {
                    char sign = field[currentCoordinates[0], currentCoordinates[1]];
                    field [currentCoordinates[0] , currentCoordinates[1]] = ' ';
                    field[newCoords[0], newCoords[1]] = sign;
                    counter++;
                    switch (currentPawn)
                    {
                        case 'A':
                            pawnExistingMoves[0, 0] = true;
                            pawnExistingMoves[0, 1] = true;
                            break;

                        case 'B':
                            pawnExistingMoves[1, 0] = true;
                            pawnExistingMoves[1, 1] = true;
                            break;
                        case 'C':
                            pawnExistingMoves[2, 0] = true;
                            pawnExistingMoves[2, 1] = true;
                            break;

                        case 'D':
                            pawnExistingMoves[3, 0] = true;
                            pawnExistingMoves[3, 1] = true;
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
                            pawnExistingMoves[0, 0] = false;
                            /*for (int i = 0; i < 2; i++)
                            {
                                if (pawnExistingMoves[0,i] == true)
                                {
                                    allAreFalse = false;
                                }
                            }*/
                            break;

                        case 'B':
                            pawnExistingMoves[1, 0] = false;
                            /*for (int i = 0; i < 2; i++)
                            {
                                if (pawnExistingMoves[1, i] == true)
                                {
                                    allAreFalse = false;
                                }
                            }*/
                            break;
                        case 'C':
                            pawnExistingMoves[2, 0] = false;
                            /*for (int i = 0; i < 2; i++)
                            {
                                if (pawnExistingMoves[2, i] == true)
                                {
                                    allAreFalse = false;
                                }
                            }*/
                            break;

                        case 'D':
                            pawnExistingMoves[3, 0] = false;
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
                            if (pawnExistingMoves[i, j] == true)
                            {
                                allAreFalse = false;
                            }
                        }
                    }
                    if (allAreFalse)
                    {
                        flag3 = true;
                        Console.WriteLine("King wins!");
                        flag3 = true;
                        return null;
                    }
                    Console.BackgroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("You can't go in this direction! ");
                    Console.ResetColor();
                    return null;
                }
            }
            else
        	{
                newCoords[0] = currentCoordinates[0] + displasmentDownRight[0];
                newCoords[1] = currentCoordinates[1] + displasmentDownRight[1];
                if (check(newCoords) && field[newCoords[0], newCoords[1]] == ' ')
                {
                    char sign = field[currentCoordinates[0], currentCoordinates[1]];
                    field[currentCoordinates[0], currentCoordinates[1]] = ' ';
                    field[newCoords[0], newCoords[1]] = sign;
                    counter++;
                    switch (currentPawn)
                    {
                        case 'A':
                            pawnExistingMoves[0, 0] = true;
                            pawnExistingMoves[0, 1] = true;
                            break;

                        case 'B':
                            pawnExistingMoves[1, 0] = true;
                            pawnExistingMoves[1, 1] = true;
                            break;
                        case 'C':
                            pawnExistingMoves[2, 0] = true;
                            pawnExistingMoves[2, 1] = true;
                            break;

                        case 'D':
                            pawnExistingMoves[3, 0] = true;
                            pawnExistingMoves[3, 1] = true;
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
                            pawnExistingMoves[0, 1] = false;
                            /*for (int i = 0; i < 2; i++)
                            {
                                if (pawnExistingMoves[0, i] == true)
                                {
                                    allAreFalse = false;
                                }
                            }*/
                            break;

                        case 'B':
                            pawnExistingMoves[1, 1] = false;
                            /*for (int i = 0; i < 2; i++)
                            {
                                if (pawnExistingMoves[1, i] == true)
                                {
                                    allAreFalse = false;
                                }
                            }*/
                            break;
                        case 'C':
                            pawnExistingMoves[2, 1] = false;
                            /*for (int i = 0; i < 2; i++)
                            {
                                if (pawnExistingMoves[2, i] == true)
                                {
                                    allAreFalse = false;
                                }
                            }*/
                            break;

                        case 'D':
                            pawnExistingMoves[3, 1] = false;
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
                        for (int j = 0; j < 2 ; j++)
                        {
                            if (pawnExistingMoves[i, j] == true)
                            {
                                allAreFalse = false;
                            }
                        }
                    }

                    if (allAreFalse)
                    {
                        flag3 = true;
                        Console.WriteLine("King wins!");
                        flag3 = true;
                        return null;
                    }
                    Console.BackgroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("You can't go in this direction! ");
                    Console.ResetColor();
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
                    if (check(newCoords) && field[newCoords[0], newCoords[1]] == ' ')
                    {
                        char sign = field[currentCoordinates[0], currentCoordinates[1]];
                        field[currentCoordinates[0], currentCoordinates[1]] = ' ';
                        field[newCoords[0], newCoords[1]] = sign;
                        counter++;
                        for (int i = 0; i < 4; i++)
                        {
                            kingExistingMoves[i] = true;
                        }
                        checkForKingExit(newCoords[0]);
                        return newCoords;
                    }
                    else
                    {
                        kingExistingMoves[0] = false;
                        bool allAreFalse = true;
                        for (int i = 0; i < 4; i++)
                        {
                            if (kingExistingMoves[i] == true)
                            {
                                allAreFalse = false; 
                            }   
                        }
                        if (allAreFalse)
                        {
                            flag3 = true;
                            Console.WriteLine("King loses!");
                            return null;
                        }
                        Console.BackgroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("You can't go in this direction! ");
                        Console.ResetColor();
                        return null;
                    }
                }
                else
                {
                    newCoords[0] = currentCoordinates[0] + displasmentUpRight[0];
                    newCoords[1] = currentCoordinates[1] + displasmentUpRight[1];
                    if (check(newCoords) && field[newCoords[0], newCoords[1]] == ' ')
                    {
                        char sign = field[currentCoordinates[0], currentCoordinates[1]];
                        field[currentCoordinates[0], currentCoordinates[1]] = ' ';
                        field[newCoords[0], newCoords[1]] = sign;
                        counter++;
                        for (int i = 0; i < 4; i++)
                        {
                            kingExistingMoves[i] = true;
                        }
                        checkForKingExit(newCoords[0]);
                        return newCoords;
                    }
                    else
                    {
                        kingExistingMoves[1] = false;
                        bool allAreFalse = true;
                        for (int i = 0; i < 4; i++)
                        {
                            if (kingExistingMoves[i] == true)
                            {
                                allAreFalse = false;
                            }
                        }
                        if (allAreFalse)
                        {
                            flag3 = true;
                            Console.WriteLine("King loses!");
                            return null;
                        }
                        Console.BackgroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("You can't go in this direction! ");
                        Console.ResetColor();
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
                    if (check(newCoords) && field[newCoords[0], newCoords[1]] == ' ')
                    {
                        char sign = field[currentCoordinates[0], currentCoordinates[1]];
                        field[currentCoordinates[0], currentCoordinates[1]] = ' ';
                        field[newCoords[0], newCoords[1]] = sign;
                        counter++;
                        for (int i = 0; i < 4; i++)
                        {
                            kingExistingMoves[i] = true;
                        }
                        checkForKingExit(newCoords[0]);
                        return newCoords;
                    }
                    else
                    {
                        kingExistingMoves[2] = false;
                        bool allAreFalse = true;
                        for (int i = 0; i < 4; i++)
                        {
                            if (kingExistingMoves[i] == true)
                            {
                                allAreFalse = false;
                            }
                        }
                        if (allAreFalse)
                        {
                            flag3 = true;
                            Console.WriteLine("King loses!");
                            return null;
                        }
                        Console.BackgroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("You can't go in this direction! ");
                        Console.ResetColor();
                        return null;
                    }
                }
                else
                {
                    newCoords[0] = currentCoordinates[0] + displasmentDownRight[0];
                    newCoords[1] = currentCoordinates[1] + displasmentDownRight[1];
                    if (check(newCoords) && field[newCoords[0], newCoords[1]] == ' ')
                    {
                        char sign = field[currentCoordinates[0], currentCoordinates[1]];
                        field[currentCoordinates[0], currentCoordinates[1]] = ' ';
                        field[newCoords[0], newCoords[1]] = sign;
                        counter++;
                        for (int i = 0; i < 4; i++)
                        {
                            kingExistingMoves[i] = true;
                        }
                        checkForKingExit(newCoords[0]);
                        return newCoords;
                    }
                    else
                    {
                        kingExistingMoves[3] = false;
                        bool allAreFalse = true;
                        for (int i = 0; i < 4; i++)
                        {
                            if (kingExistingMoves[i] == true)
                            {
                                allAreFalse = false;
                            }
                        }
                        if (allAreFalse)
                        {
                            flag3 = true;
                            Console.WriteLine("King loses!");
                            return null;
                        }
                        Console.BackgroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("You can't go in this direction! ");
                        Console.ResetColor();
                        return null;
                    }
                }
               // checkForKingExit();
            }
        }
        
        static void Main()
        {
            START(counter);
            Console.WriteLine("\nThank you for using this game!\n\n");
        }             
    }
}