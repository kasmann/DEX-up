using System;
using System.Collections.Generic;
using System.Threading;

namespace Unit21
{
    public class JobExecutor : IJobExecutor
    {
        public int Amount { get; private set; }

        private delegate void _del();
        
        private Queue<Action> _queue;

        public JobExecutor()
        {
            Amount = 0;
            _queue = new Queue<Action>();
            ThreadPool.SetMaxThreads(0, 0);
        }

        public void Add(Action action)
        {
            _queue.Enqueue(action);
            Amount++;
            Thread t = new Thread(new ThreadStart(action));
        }

        public void Clear()
        {
            _queue.Clear();
            Amount = 0;
        }

        public void Start(int maxConcurrent)
        {
           ThreadPool.SetMaxThreads(maxConcurrent, maxConcurrent);
        }

        public void Stop() {}
    }
}