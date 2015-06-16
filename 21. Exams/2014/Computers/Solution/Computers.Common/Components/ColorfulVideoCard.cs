namespace Computers.Common.Components
{
    using System;

    public class ColorfulVideoCard : MotherboardComponent, IVideoCard
    {
        public void Draw(string data)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(data);
            Console.ResetColor();
        }
    }
}
