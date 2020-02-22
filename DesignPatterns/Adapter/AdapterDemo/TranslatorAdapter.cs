using System;
using System.Collections.Generic;
using System.Text;

namespace AdapterDemo
{
    public class TranslatorAdapter : Player
    {
        private readonly ForeignCenter _foreignCenter = new ForeignCenter();

        public TranslatorAdapter(string name) : base(name)
        {
            _foreignCenter.Name = name;
        }

        public override void Attack()
        {
            _foreignCenter.Jingong();
        }

        public override void Defense()
        {
            _foreignCenter.Fangshou();
        }
    }
}
