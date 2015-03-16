namespace Command.CalculatorExample
{
    using System;

    /// <summary>
    /// The 'Receiver' class
    /// </summary>
    public class Calculator
    {
        private decimal currentValue;

        public void Operation(char @operator, int operand)
        {
            switch (@operator)
            {
                case '+':
                    this.currentValue += operand;
                    break;
                case '-':
                    this.currentValue -= operand;
                    break;
                case '*':
                    this.currentValue *= operand;
                    break;
                case '/':
                    this.currentValue /= operand;
                    break;
            }

            Console.WriteLine("Current value = {0,3} (following {1} {2})", this.currentValue, @operator, operand);
        }
    }
}
