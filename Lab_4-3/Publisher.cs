using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Lab_4_3
{
    public class Publisher
    {
        private Dictionary<string, List<Action<EventData>>> eventSubscribers;

        public Publisher()
        {
            eventSubscribers = new Dictionary<string, List<Action<EventData>>>();
        }

        public void Subscribe(string eventName, Action<EventData> eventHandler)
        {
            if (!eventSubscribers.ContainsKey(eventName))
            {
                eventSubscribers[eventName] = new List<Action<EventData>>();
            }

            eventSubscribers[eventName].Add(eventHandler);
        }
        public void Unsubscribe(string eventName, Action<EventData> eventHandler)
        {
            if (eventSubscribers.ContainsKey(eventName))
            {
                eventSubscribers[eventName].Remove(eventHandler);

                if (eventSubscribers[eventName].Count == 0)
                {
                    eventSubscribers.Remove(eventName);
                }
            }
        }
        public void Publish(EventData eventData, RetryPolicy retryPolicy)
        {
            if (eventSubscribers.ContainsKey(eventData.EventName))
            {
                List<Action<EventData>> eventHandlers = eventSubscribers[eventData.EventName];

                // Сортування обробників за пріоритетом (від найвищого до найнижчого)
                eventHandlers.Sort((eh1, eh2) => GetPriority(eh2).CompareTo(GetPriority(eh1)));

                foreach (var eventHandler in eventHandlers)
                {
                    TryExecuteWithRetry(() => eventHandler(eventData), retryPolicy);
                }
            }
        }
        private void TryExecuteWithRetry(Action action, RetryPolicy retryPolicy)
        {
            int attempt = 0;
            int delay = retryPolicy.InitialDelay;

            while (attempt <= retryPolicy.MaxAttempts)
            {
                try
                {
                    action();
                    return;
                }
                catch (Exception ex)
                {
                    attempt++;

                    if (attempt > retryPolicy.MaxAttempts)
                    {
                        // Перевищено максимальну кількість спроб, виходимо з циклу
                        Console.WriteLine($"Error: {ex.Message}");
                        break;
                    }

                    // Затримка перед наступною спробою з урахуванням рандомізації
                    int randomizedDelay = (int)(delay * (1 + retryPolicy.RandomizationFactor * (new Random().NextDouble() - 0.5)));
                    Thread.Sleep(randomizedDelay);
                }
                delay = (int)Math.Min(delay * retryPolicy.BackoffMultiplier, retryPolicy.MaxDelay);
            }
        }
        private int GetPriority(Action<EventData> eventHandler)
        {
            if (eventHandler.Target is Subscriber subscriber)
            {
                return subscriber.Priority;
            }

            return 0;
        }
    }
}
