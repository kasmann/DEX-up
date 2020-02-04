using System;
using System.Threading;

namespace Unit21JobExecutor
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            JobExecutor jobExecutor = new JobExecutor();
            
            jobExecutor.Add(PrintHello);
            jobExecutor.Add(PrintWorking);
            jobExecutor.Add(PrintBye);
            jobExecutor.Add(PrintBye2);
                        
            jobExecutor.Start(3);
            
            
            jobExecutor.Stop();
            Thread.Sleep(5000);
        }

        private static void PrintHello()
        {
            for (var i = 0; i < 5; i++)
            {
                Console.WriteLine($"Метод PrintHello выполняется в потоке {Thread.CurrentThread.ManagedThreadId}");
            }
        }
        
        private static void PrintWorking()
        {
            for (var i = 0; i < 5; i++)
            {
                Console.WriteLine($"Метод PrintWorking выполняется в потоке {Thread.CurrentThread.ManagedThreadId}");
                Thread.Sleep(500);
            }
        }
        
        private static void PrintBye()
        {
            for (var i = 0; i < 5; i++)
            {
                Console.WriteLine($"Метод PrintBye выполняется в потоке {Thread.CurrentThread.ManagedThreadId}");
                Thread.Sleep(1000);
            }
        }
        
        private static void PrintBye2()
        {
            for (var i = 0; i < 5; i++)
            {
                Console.WriteLine($"Метод PrintBye2 выполняется в потоке {Thread.CurrentThread.ManagedThreadId}");
            }
        }
    }
}