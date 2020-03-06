using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Unit21JobExecutor
{
    public class JobExecutor : IJobExecutor
    {
        public int Amount => _queue.Count;       
        private readonly Queue<Action> _queue = new Queue<Action>();
        private readonly object _locker = new object();
        private bool _isRunning = false;
        private EventWaitHandle _eventWaitHandle = new AutoResetEvent(false);
        private Task _task;
        private Semaphore _semaphore;

        public void Add(Action action)
        {
            lock (_locker)
            {
                Console.WriteLine($"***Action {action.Method} added***"); 
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
            if (_isRunning)
            {
                Console.WriteLine("\nJob executor restarted.\n-----------------------");
                Stop();
            }

            _isRunning = true;
            _eventWaitHandle = new AutoResetEvent(false);
            _task = Task.Run(() => Work(maxConcurrent));
        }

        /// <summary>
        /// Non thread safety
        /// </summary>
        public void Stop()
        {
            if (!_isRunning)
            {
                Console.WriteLine("\nJob executor had already stop.\n-----------------------");
                return;
            }
            _isRunning = false;
            _eventWaitHandle.Set();       
            _task.Wait(); 

            _eventWaitHandle.Close();
            _task.Dispose();
            
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
                                try
                                {
                                    action.Invoke();
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine(ex.Message);
                                }
                                finally
                                {
                                    _semaphore.Release();
                                }
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
