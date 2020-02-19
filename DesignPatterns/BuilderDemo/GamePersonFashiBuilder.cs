using System;
using System.Collections.Generic;
using System.Text;

namespace BuilderDemo
{
    public class GamePersonFashiBuilder : GamePersonBuilder
    {
        private readonly GamePerson _fashi=new GamePerson();
        public override void CreateHead()
        {
            var head = "法师的头：戴着法师帽";
            _fashi.Parts.Add(head);
            Console.WriteLine(head);
        }

        public override void CreateBody()
        {
            var body = "法师的身体：穿着道袍";
            _fashi.Parts.Add(body);
            Console.WriteLine(body);
        }

        public override void CreateHand()
        {
            var hand = "法师的手：左手拿魔法阵，右手拿念珠";
            _fashi.Parts.Add(hand);
            Console.WriteLine(hand);
        }

        public override void CreateLeg()
        {
            var leg = "法师的腿：穿着高跟鞋";
            _fashi.Parts.Add(leg);
            Console.WriteLine(leg);
        }

        public override GamePerson Build()
        {
            return _fashi;
        }
    }
}
