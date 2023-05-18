using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_4_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Publisher publisher = new Publisher();

            Subscriber subscriber1 = new Subscriber("Subscriber1");
            Subscriber subscriber2 = new Subscriber("Subscriber2");
            Subscriber subscriber3 = new Subscriber("Subscriber3");

            publisher.Subscribe(2, subscriber1.EventHandler);
            publisher.Subscribe(1, subscriber2.EventHandler);
            publisher.Subscribe(3, subscriber3.EventHandler);

            for (int i = 0; i < 5; i++)
            {
                EventData eventData = new EventData
                {
                    EventName = "Event" + i,
                    TimeStamp = DateTime.Now
                };

                publisher.Publish(eventData);
            }

            publisher.Unsubscribe(2, subscriber1.EventHandler);
            publisher.Unsubscribe(1, subscriber2.EventHandler);
            publisher.Unsubscribe(3, subscriber3.EventHandler);

            Console.ReadLine();
        }
    }
}
