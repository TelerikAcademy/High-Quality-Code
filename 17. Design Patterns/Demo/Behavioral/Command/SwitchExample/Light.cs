namespace Command.SwitchExample
{
    using System;

    /// <summary>
    /// The Receiver class
    /// </summary>
    public class Light : ISwitchable
    {
        public void PowerOn()
        {
            Console.WriteLine("The light is on");
        }

        public void PowerOff()
        {
            Console.WriteLine("The light is off");
        }
    }
}
