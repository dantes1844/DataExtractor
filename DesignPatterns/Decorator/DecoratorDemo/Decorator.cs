using System;
using System.Collections.Generic;
using System.Text;

namespace DecoratorDemo
{
    /// <summary>
    /// 装饰器基类，同样从Component中继承，并组合了一个Component的实例，用来调用Component本身的方法
    /// </summary>
    public abstract class Decorator : LibraryItem
    {
        protected readonly LibraryItem LibraryItem;

        protected Decorator(LibraryItem libraryItem)
        {
            this.LibraryItem = libraryItem;
        }

        public override void Display()
        {
            LibraryItem?.Display(); //调用实例的方法。即保留对象本身的方法
        }
    }
}
