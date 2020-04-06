namespace SimpleFactory
{
    /// <summary>
    ///     抽象产品类
    /// </summary>
    public abstract class Calculator
    {
        public abstract int Calculate(int a, int b);
    }

    public class Add : Calculator
    {
        public override int Calculate(int a, int b)
        {
            return a + b;
        }
    }

    public class Sub : Calculator
    {
        public override int Calculate(int a, int b)
        {
            return a - b;
        }
    }

    public class Mulitplication : Calculator
    {
        public override int Calculate(int a, int b)
        {
            return a * b;
        }
    }

    public class Divide : Calculator
    {
        public override int Calculate(int a, int b)
        {
            return b == 0 ? 0 : a / b;
        }
    }
}