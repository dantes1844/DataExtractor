using System;

namespace AbstractFactory
{
    #region 产品A

    /// <summary>
    ///     The 'AbstractProductA' abstract class
    /// </summary>
    internal abstract class Herbivore
    {
    }
    /// <summary>
    ///     The 'ProductA1' class
    /// </summary>
    internal class Wildebeest : Herbivore
    {
    }

    /// <summary>
    ///     The 'ProductA2' class
    /// </summary>
    internal class Bison : Herbivore
    {
    }

    #endregion

    #region 产品B

    /// <summary>
    ///     The 'AbstractProductB' abstract class
    /// </summary>
    internal abstract class Carnivore
    {
        public abstract void Eat(Herbivore h);
    }

    /// <summary>
    ///     The 'ProductB1' class
    /// </summary>
    internal class Lion : Carnivore
    {
        public override void Eat(Herbivore h)
        {
            // Eat Wildebeest
            Console.WriteLine($"{ GetType().Name} eats {h.GetType().Name}");
        }
    }

    /// <summary>
    ///     The 'ProductB2' class
    /// </summary>
    internal class Wolf : Carnivore
    {
        public override void Eat(Herbivore h)
        {
            // Eat Bison
            Console.WriteLine($"{ GetType().Name} eats {h.GetType().Name}");
        }
    }

    #endregion

    #region 产品C

    /// <summary>
    /// 增加一个抽象产品
    /// </summary>
    internal abstract class Person
    {
        public abstract void Hunt(Carnivore c);
    }

    internal class Hunter:Person
    {
        private readonly string _hunterName;
        public Hunter(string name)
        {
            _hunterName = name; 
        }
        public override void Hunt(Carnivore c)
        {
            Console.WriteLine($"{_hunterName} 打猎 {c.GetType().Name}");
        }
    }

    #endregion

    #region 客户端，相当于业务层，调用数据库层逻辑

    /// <summary>
    ///     客户端
    /// </summary>
    internal class AnimalWorld
    {
        //相当于一个数据库中的若干表实体(组合关系)
        private readonly Herbivore _herbivore;
        private readonly Carnivore _carnivore;
        private readonly Person _person;

        /// <summary>
        /// 此时的工厂实例就相当于数据库实例
        /// </summary>
        /// <param name="factory"></param>
        public AnimalWorld(ContinentFactory factory)
        {
            _carnivore = factory.CreateCarnivore();
            _herbivore = factory.CreateHerbivore();
            _person = factory.CreateHunter();
        }

        public void RunFoodChain()
        {
            _person.Hunt(_carnivore);
            _carnivore.Eat(_herbivore);
        }
    } 

    #endregion
}