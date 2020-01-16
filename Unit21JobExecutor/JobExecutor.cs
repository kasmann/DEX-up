using System;
using System.Collections.Generic;
using System.Threading;

namespace Unit21JobExecutor
{
    public class JobExecutor : IJobExecutor
    {
        public int Amount { get; private set; }

        private readonly Queue<Action> _queue;
        private Thread[] _threads;

        public JobExecutor()
        {
            Amount = 0;
            _queue = new Queue<Action>();
            ThreadPool.SetMaxThreads(0, 0);
        }

        public void Add(Action action)
        {
            _queue.Enqueue(action);
            Amount = _queue.Count;
        }

        public void Clear()
        {
            if (_queue.Count == 0)
            {
                Console.WriteLine("Job executor already clear.");
            }
            else
            {
                _queue.Clear();
                Amount = _queue.Count;
                Console.WriteLine("-----------------------\nJob executor cleared.\n-----------------------");
            }
        }

        public void Start(int maxConcurrent = 1)
        {
            if (_queue.Count == 0)
            {
                Console.WriteLine("Job executor is empty.");
            }
            else
            {
                Console.WriteLine("-----------------------\nJob executor started.\n");

                ThreadPool.SetMaxThreads(maxConcurrent, maxConcurrent);

                
                var arrayLength = maxConcurrent > _queue.Count ? _queue.Count : maxConcurrent;
                _threads = new Thread[arrayLength];
                var _queueCopy = new Queue<Action>(_queue);
                
                for (var i=0; i<_threads.Length; i++)
                {
                    _threads[i] = new Thread(new ThreadStart(_queueCopy.Dequeue())) {Name = "thread" + i};
                    _threads[i].Start();
                    Console.WriteLine("Thread {0} started.", _threads[i].Name);
                }
            }
        }

        public void Stop()
        {
            if (_queue.Count == 0)
            {
                Console.WriteLine("Job executor is empty.");
            }
            else
            {
                foreach (var thread in _threads)
                {
                    thread.Abort();
                    Console.WriteLine("Thread {0} aborted.", thread.Name);
                }

                ThreadPool.SetMaxThreads(0, 0);
                Console.WriteLine("\nJob executor stopped.\n-----------------------");
            }
        }
    }
}