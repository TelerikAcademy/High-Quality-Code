namespace Interpreter.RomanNumbersExample.Expressions
{
    /// <summary>
    /// A 'TerminalExpression' class
    /// <remarks>
    /// Thousand checks for the Roman Numeral M 
    /// </remarks>
    /// </summary>
    public class ThousandExpression : Expression
    {
        protected override string One()
        {
            return "M";
        }

        protected override string Four()
        {
            return " ";
        }

        protected override string Five()
        {
            return " ";
        }

        protected override string Nine()
        {
            return " ";
        }

        protected override int Multiplier()
        {
            return 1000;
        }
    }
}
