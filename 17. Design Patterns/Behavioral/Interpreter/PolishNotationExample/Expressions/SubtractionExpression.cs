namespace Interpreter.PolishNotationExample.Expressions
{
    /// <summary>
    /// Non-terminal expression
    /// </summary>
    public class SubtractionExpression : ExpressionBase
    {
        private readonly ExpressionBase expression1;
        private readonly ExpressionBase expression2;

        public SubtractionExpression(ExpressionBase expression1, ExpressionBase expression2)
        {
            this.expression1 = expression1;
            this.expression2 = expression2;
        }

        public override int Evaluate()
        {
            var value1 = this.expression1.Evaluate();
            var value2 = this.expression2.Evaluate();
            return value1 - value2;
        }

        public override string ToString()
        {
            return string.Format("({0} - {1})", this.expression1, this.expression2);
        }
    }
}
