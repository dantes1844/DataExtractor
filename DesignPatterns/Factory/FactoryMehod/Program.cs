using System;

namespace FactoryMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            //工厂方法里，客户端需要知道实例化哪个工厂，由工厂来具体生产对象。
            var a = 100;
            var b = 200;
            var type = "+";
            var calculator = new AddFactory().GetCalculator();
            var result = calculator?.Calculate(a, b);
            Console.WriteLine($"a{type}b={result}");

            Console.ReadKey();
        }
    }
}
