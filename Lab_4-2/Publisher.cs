using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_4_2
{
    internal class Publisher
    {
        private Dictionary<int, List<Action<EventData>>> eventHandlers;

        public Publisher()
        {
            eventHandlers = new Dictionary<int, List<Action<EventData>>>();
        }

        public void Subscribe(int priority, Action<EventData> eventHandler)
        {
            if (!eventHandlers.ContainsKey(priority))
            {
                eventHandlers[priority] = new List<Action<EventData>>();
            }

            eventHandlers[priority].Add(eventHandler);
        }
        public void Unsubscribe(int priority, Action<EventData> eventHandler)
        {
            if (eventHandlers.ContainsKey(priority))
            {
                eventHandlers[priority].Remove(eventHandler);

                if (eventHandlers[priority].Count == 0)
                {
                    eventHandlers.Remove(priority);
                }
            }
        }
        public void Publish(EventData eventData)
        {
            List<int> priorities = new List<int>(eventHandlers.Keys);
            priorities.Sort();

            foreach (int priority in priorities)
            {
                foreach (var handler in eventHandlers[priority])
                {
                    handler(eventData);
                }
            }
        }
    }   
}
