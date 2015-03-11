namespace Flyweight
{
    using System;

    public class Program
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
            string s1 = "some value";
            string s2 = "some value";
            string s3 = Console.ReadLine();
            string s4 = string.Intern(s3);
            Console.WriteLine(object.ReferenceEquals(s1, s2));
            Console.WriteLine(object.ReferenceEquals(s1, s3));
            Console.WriteLine(object.ReferenceEquals(s1, s4));
        }
    }
}
