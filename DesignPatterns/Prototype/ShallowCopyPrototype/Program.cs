using System;

namespace ShallowCopyPrototype
{
    class Program
    {
        static void Main(string[] args)
        {
            Product p1 = new Product()
            {
                Name = "充电宝",
                Age = 1,
                Address = new Address()
                {
                    Province = "湖北",
                    City = "武汉",
                    District = "洪山区"
                }
            };
            Product p2 = (Product)p1.Clone();
            p2.Age = 2; //值复制
            p2.Name = "移动电源"; //值复制
            p2.Address.District = "江夏区";//引用的地址，修改之后原来的对象也跟随变化

            Console.WriteLine(p1);
            Console.WriteLine(p2);
            Console.ReadKey();
        }
    }
}
