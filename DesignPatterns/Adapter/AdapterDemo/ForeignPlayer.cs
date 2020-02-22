using System;
using System.Collections.Generic;
using System.Text;

namespace AdapterDemo
{
    public class ForeignCenter
    {
        public string Name { get; set; }

        public void Jingong()
        {
            Console.WriteLine($"中国球员{Name}进攻");
        }

        public void Fangshou()
        {
            Console.WriteLine($"中国球员{Name}防守");
        }
    }
}
