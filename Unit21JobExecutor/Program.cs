using System;
using System.Threading;

namespace Unit21JobExecutor
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            JobExecutor jobExecutor = new JobExecutor();
            
            jobExecutor.Add(PrintHello);
            jobExecutor.Add(PrintWorking);
            jobExecutor.Add(PrintWorking);
            jobExecutor.Add(PrintWorking);
            jobExecutor.Add(PrintBye);
            
            jobExecutor.Start(3);
            Thread.Sleep(3000);
            jobExecutor.Stop();
            
            jobExecutor.Start(100);
            Thread.Sleep(10000);
            jobExecutor.Stop();
            
            jobExecutor.Start();
            Thread.Sleep(1000);
            jobExecutor.Stop();
            
            jobExecutor.Clear();
        }

        private static void PrintHello()
        {
            for (var i = 0; i < 5; i++)
            {
                Console.WriteLine("hello " + i);
            }
        }
        
        private static void PrintWorking()
        {
            for (var i = 0; i < 5; i++)
            {
                Console.WriteLine("working " + i);
            }
        }
        
        private static void PrintBye()
        {
            for (var i = 0; i < 5; i++)
            {
                Console.WriteLine("bye " + i);
            }
        }
    }
}