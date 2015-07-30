namespace Interpreter.RomanNumbersExample.Expressions
{
    /// <summary>
    /// The 'AbstractExpression' class
    /// </summary>
    public abstract class Expression
    {
        public void Interpret(Context context)
        {
            if (context.Input.Length == 0)
            {
                return;
            }

            if (context.Input.StartsWith(this.Nine()))
            {
                context.Output += 9 * this.Multiplier();
                context.Input = context.Input.Substring(2);
            }
            else if (context.Input.StartsWith(this.Four()))
            {
                context.Output += 4 * this.Multiplier();
                context.Input = context.Input.Substring(2);
            }
            else if (context.Input.StartsWith(this.Five()))
            {
                context.Output += 5 * this.Multiplier();
                context.Input = context.Input.Substring(1);
            }

            while (context.Input.StartsWith(this.One()))
            {
                context.Output += 1 * this.Multiplier();
                context.Input = context.Input.Substring(1);
            }
        }

        protected abstract string One();

        protected abstract string Four();

        protected abstract string Five();

        protected abstract string Nine();

        protected abstract int Multiplier();
    }
}
