namespace Interpreter.PolishNotationExample.Expressions
{
    /// <summary>
    /// Terminal expression
    /// </summary>
    public class IntegerExpression : ExpressionBase
    {
        private readonly int value;

        public IntegerExpression(int value)
        {
            this.value = value;
        }

        public override int Evaluate()
        {
            return this.value;
        }

        public override string ToString()
        {
            return this.value.ToString();
        }
    }
}
