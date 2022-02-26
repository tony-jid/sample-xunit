using System;
using app_lib;

namespace app_console
{
    class Program
    {
        static void Main(string[] args)
        {
            string num1Text, num2Text = string.Empty;

            Console.Write("Enter num 1: ");
            num1Text = Console.ReadLine();
            Console.Write("Enter num 2: ");
            num2Text = Console.ReadLine();

            int num1, num2 = 0;
            int.TryParse(num1Text, out num1);
            int.TryParse(num2Text, out num2);

            Calculator calculator = new Calculator();
            int result = calculator.Plus(num1, num2);
            Console.WriteLine("Result: {0}", result);
        }
    }
}
