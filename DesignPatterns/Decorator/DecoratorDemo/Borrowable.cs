using System;
using System.Collections.Generic;
using System.Text;

namespace DecoratorDemo
{
    /// <summary>
    /// 具体的装饰器，继承自装饰器类，并重写了基类的方法，该方法默认是调用被装饰对象的方法
    /// 此处重写的方法先是调用了被装饰对象本身的方法，然后在其后面增加了新的实现
    /// 这样就在保留对象原有功能的基础上，在对象上增加了新的功能
    /// .NetFramework中的Attribute就是装饰器模式，在方法的前/后增加相应的功能
    /// </summary>
    public class Borrowable : Decorator
    {
        protected List<string> Borrowers = new List<string>();

        public Borrowable(LibraryItem libraryItem) : base(libraryItem)
        {
        }

        public void Borrow(string name)
        {
            Borrowers.Add(name);
            LibraryItem.Copies--;
        }

        public void ReturnItem(string name)
        {
            Borrowers.Remove(name);
            LibraryItem.Copies++;
        }

        public override void Display()
        {
            //调用对象本身的方法
            base.Display();

            //在对象本身功能后面，扩展其实现
            foreach (var borrower in Borrowers)
            {
                Console.WriteLine($"借阅者是:{borrower}");
            }
            Console.WriteLine("----------------------------------------");
        }
    }
}
