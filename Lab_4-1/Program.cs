using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Lab_4_1
{
    internal class Program
    {
        private static void eventHandler(EventData eventData)
        {
            Console.WriteLine($"Unsubscribed from Event1: {eventData.EventName} - {eventData.TimeStamp}");
        }
        static void Main(string[] args)
        {
            EventThrottler eventBus = new EventThrottler(1000); // Інтервал обмеження: 1 секунда

            
            eventBus.Subscribe("Event1", eventData =>
            {
                Console.WriteLine($"Event1 handled: {eventData.EventName} - {eventData.TimeStamp}");
            });

            
            eventBus.Subscribe("Event2", eventData =>
            {
                Console.WriteLine($"Event2 handled: {eventData.EventName} - {eventData.TimeStamp}");
            });
            
            for (int i = 0; i < 10; i++)
            {
                EventData eventData = new EventData
                {
                    EventName = i % 2 == 0 ? "Event1" : "Event2",
                    TimeStamp = DateTime.Now
                };

                eventBus.Publish(eventData.EventName, eventData);

                Thread.Sleep(500);

                eventBus.Unsubscribe("Event1", eventHandler);

                
                EventData eventDataAfterUnsubscribe = new EventData
                {
                    EventName = "Event1",
                    TimeStamp = DateTime.Now
                };
                eventBus.Publish(eventDataAfterUnsubscribe.EventName, eventDataAfterUnsubscribe);

                Console.ReadLine();
            }
        }
    }
}
