using System;
using System.Collections.Generic;
using System.Text;

namespace DecoratorDemo
{
    /// <summary>
    /// 模式中的Component
    /// 有自己的属性和方法
    /// </summary>
    public abstract class LibraryItem
    {
        public int Copies { get; set; }

        public abstract void Display();
    }
}
