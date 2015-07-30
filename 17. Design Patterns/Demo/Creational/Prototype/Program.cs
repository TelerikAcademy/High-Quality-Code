namespace Prototype
{
    using System;

    public static class Program
    {
        public static void Main()
        {
            var darkTrooper = new Stormtrooper("Dark trooper", 180, 80);
            Console.WriteLine(darkTrooper);
            
            // var anotherDarkTrooper = new Stormtrooper("Dark trooper", 180, 80);
            var anotherDarkTrooper = darkTrooper.Clone();
            darkTrooper.Height = 200;
            Console.WriteLine(anotherDarkTrooper);
        }
    }
}
