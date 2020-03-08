using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unit21JobExecutor
{
    public class NotificationQueue<T>
    {
        public int Count => _queue.Count;
        public delegate void QueueChanged(string message);
        public event QueueChanged Notification;

        private readonly Queue<T> _queue;

        public NotificationQueue()
        {
            _queue = new Queue<T>();
        }

        public NotificationQueue(Queue<T> queue)
        {
            _queue = queue;
        }

        public void Enqueue(T value)
        {
            _queue.Enqueue(value);
            Notification?.Invoke($"\nAction added.");
        }

        public T Dequeue()
        {            
            var value = _queue.Dequeue();
            if (_queue.Count == 0)
            {
                Notification?.Invoke("\nQueue empty.");
            }
            return value;
        }

        public void Clear()
        {
            _queue.Clear();
            Notification?.Invoke("\nQueue cleared.");
        }
    }
}
