namespace Command.CalculatorExample
{
    /// <summary>
    /// The 'Command' abstract class
    /// </summary>
    public abstract class Command
    {
        public abstract void Execute();

        public abstract void UnExecute();
    }
}
