namespace FactoryMethod
{
    /// <summary>
    ///     简单工厂里，获取对象的逻辑在其中
    ///     而工厂方法则是将对象获取的逻辑放到具体的子类里
    ///     客户端决定实例化哪个工厂，再由工厂生成具体的子类
    /// </summary>
    public abstract class Factory
    {
        public abstract Calculator GetCalculator();
    }

    public class AddFactory : Factory
    {
        public override Calculator GetCalculator()
        {
            return new Add();
        }
    }

    public class SubFactory : Factory
    {
        public override Calculator GetCalculator()
        {
            return new Sub();
        }
    }

    public class MuliplicationFactory : Factory
    {
        public override Calculator GetCalculator()
        {
            return new Mulitplication();
        }
    }

    public class DivideFactory : Factory
    {
        public override Calculator GetCalculator()
        {
            return new Divide();
        }
    }
}