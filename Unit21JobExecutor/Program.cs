using System;
using System.Threading;

namespace Unit21JobExecutor
{
    internal static class Program
    {
        private static  int _count = 3;

        public static void Main(string[] args)
        {
            using (JobExecutor jobExecutor = new JobExecutor())
            {
                try
                {
                    jobExecutor.Stop();
                }
                catch (JobExecutorStopped ex)
                {
                    Console.WriteLine(ex.Message);
                }

                jobExecutor.Add(Foo1);
                jobExecutor.Add(Foo2);
                jobExecutor.Add(Foo3);
                jobExecutor.Add(Foo4);
                jobExecutor.Add(Foo3);
                jobExecutor.Add(Foo2);

                try
                {
                    jobExecutor.Start(3);
                }
                catch (JobExecutorStarted ex)
                {
                    Console.WriteLine(ex.Message);
                }

                Thread.Sleep(4000);

                jobExecutor.Add(Foo4);
                jobExecutor.Add(Foo3);
                jobExecutor.Add(Foo2);
                jobExecutor.Add(Foo1);

                try
                {
                    jobExecutor.Start(2);
                }
                catch (JobExecutorStarted ex)
                {
                    Console.WriteLine(ex.Message);
                }

                //try
                //{
                //    jobExecutor.Stop();
                //    jobExecutor.Stop();
                //}
                //catch (JobExecutorStopped ex)
                //{
                //    Console.WriteLine(ex.Message);
                //}
            }
        }

        private static void Foo1()
        {
            throw new Exception("dropped");
        }

        private static void Foo2()
        {
            for (var i = 0; i < _count; i++)
            {
                Console.WriteLine($"Метод Foo2 выполняется в потоке {Thread.CurrentThread.ManagedThreadId}");
                Thread.Sleep(500);
            }
        }

        private static void Foo3()
        {
            for (var i = 0; i < _count; i++)
            {
                Console.WriteLine($"Метод Foo3 выполняется в потоке {Thread.CurrentThread.ManagedThreadId}");
                Thread.Sleep(500);
            }
        }

        private static void Foo4()
        {
            for (var i = 0; i < _count; i++)
            {
                Console.WriteLine($"Метод Foo4 выполняется в потоке {Thread.CurrentThread.ManagedThreadId}");
                Thread.Sleep(500);
            }
        }
    }
}