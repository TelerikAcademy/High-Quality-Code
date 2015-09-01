namespace Flyweight
{
    using System;

    public static class Program
    {
        public static void Main()
        {
            FlyweightDemo();

            Console.WriteLine(new string('-', 60));

            StringsDemo();
        }

        private static void FlyweightDemo()
        {
            // Build a document with text
            const string Document = "AAZZABBZZBAB";

            var characterFactory = new CharacterFactory();

            // extrinsic state
            var pointSize = 10;

            // For each character use a flyweight object
            foreach (var c in Document)
            {
                pointSize++;
                var character = characterFactory.GetCharacter(c);
                character.Display(pointSize);
            }

            Console.WriteLine(
                "Total number of character objects: {0}",
                characterFactory.NumberOfObjects);
        }

        private static void StringsDemo()
        {
            string str1 = "some value";
            string str2 = "some value";
            string str3 = Console.ReadLine();
            string str4 = string.Intern(str3);
            Console.WriteLine(ReferenceEquals(str1, str2));
            Console.WriteLine(ReferenceEquals(str1, str3));
            Console.WriteLine(ReferenceEquals(str1, str4));
        }
    }
}
