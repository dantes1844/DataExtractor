using System;

namespace Composition
{
    class Program
    {
        static void Main(string[] args)
        {
            //Component root = new Composite("根节点");

            //Component branch = new Composite("分支1");
            //branch.Add(new Leaf("分支1的叶子1"));
            //branch.Add(new Leaf("分支1的叶子2"));

            //var branch1 = new Composite("分支2");
            //branch1.Add(new Leaf("叶子1"));
            //branch1.Add(new Leaf("叶子2"));

            //root.Add(branch);
            //root.Add(branch1);

            //root.Display(2);

            Leaf leaf = new Leaf("yezi");

            Leaf leaf2 = leaf;
            leaf2 = new Leaf("yezi");

            string a = "hello";
            string b = "hello";
            Console.WriteLine($"a=b={a == b}");
            Console.WriteLine($"a.Equals(b)={a.Equals(b)}");

            Console.WriteLine($"leaf2.Equals(leaf)={leaf2.Equals(leaf)}");
            Console.WriteLine($"leaf2 == leaf={leaf2 == leaf}");

            Console.ReadKey();

        }
    }
}
