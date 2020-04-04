using System;

namespace Recursion
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = 6;
            var result = Fibonacci(n);

            Console.WriteLine($"Fibonacci({n})={result}");

            Console.ReadKey();
        }

        public static int executedCount = 1;

        private static int Fibonacci(int n)
        {
            Console.WriteLine($"=============================执行次数：{executedCount++}");
            if (n < 0)
            {
                Console.WriteLine("n<0 了 直接返回。");
                return 0;
            }

            if (n <= 2)
            {
                Console.WriteLine($"n={n}, n <= 2, 返回1。");
                return 1;
            }

            Console.WriteLine($"分而治之-1:Fibonacci({n} - 1)");
            var num2 = Fibonacci(n - 1);
            Console.WriteLine($"Fibonacci({n} - 1)={num2}");

            Console.WriteLine($"分而治之-2:Fibonacci({n} - 2)");
            var num1 = Fibonacci(n - 2);
            Console.WriteLine($"Fibonacci({n} - 2)={num1}");

            Console.WriteLine($">>>>>>>>>>>>>>>>>>>>>>>>>>>>  n={n},Fibonacci({n})= {num1}+{num2}={num1 + num2}");
            Console.WriteLine();

            return num2 + num1;
        }
    }
}
