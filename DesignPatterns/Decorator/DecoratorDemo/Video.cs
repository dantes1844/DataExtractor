using System;
using System.Collections.Generic;
using System.Text;

namespace DecoratorDemo
{
    /// <summary>
    /// 具体的Component，实现了基类的方法，并增加了自己的字段属性
    /// </summary>
    public class Video : LibraryItem
    {
        private readonly string _director;
        private readonly string _name;
        private readonly int _playTime;

        public Video(string name, string director, int playTime, int copies)
        {
            _director = director;
            _name = name;
            _playTime = playTime;
            Copies = copies;
        }

        public override void Display()
        {
            Console.WriteLine($"当前电影名称:《{_name}》");
            Console.WriteLine($"当前电影导演:《{_director}》");
            Console.WriteLine($"当前电影播放次数:{_playTime}次");
            Console.WriteLine($"当前电影剩余数量:{Copies}");
            Console.WriteLine("----------------------------------------");
        }
    }
}
