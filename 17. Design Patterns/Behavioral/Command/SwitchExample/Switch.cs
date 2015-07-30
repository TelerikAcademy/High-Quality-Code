namespace Command.SwitchExample
{
    using System.Collections.Generic;

    /// <summary>
    /// The Invoker class
    /// </summary>
    public class Switch
    {
        private readonly List<ICommand> history = new List<ICommand>();

        public List<ICommand> History
        {
            get
            {
                return this.history;
            }
        }

        public void StoreAndExecute(ICommand command)
        {
            this.history.Add(command); // optional 
            command.Execute();
        }
    }
}
