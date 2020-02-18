using System;

namespace SimpleFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = 100;
            var b = 200;
            var type = "+";
            var calculator = Factory.GetCalculatorInstance(type);
            //var calculator = new Factory().GetCalculator(type);
            var result = calculator?.Calculate(a, b);
            Console.WriteLine($"a{type}b={result}");

            Console.ReadKey();
        }
    }
}
