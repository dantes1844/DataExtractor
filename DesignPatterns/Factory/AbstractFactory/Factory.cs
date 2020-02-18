using System.Collections.Generic;

namespace AbstractFactory
{
    /// <summary>
    ///     The 'AbstractFactory' abstract class
    /// </summary>
    internal abstract class ContinentFactory
    {
        public abstract Herbivore CreateHerbivore();
        public abstract Carnivore CreateCarnivore();

        public abstract Person CreateHunter();
    }

    /// <summary>
    ///     The 'ConcreteFactory1' class
    /// </summary>
    internal class AfricaFactory : ContinentFactory
    {
        public override Herbivore CreateHerbivore()
        {
            return new Wildebeest();
        }

        public override Carnivore CreateCarnivore()
        {
            return new Lion();
        }

        public override Person CreateHunter()
        {
            return new Hunter("非洲猎人");
        }
    }

    /// <summary>
    ///     The 'ConcreteFactory2' class
    /// </summary>
    internal class AmericaFactory : ContinentFactory
    {
        public override Herbivore CreateHerbivore()
        {
            return new Bison();
        }

        public override Carnivore CreateCarnivore()
        {
            return new Wolf();
        }

        public override Person CreateHunter()
        {
            return new Hunter("美洲猎人");
        }
    }
}