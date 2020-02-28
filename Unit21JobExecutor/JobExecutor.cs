using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;

using System.Security.Permissions;

namespace Unit21JobExecutor
{
    public class JobExecutor : IJobExecutor
    {
        public int Amount => _queue.Count;
        private readonly EventWaitHandle _eventWaitHandle = new AutoResetEvent(false);
        private readonly Queue<Action> _queue = new Queue<Action>();
        private readonly object _locker = new object();
        private Thread _worker = null;
        private Semaphore _semaphore;
        private bool _isRunning;

        public void Add(Action action)
        {
            lock (_locker)
            {
                _queue.Enqueue(action);
            }

            _eventWaitHandle.Set();
        }

        public void Clear()
        {
            lock (_locker)
            {
                _queue.Clear();
            }
        }

        /// <summary>
        /// Non thread safety
        /// </summary>
        /// <param name="maxConcurrent"></param>
        public void Start(int maxConcurrent = 1)
        {
            if (_worker == null)
            {
                Console.WriteLine("-----------------------\nJob executor started.\n");

                _isRunning = true;
                _worker = new Thread(Work);
                _worker.Start(maxConcurrent);
            }
            else
            {
                Console.WriteLine("-----------------------\nJob executor is already started!\n");
            }
        }

        /// <summary>
        /// Non thread safety
        /// </summary>
        public void Stop()
        {
            _isRunning = false;
            _eventWaitHandle.Set();
            
            _worker.Join();
            _eventWaitHandle.Close();
            
            
            Console.WriteLine("\nJob executor stopped.\n-----------------------");
        }
        
        private void Work(object maxConcurrent)
        {
            using (_semaphore = new Semaphore((int) maxConcurrent, (int) maxConcurrent))
            {
                while (_isRunning)
                {
                    Action action = null;

                    lock (_locker)
                    {
                        if (_queue.Count > 0)
                        {
                            action = _queue.Dequeue();
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

               // _worker = null; // он нам не нужен после заверщения метода, даем возможность GC его удалить, но у тебя завязана на нем логика, попробуй переделать
            }
        }

    }
}
