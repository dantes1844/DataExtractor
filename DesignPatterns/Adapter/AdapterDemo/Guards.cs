using System;
using System.Collections.Generic;
using System.Text;

namespace AdapterDemo
{
    public class Guards : Player
    {
        public Guards(string name) : base(name)
        {
        }

        public override void Attack()
        {
            Console.WriteLine($"后卫{_playerName}进攻...");
        }

        public override void Defense()
        {
            Console.WriteLine($"后卫{_playerName}防守");
        }
    }

    public class Foreward : Player
    {
        public Foreward(string name) : base(name)
        {
        }

        public override void Attack()
        {
            Console.WriteLine($"前锋{_playerName}进攻");
        }

        public override void Defense()
        {
            Console.WriteLine($"前锋{_playerName}防守");
        }
    }

    public class Center : Player
    {
        public Center(string name) : base(name)
        {
        }

        public override void Attack()
        {
            Console.WriteLine($"$中锋{_playerName}进攻");
        }

        public override void Defense()
        {
            Console.WriteLine($"中锋{_playerName}防守");
        }
    }
}
