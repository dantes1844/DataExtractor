using System;
using System.Collections.Generic;
using System.Text;

namespace DecoratorDemo
{
    /// <summary>
    /// 具体的Component，实现了基类，并增加了自己的字段属性
    /// </summary>
    public class Book:LibraryItem
    {
        private readonly string _name;
        private readonly string _author;

        public Book(string name,string author, int copies)
        {
            _name = name;
            _author = author;
            Copies = copies;
        }

        public override void Display()
        {
            Console.WriteLine($"当前书籍名称:{_name}");
            Console.WriteLine($"当前书籍作者:{_author}");
            Console.WriteLine($"当前书籍剩余数量:{Copies}");
            Console.WriteLine("----------------------------------------");
        }
    }
}
