namespace Computers.Common.Components
{
    using System;

    public class MonochromeVideoCard : MotherboardComponent, IVideoCard
    {
        public void Draw(string data)
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine(data);
            Console.ResetColor();
        }
    }
}
