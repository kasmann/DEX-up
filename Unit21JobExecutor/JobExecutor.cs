using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;

using System.Security.Permissions;

namespace Unit21JobExecutor
{
    public class JobExecutor : IJobExecutor
    {
        public int Amount { get; private set; }
        private readonly EventWaitHandle _eventWaitHandle = new AutoResetEvent(false);
        private readonly Queue<Action> _queue = new Queue<Action>();
        private readonly object _locker = new object();
        private Thread _worker = null;
        private Semaphore _semaphore;

        public JobExecutor()
        {
            Amount = 0;
        }

        public void Add(Action action)
        {
            lock (_locker)
            {
                _queue.Enqueue(action);
                Amount = _queue.Count;
            }

            _eventWaitHandle.Set();
        }

        public void Clear()
        {
            lock (_locker)
            {
                _queue.Clear();
                Amount = 0;
            }
        }

        public void Start(int maxConcurrent = 1)
        {
            if (_worker == null)
            {
                Console.WriteLine("-----------------------\nJob executor started.\n");

                _worker = new Thread(Work);
                _worker.Start(maxConcurrent);
            }
            else
            {
                Console.WriteLine("-----------------------\nJob executor is already started!\n");
            }
        }

        private void Work(object maxConcurrent)
        {
            _semaphore = new Semaphore((int)maxConcurrent, (int)maxConcurrent);

            while (true)
            {
                Action action = null;

                lock (_locker)
                {
                    if (_queue.Count > 0)
                    {
                        action = _queue.Dequeue();
                        Amount = _queue.Count;
                        if (action == null) return;
                    }
                }

                if (action != null)
                {
                    ThreadPool.QueueUserWorkItem(
                            (object unused) =>
                            {
                                _semaphore.WaitOne();
                                action();
                                _semaphore.Release();
                            });
                }
                else
                {
                    _eventWaitHandle.WaitOne();
                }
            }
        }


        public void Stop()
        {
            Add(null);
            _worker.Join();
            _eventWaitHandle.Close();
            _semaphore.Dispose();
            Console.WriteLine("\nJob executor stopped.\n-----------------------");
        }
    }
}
