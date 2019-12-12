using System;
using System.Collections.Generic;
using System.ComponentModel;
using Unit14.Annotations;

namespace Unit14
{
    public class NotificationQueue<T> : INotifyPropertyChanged
    {

        public Queue<T> Queue { get; }
        public int MaxLength { get; }
        
        public delegate void QueueChanged(string message);
        
        public event QueueChanged Notification;
        public event PropertyChangedEventHandler PropertyChanged;


        public NotificationQueue(int maxLength = 1)
        {
            Queue = new Queue<T>();
            MaxLength = maxLength;
        }
        
        public NotificationQueue(Queue<T> queue, int maxLength)
        {
            Queue = queue;
            MaxLength = maxLength;
        }

        public void Add(T value)
        {
            if (Queue.Count == MaxLength)
            {
                Notification?.Invoke("Queue full. Cannot add value.");
            }
            else
            {
                Queue.Enqueue(value);
                OnPropertyChanged("Queue");
            }
        }

        public void Clear()
        {
            Queue.Clear();
            Notification?.Invoke("Queue cleared");
        }
        
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}