using System;
using System.Collections.Generic;
using System.Text;

namespace PrototypeDemo
{
    public class Product : ICloneable
    {
        public string Name { get; set; }

        public int Age { get; set; }


        public Address Address { get; set; }

        public object Clone()
        {
            return MemberwiseClone();
        }

        public override string ToString()
        {
            return $"{Name}-{Age}-{Address}";
        }
    }

    public class Address
    {
        public string Province { get; set; }

        public string City { get; set; }

        public string District { get; set; }

        public override string ToString()
        {
            return $"{Province}-{City}-{District}";
        }
    }
}
