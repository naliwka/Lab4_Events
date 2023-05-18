using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_4_3
{
    public class Subscriber
    {
        public string Name { get; set; }
        public int Priority { get; set; }
        public Subscriber(string name, int priority)
        {
            Name = name;
            Priority = priority;
        }
    }
}
