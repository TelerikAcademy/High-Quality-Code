# Control Flow, Conditional Statements and Loops Homework

## Task 1. Class Chef in C&#35;
*	Refactor the following class using best practices for organizing straight-line code:

        public class Chef
        {
            private Bowl GetBowl()
            {   
                //... 
            }
            private Carrot GetCarrot()
            {
                //...
            }
            private void Cut(Vegetable potato)
            {
                //...
            }  
            public void Cook()
            {
                Potato potato = GetPotato();
                Carrot carrot = GetCarrot();
                Bowl bowl;
                Peel(potato);
                        
                Peel(carrot);
                bowl = GetBowl();
                Cut(potato);
                Cut(carrot);
                bowl.Add(carrot);
                        
                bowl.Add(potato);
            }
            private Potato GetPotato()
            {
                //...
            }
        }

## Task 2. Refactor the following if statements

    Potato potato;
    //... 
    if (potato != null)
       if(!potato.HasNotBeenPeeled && !potato.IsRotten)
        Cook(potato);

and

    if (x >= MIN_X && (x =< MAX_X && ((MAX_Y >= y && MIN_Y <= y) && !shouldNotVisitCell)))
    {
       VisitCell();
    }

## Task 3. Refactor the following loop

    int i=0;
    for (i = 0; i < 100;) 
    {
       if (i % 10 == 0)
       {
        Console.WriteLine(array[i]);
        if ( array[i] == expectedValue ) 
        {
           i = 666;
        }
        i++;
       }
       else
       {
            Console.WriteLine(array[i]);
        i++;
       }
    }
    // More code here
    if (i == 666)
    {
        Console.WriteLine("Value Found");
    }

## Task 4*. Refactor your C# 1 exam solutions

*   Using best practices for Variables, Data, Expressions, Constants, Control Flow, Conditional Statements and Loops refactor all your solutions sent during the first C# practical exam this year