using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Lab_4_1
{
    public class EventThrottler
    {
        private Dictionary<string, List<Action<EventData>>> eventHandlers;
        private Dictionary<string, DateTime> lastEventTimes;
        private int throttleIntervalMs;

        public EventThrottler(int throttleIntervalMs)
        {
            this.throttleIntervalMs = throttleIntervalMs;
            eventHandlers = new Dictionary<string, List<Action<EventData>>>();
            lastEventTimes = new Dictionary<string, DateTime>();
        }

        public void Subscribe(string eventName, Action<EventData> eventHandler)
        {
            if (!eventHandlers.ContainsKey(eventName))
            {
                eventHandlers[eventName] = new List<Action<EventData>>();
                lastEventTimes[eventName] = DateTime.MinValue;
            }
            eventHandlers[eventName].Add(eventHandler);
        }

        public void Unsubscribe(string eventName, Action<EventData> eventHandler)
        {
            if (eventHandlers.ContainsKey(eventName))
            {
                eventHandlers[eventName].Remove(eventHandler);
            }
            if (eventHandlers[eventName].Count == 0)
            {
                eventHandlers.Remove(eventName);
                lastEventTimes.Remove(eventName);
            }
        }
        public void Publish(string eventName, EventData eventData)
        {
            if (!eventHandlers.ContainsKey(eventName))
                return;

            DateTime currentTime = DateTime.Now;
            DateTime lastEventTime = lastEventTimes[eventName];

            if ((currentTime - lastEventTime).TotalMilliseconds < throttleIntervalMs)
                return;

            lastEventTimes[eventName] = currentTime;
            foreach (var handler in eventHandlers[eventName])
            {
                ThreadPool.QueueUserWorkItem(_ =>
                {
                    handler(eventData);
                });
            }
        }
    }
}
