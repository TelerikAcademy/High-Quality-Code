namespace Interpreter
{
    using System;
    using System.Collections.Generic;

    using Interpreter.RomanNumbersExample;
    using Interpreter.RomanNumbersExample.Expressions;

    public static class Program
    {
        public static void Main()
        {
            RomanNumbersExample();
        }

        private static void RomanNumbersExample()
        {
            var romanNumbersInterpreter =
                new RomanNumbersInterpreter(
                    new List<Expression>
                        {
                            new ThousandExpression(),
                            new HundredExpression(),
                            new TenExpression(),
                            new OneExpression()
                        });

            const string Input = "MMCMXXVIII";
            var context = new Context(Input);

            romanNumbersInterpreter.Interpret(context);
            
            Console.WriteLine();
            Console.WriteLine("Final: {0} = {1}", Input, context.Output);
        }
    }
}
