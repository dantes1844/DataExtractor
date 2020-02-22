using System;

namespace AdapterDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Player battier = new Foreward("Battier");
            battier.Attack();
            battier.Defense();

            Player tMac=new Guards("Tracy McGrady");
            tMac.Attack();
            tMac.Defense();

            Player yaoming = new TranslatorAdapter("Yaoming");
            yaoming.Attack();
            yaoming.Defense();

            Console.ReadKey();
        }
    }
}
