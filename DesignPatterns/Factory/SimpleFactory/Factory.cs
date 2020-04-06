using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleFactory
{

    /// <summary>
    /// 简单工厂，也叫静态工厂
    /// 1：获取对象的逻辑在工厂内部，客户端不可见
    /// 2：耦合性较强，新增了产品类后，工厂方法需要同步更新
    /// </summary>
    public class Factory
    {
        public Calculator GetCalculator(string type)
        {
            Calculator calculator = null;
            switch (type)
            {
                case "+":
                    calculator = new Add();
                    break;
                case "-":
                    calculator = new Sub();
                    break;
                case "*":
                    calculator = new Mulitplication();
                    break;
                case "/":
                    calculator = new Divide();
                    break;
            }

            return calculator;
        }


        public static Calculator GetCalculatorInstance(string type)
        {
            Calculator calculator = null;
            switch (type)
            {
                case "+":
                    calculator = new Add();
                    break;
                case "-":
                    calculator = new Add();
                    break;
                case "*":
                    calculator = new Add();
                    break;
                case "/":
                    calculator = new Add();
                    break;
            }

            return calculator;
        }
    }
}
