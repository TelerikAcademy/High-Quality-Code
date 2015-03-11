﻿namespace Flyweight
{
    using System;

    public class Program
    {
        public static void Main()
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
        }
    }
}
