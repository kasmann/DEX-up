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
            
            jobExecutor.Add(PrintWorking);
            jobExecutor.Add(PrintBye);
            
            jobExecutor.Add(PrintWorking);
            jobExecutor.Start(5);
            jobExecutor.Add(PrintHello);
            jobExecutor.Add(PrintBye);
            
            jobExecutor.Stop();
        }

        private static void PrintHello()
        {
            Console.WriteLine("Hello!");
        }
        
        private static void PrintWorking()
        {
            Console.WriteLine("Working...");
        }
        
        private static void PrintBye()
        {
            Console.WriteLine("Bye!");
        }
    }
}