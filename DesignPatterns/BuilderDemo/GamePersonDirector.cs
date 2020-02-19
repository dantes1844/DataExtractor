using System;
using System.Collections.Generic;
using System.Text;

namespace BuilderDemo
{
    public class GamePersonDirector
    {
        private GamePersonBuilder _gamePersonBuilder;

        public GamePersonDirector(GamePersonBuilder gamePersonBuilder)
        {
            _gamePersonBuilder = gamePersonBuilder;
        }

        public GamePerson Build()
        {
            _gamePersonBuilder.CreateHead();
            _gamePersonBuilder.CreateBody();
            _gamePersonBuilder.CreateHand();
            _gamePersonBuilder.CreateLeg();

            return _gamePersonBuilder.Build();
        }
    }
}
