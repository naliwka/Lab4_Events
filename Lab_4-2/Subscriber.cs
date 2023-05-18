using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_4_2
{
    public class Subscriber
    {
        private string name;

        public Subscriber(string name)
        {
            this.name = name;
        }

        public void EventHandler(EventData eventData)
        {
            Console.WriteLine($"{name} handled event: {eventData.EventName} - {eventData.TimeStamp}");
        }
    }
}
