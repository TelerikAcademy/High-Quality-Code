namespace Prototype
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var darkTrooper = new Stormtrooper("Dark trooper", 180, 80);
            Console.WriteLine(darkTrooper);
            
            // var anotherDarkTrooper = new Stormtrooper("Dark trooper", 180, 80);
            var anotherDarkTrooper = darkTrooper.Clone() as Stormtrooper;
            darkTrooper.Height = 200;
            Console.WriteLine(anotherDarkTrooper);
        }
    }
}
