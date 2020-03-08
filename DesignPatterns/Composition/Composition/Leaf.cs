using System;
using System.Collections.Generic;
using System.Text;

namespace Composition
{
    public class Leaf : Component
    {
        public Leaf(string name) : base(name)
        {
        }

        public override void Add(Component component)
        {
            Console.WriteLine("叶子节点不具有此功能...");
        }

        public override void Remove(Component component)
        {
            Console.WriteLine("叶子节点不具有此功能...");
        }

        public override void Display(int depth)
        {
            Console.WriteLine(new string('-', depth) + name);
        }
    }
}
