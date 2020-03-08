using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Unit21JobExecutor
{
    public class JobExecutor : IJobExecutor, IDisposable
    {
        public int Amount => _nqueue.Count;
        private readonly object _locker = new object();
        private bool _isRunning = false;
        private EventWaitHandle _eventWaitHandle = new AutoResetEvent(false);
        private Task _task;
        private Semaphore _semaphore;
        private readonly NotificationQueue<Action> _nqueue = new NotificationQueue<Action>();

        public void Add(Action action)
        {
            lock (_locker)
            {
                _nqueue.Enqueue(action);
            }

            _eventWaitHandle.Set();
        }

        public void Clear()
        {
            lock (_locker)
            {
                _nqueue.Clear();
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
                throw new JobExecutorStarted("\nJob executor is already started.");
            }

            _isRunning = true;
            _eventWaitHandle = new AutoResetEvent(false);
            _task = Task.Run(() => Work(maxConcurrent));

            _nqueue.Notification += ShowNotification;
            
            Console.WriteLine("\nJob executor started.");
        }

        /// <summary>
        /// Non thread safety
        /// </summary>
        public void Stop()
        {
            if (!_isRunning)
            {
                throw new JobExecutorStopped("\nJob executor is already stopped or hasn't been started.");
            }

            _isRunning = false;
            _eventWaitHandle.Set();
            _task.Wait(); 
                        
            Console.WriteLine("\nJob executor stopped.");
        }

        public void Dispose()
        {
            if (_isRunning) Stop();
            _eventWaitHandle.Close();
            _task.Dispose();
            _nqueue.Notification -= ShowNotification;
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
                        if (_nqueue.Count > 0)
                        {
                            action = _nqueue.Dequeue();
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
                                    Console.WriteLine($"An error occurred while executing the method {action.Method}.\n{ex.Message}");
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
            }
        }

        private static void ShowNotification(string message)
        {
            Console.WriteLine(message);
        }
    }
}
