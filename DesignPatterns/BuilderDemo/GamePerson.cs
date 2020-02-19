using System.Collections.Generic;

namespace BuilderDemo
{
    public class GamePerson
    {
        public List<string> Parts { get; set; }

        public GamePerson()
        {
            Parts = new List<string>();
        }
    }
}