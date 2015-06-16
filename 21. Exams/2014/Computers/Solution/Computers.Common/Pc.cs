namespace Computers.Common
{
    using System.Collections.Generic;

    using Computers.Common.Components;

    public class Pc : Computer
    {
        private const string YouWinMessage = "You win!";

        private const string YouDidNotGuessTheNumberMessage = "You didn't guess the number {0}.";

        public Pc(ICpu cpu, IRam ram, IEnumerable<IHardDrive> hardDrives, IVideoCard videoCard)
            : base(cpu, ram, hardDrives, videoCard)
        {
        }

        public void Play(int guessNumber)
        {
            this.Cpu.GenerateRandomNumber(1, 10);
            var number = this.Ram.LoadValue();
            if (number == guessNumber)
            {
                this.VideoCard.Draw(YouWinMessage);
            }
            else
            {
                this.VideoCard.Draw(string.Format(YouDidNotGuessTheNumberMessage, number));
            }
        }
    }
}
