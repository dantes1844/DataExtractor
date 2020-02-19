using System;

namespace BuilderDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            GamePersonDirector director = new GamePersonDirector(new GamePersonFashiBuilder());
            var fashi = director.Build();

            foreach (var fashiPart in fashi.Parts)
            {
                Console.WriteLine($"法师创建了:{fashiPart}");
            }

            Console.ReadKey();
        }
    }
}
