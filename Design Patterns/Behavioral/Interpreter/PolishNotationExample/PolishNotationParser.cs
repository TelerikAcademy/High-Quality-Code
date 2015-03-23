namespace Interpreter.PolishNotationExample
{
    using System;
    using System.Collections.Generic;

    using Interpreter.PolishNotationExample.Expressions;

    public class PolishNotationParser
    {
        public ExpressionBase Parse(string polish)
        {
            var symbols = new List<string>(polish.Split(' '));
            return this.ParseNextExpression(symbols);
        }

        private ExpressionBase ParseNextExpression(List<string> symbols)
        {
            int value;
            if (int.TryParse(symbols[0], out value))
            {
                symbols.RemoveAt(0);
                return new IntegerExpression(value);
            }
            else
            {
                return this.ParseNonTerminalExpression(symbols);
            }
        }

        private ExpressionBase ParseNonTerminalExpression(List<string> symbols)
        {
            var symbol = symbols[0];
            symbols.RemoveAt(0);

            var expression1 = this.ParseNextExpression(symbols);
            var expression2 = this.ParseNextExpression(symbols);

            switch (symbol)
            {
                case "+":
                    return new AdditionExpression(expression1, expression2);
                case "-":
                    return new SubtractionExpression(expression1, expression2);
                default:
                    var message = string.Format("Invalid Symbol ({0})", symbol);
                    throw new InvalidOperationException(message);
            }
        }
    }
}
