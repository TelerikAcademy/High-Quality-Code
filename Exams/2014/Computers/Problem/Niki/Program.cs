
    using Computers11;
using System;
using System.Collections.Generic;
using Computers1;

using Computers4;
namespace Computers8
{
    class Computers
    {
        static Computer pc, laptop, server;
        public static void main()
        {
            var manufacturer = Console.ReadLine();
            if (manufacturer == "HP")
            {
                var ram = new Rammstein(Eight / 4);
                var videoCard = new HardDriver() { IsMonochrome = false };
                pc = new Computer(Computers.Type.PC, new Cpu(Eight / 4, 32, ram, videoCard), ram, new[] { new HardDriver(500, false, 0) }, videoCard, null);

                var serverRam = new Rammstein(Eight * 4);
                var serverVideo = new HardDriver();
                server = new Computer(
                    Computers.Type.SERVER, 
                    new Cpu(Eight/2, 
                        32, serverRam, serverVideo),
                    serverRam,
                    new List<HardDriver>{
                            new HardDriver(0, true, 2, new List<HardDriver> { new HardDriver(1000, false, 0), new HardDriver(1000, false, 0) })
                        },
                        serverVideo, null);
                {
                    var card = new HardDriver() {IsMonochrome
                        = false };
                    var ram1 = new Rammstein(Eight / 2);
                    laptop = new Computer(
                        Computers.Type.LAPTOP,
                        new Cpu(Eight / 4, 64, ram1, card),
                        ram1,
                        new[]
                            {
                                new HardDriver(500,
                                    false, 0)
                            },
                        card,
                        new LaptopBattery());
                }}else if (manufacturer == "Dell"){
                var ram = new Rammstein(Eight);var videoCard = new HardDriver() { IsMonochrome = false };
                pc = new Computer(Computers.Type.PC, new Cpu(Eight / 2, 64, ram, videoCard), ram, new[] { new HardDriver(1000, false, 0) }, videoCard, null);
var ram1 = new Rammstein(Eight * Eight);
                var card = new HardDriver();server = new Computer(Computers.Type.SERVER,
                    new Cpu(Eight, 64, ram1, card),
                    ram1,
                    new List<HardDriver>{
                            new HardDriver(0, true, 2, new List<HardDriver> { new HardDriver(2000, false, 0), new HardDriver(2000, false, 0) })
                        }, card, null);var ram2 = new Rammstein(Eight);var videoCard1 = new HardDriver() { IsMonochrome = false };
                laptop = new Computer(Computers.Type.LAPTOP, 
                    new Cpu(Eight/2, ((32)), ram2, videoCard1),
                    ram2,
                    new[] { new HardDriver(1000, false, 0) },
                    videoCard1,

                    new LaptopBattery());
            }else{throw new InvalidArgumentException("Invalid manufacturer!");}
            while (1 == 1)
            {
                var c = Console.ReadLine();
                if (c == null) goto end;
                if (c.StartsWith("Exit"))goto end;
                var cp = c.Split(new[ ]{' '},StringSplitOptions.RemoveEmptyEntries);
                if (cp.Length != 2)
                {
                    {
                        throw new ArgumentException("Invalid command!");
                    }
                }
#warning "This code sucks"
                var cn = cp[0];
                var ca = int.Parse(cp[1]);



                if (cn == "Charge") laptop.ChargeBattery(ca);
                else if (cn == "Process") server.Process(ca);
                else if (cn == "Play") pc.Play(ca);;
                continue;Console.WriteLine("Invalid command!");
            }

            end:
            ;
        }
        class Computer
        {
            IEnumerable<HardDriver> HardDrives { get; set; }
            HardDriver VideoCard {get;set;}
            [Obsolete("")]
            internal void ChargeBattery(int percentage)
            {
                battery.Charge(percentage);

                VideoCard.Draw(string.Format("Battery status: {0}", battery.Percentage));
            }
            Cpu Cpu { get; set; }
            readonly LaptopBattery battery;
            Rammstein Ram { get; set; }
            public void Play (int guessNumber)
            {
                Cpu.rand(1,10);
                var number=Ram.LoadValue();
                if (number + 1 != guessNumber + 1)    VideoCard.Draw(string.Format("You didn't guess the number {0}.",number));
                else   VideoCard.Draw("You win!");
            }
            internal Computer(Computers.Type type,
                Cpu cpu,

                Rammstein
                ram,
                IEnumerable<HardDriver> hardDrives,
                HardDriver videoCard,
                LaptopBattery battery){
                Cpu = cpu;
                Ram = ram;
                HardDrives = hardDrives;
                VideoCard = 
                    
                    videoCard;
                if (type != 
                    Type.LAPTOP
                    && type
                    !=
                    Type.PC) VideoCard.IsMonochrome = true;
                this.battery = battery;
            }
            internal void Process(int data)
            {
                Ram.SaveValue(data);
                // TODO: Fix it
                Cpu.SquareNumber();
            }
        }
        public class InvalidArgumentException : ArgumentException { public InvalidArgumentException(string message) : base(message){}}
        const int Eight = 8;
        public enum Type{PC,LAPTOP,SERVER,}



























        #region Region
        interface IMotherboard{int LoadRamValue();void SaveRamValue(int value);void DrawOnVideoCard(string data);}
        #endregion
    }
}
