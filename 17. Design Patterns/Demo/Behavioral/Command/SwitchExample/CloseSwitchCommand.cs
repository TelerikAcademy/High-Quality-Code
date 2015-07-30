namespace Command.SwitchExample
{
    /// <summary>
    /// The Command for turning on the device - ConcreteCommand #2
    /// </summary>
    public class CloseSwitchCommand : ICommand
    {
        private readonly ISwitchable switchable;

        public CloseSwitchCommand(ISwitchable switchable)
        {
            this.switchable = switchable;
        }

        public void Execute()
        {
            this.switchable.PowerOn();
        }

        public void UnExecute()
        {
            this.switchable.PowerOff();
        }
    }
}
