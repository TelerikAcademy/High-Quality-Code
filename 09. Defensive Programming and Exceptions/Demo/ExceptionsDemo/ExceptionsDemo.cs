using System;

class ExceptionsDemo
{
    static void Main()
    {
        string s = Console.ReadLine();
        try
        {
            Int32.Parse(s);
            Console.WriteLine("You entered valid Int32 number {0}.", s);
        }
        catch (FormatException)
        {
            Console.WriteLine("Invalid integer number!");
        }
        catch (OverflowException)
        {
            Console.WriteLine("The number is too big to fit in Int32!");
        }
    }
}
