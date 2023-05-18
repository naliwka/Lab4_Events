using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_4_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Publisher publisher = new Publisher();
            RetryPolicy retryPolicy = new RetryPolicy
            {
                MaxAttempts = 3,
                InitialDelay = 1000,
                MaxDelay = 5000,
                BackoffMultiplier = 2,
                RandomizationFactor = 0.5
            };
            Subscriber subscriber1 = new Subscriber("Subscriber1", 2);
            Subscriber subscriber2 = new Subscriber("Subscriber2", 1);
            Subscriber subscriber3 = new Subscriber("Subscriber3", 3);

            publisher.Subscribe("Event0", eventData =>
            {
                Console.WriteLine($"{subscriber1.Name} handled event: {eventData.EventName} - {eventData.TimeStamp}");
            });
            publisher.Subscribe("Event0", eventData =>
            {
                Console.WriteLine($"{subscriber2.Name} handled event: {eventData.EventName} - {eventData.TimeStamp}");
            });
            publisher.Subscribe("Event0", eventData =>
            {
                Console.WriteLine($"{subscriber3.Name} handled event: {eventData.EventName} - {eventData.TimeStamp}");
            });

            publisher.Subscribe("Event1", eventData =>
            {
                Console.WriteLine($"{subscriber1.Name} handled event: {eventData.EventName} - {eventData.TimeStamp}");
            });
            publisher.Subscribe("Event1", eventData =>
            {
                Console.WriteLine($"{subscriber2.Name} handled event: {eventData.EventName} - {eventData.TimeStamp}");
            });
            publisher.Subscribe("Event1", eventData =>
            {
                Console.WriteLine($"{subscriber3.Name} handled event: {eventData.EventName} - {eventData.TimeStamp}");
            });

            publisher.Subscribe("Event2", eventData =>
            {
                Console.WriteLine($"{subscriber1.Name} handled event: {eventData.EventName} - {eventData.TimeStamp}");
            });
            publisher.Subscribe("Event2", eventData =>
            {
                Console.WriteLine($"{subscriber2.Name} handled event: {eventData.EventName} - {eventData.TimeStamp}");
            });
            publisher.Subscribe("Event2", eventData =>
            {
                Console.WriteLine($"{subscriber3.Name} handled event: {eventData.EventName} - {eventData.TimeStamp}");
            });
            publisher.Subscribe("Event3", eventData =>
            {
                Console.WriteLine($"{subscriber1.Name} handled event: {eventData.EventName} - {eventData.TimeStamp}");
            });
            publisher.Subscribe("Event3", eventData =>
            {
                Console.WriteLine($"{subscriber2.Name} handled event: {eventData.EventName} - {eventData.TimeStamp}");
            });
            publisher.Subscribe("Event3", eventData =>
            {
                Console.WriteLine($"{subscriber3.Name} handled event: {eventData.EventName} - {eventData.TimeStamp}");
            });

            publisher.Subscribe("Event4", eventData =>
            {
                Console.WriteLine($"{subscriber1.Name} handled event: {eventData.EventName} - {eventData.TimeStamp}");
            });
            publisher.Subscribe("Event4", eventData =>
            {
                Console.WriteLine($"{subscriber2.Name} handled event: {eventData.EventName} - {eventData.TimeStamp}");
            });
            publisher.Subscribe("Event4", eventData =>
            {
                Console.WriteLine($"{subscriber3.Name} handled event: {eventData.EventName} - {eventData.TimeStamp}");
            });

            EventData errorEvent = new EventData { EventName = "ErrorEvent", TimeStamp = DateTime.Now };
            publisher.Publish(errorEvent, retryPolicy);

            EventData event0 = new EventData { EventName = "Event0", TimeStamp = DateTime.Now };
            EventData event1 = new EventData { EventName = "Event1", TimeStamp = DateTime.Now };
            EventData event2 = new EventData { EventName = "Event2", TimeStamp = DateTime.Now };
            EventData event3 = new EventData { EventName = "Event3", TimeStamp = DateTime.Now };
            EventData event4 = new EventData { EventName = "Event4", TimeStamp = DateTime.Now };

            publisher.Publish(event0, retryPolicy);
            publisher.Publish(event1, retryPolicy);
            publisher.Publish(event2, retryPolicy);
            publisher.Publish(event3, retryPolicy);
            publisher.Publish(event4, retryPolicy);

            Console.ReadLine();
        }
    }
}
