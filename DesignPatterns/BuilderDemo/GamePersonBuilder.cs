using System;
using System.Collections.Generic;
using System.Text;

namespace BuilderDemo
{
    public abstract class GamePersonBuilder
    {
        public abstract void CreateHead();

        public abstract void CreateBody();

        public abstract void CreateHand();

        public abstract void CreateLeg();

        public abstract GamePerson Build();
    }
}
