namespace Interpreter.RomanNumbersExample.Expressions
{
    /// <summary>
    /// A 'TerminalExpression' class
    /// <remarks>
    /// Ten checks for X, XL, L and XC
    /// </remarks>
    /// </summary>
    public class TenExpression : Expression
    {
        protected override string One()
        {
            return "X";
        }

        protected override string Four()
        {
            return "XL";
        }

        protected override string Five()
        {
            return "L";
        }

        protected override string Nine()
        {
            return "XC";
        }

        protected override int Multiplier()
        {
            return 10;
        }
    }
}
