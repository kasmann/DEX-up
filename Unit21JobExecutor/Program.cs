using System;
using System.Threading;

namespace Unit21JobExecutor
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            JobExecutor jobExecutor = new JobExecutor();

            jobExecutor.Add(Foo1);
            jobExecutor.Add(Foo2);
            jobExecutor.Add(Foo3);
            jobExecutor.Add(Foo4);
            jobExecutor.Add(Foo2);
            jobExecutor.Add(Foo3);

            jobExecutor.Start(3);

            Thread.Sleep(4000);

            jobExecutor.Add(Foo4);

            jobExecutor.Stop();
        }

        private static void Foo1()
        {
            for (var i = 0; i < 3; i++)
            {
                Console.WriteLine($"Метод Foo1 выполняется в потоке {Thread.CurrentThread.ManagedThreadId}");
                Thread.Sleep(500);
            }
        }

        private static void Foo2()
        {
            for (var i = 0; i < 3; i++)
            {
                Console.WriteLine($"Метод Foo2 выполняется в потоке {Thread.CurrentThread.ManagedThreadId}");
                Thread.Sleep(500);
            }
        }

        private static void Foo3()
        {
            for (var i = 0; i < 3; i++)
            {
                Console.WriteLine($"Метод Foo3 выполняется в потоке {Thread.CurrentThread.ManagedThreadId}");
                Thread.Sleep(500);
            }
        }

        private static void Foo4()
        {
            for (var i = 0; i < 3; i++)
            {
                Console.WriteLine($"Метод Foo4 выполняется в потоке {Thread.CurrentThread.ManagedThreadId}");
                Thread.Sleep(500);
            }
        }
    }
}