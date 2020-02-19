using System;

namespace DeepCopyPrototype
{
    public class Product : ICloneable
    {
        public string Name { get; set; }

        public int Age { get; set; }


        public Address Address { get; set; }

        public object Clone()
        {
            var address = (Address)Address.Clone();
            var product = (Product)MemberwiseClone();
            product.Address = address;
            return product;
        }

        public override string ToString()
        {
            return $"{Name}-{Age}-{Address}";
        }
    }

    public class Address : ICloneable
    {
        public string Province { get; set; }

        public string City { get; set; }

        public string District { get; set; }

        public override string ToString()
        {
            return $"{Province}-{City}-{District}";
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
