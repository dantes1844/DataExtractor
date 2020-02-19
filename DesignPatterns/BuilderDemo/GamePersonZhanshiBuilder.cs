using System;
using System.Collections.Generic;
using System.Text;

namespace BuilderDemo
{
    public class GamePersonZhanshiBuilder : GamePersonBuilder
    {
        private readonly GamePerson _zhanshi = new GamePerson();

        public override void CreateHead()
        {
            var head = "战士的头：戴着头盔";
            _zhanshi.Parts.Add(head);
            Console.WriteLine(head);
        }

        public override void CreateBody()
        {
            var body = "战士的身体：穿着盔甲";
            _zhanshi.Parts.Add(body);
            Console.WriteLine(body);
        }

        public override void CreateHand()
        {
            var hand = "战士的手：拿着大刀和盾牌";
            _zhanshi.Parts.Add(hand);
            Console.WriteLine(hand);
        }

        public override void CreateLeg()
        {
            var leg = "战士的腿：绑着绑腿";
            _zhanshi.Parts.Add(leg);
            Console.WriteLine(leg);
        }

        public override GamePerson Build()
        {
            return _zhanshi;
        }
    }
}
