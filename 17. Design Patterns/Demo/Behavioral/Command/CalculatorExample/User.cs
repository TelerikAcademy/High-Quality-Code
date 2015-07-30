namespace Command.CalculatorExample
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// The 'Invoker' class
    /// </summary>
    internal class User
    {
        private readonly Calculator calculator = new Calculator();
        private readonly List<Command> commands = new List<Command>();
        private int currentCommandIndex;

        public void Redo(int levels)
        {
            Console.WriteLine("\n---- Redo {0} levels ", levels);
            for (int i = 0; i < levels; i++)
            {
                if (this.currentCommandIndex < this.commands.Count - 1)
                {
                    var command = this.commands[this.currentCommandIndex++];
                    command.Execute();
                }
            }
        }

        public void Undo(int levels)
        {
            Console.WriteLine("\n---- Undo {0} levels ", levels);
            for (int i = 0; i < levels; i++)
            {
                if (this.currentCommandIndex > 0)
                {
                    var command = this.commands[--this.currentCommandIndex];
                    command.UnExecute();
                }
            }
        }

        public void Compute(char @operator, int operand)
        {
            Command command = new CalculatorCommand(this.calculator, @operator, operand);
            command.Execute();

            this.commands.Add(command);
            this.currentCommandIndex++;
        }
    }
}
