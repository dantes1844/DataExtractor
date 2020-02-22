using System;
using System.Collections.Generic;
using System.Text;

namespace AdapterDemo
{
    public abstract class Player
    {
        protected string _playerName;

        public Player(string name)
        {
            this._playerName = name;
        }

        public abstract void Attack();

        public abstract void Defense();
    }
}
