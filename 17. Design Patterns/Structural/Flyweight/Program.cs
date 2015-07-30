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
            const string Document = "AAZZBBZB";
            var chars = Document.ToCharArray();

            var factory = new CharacterFactory();

            // extrinsic state
            int pointSize = 10;

            // For each character use a flyweight object
            foreach (char c in chars)
            {
                pointSize++;
                var character = factory.GetCharacter(c);
                character.Display(pointSize);
            }

            Console.WriteLine("Number of objects: {0}", factory.NumberOfObjects);
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
