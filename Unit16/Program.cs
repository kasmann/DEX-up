using System;
using System.Threading;

namespace Unit16
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var test = new Test();
            test.Dispose();
            
            test.name = "new name";
            Console.WriteLine(test.name);
            
            test.name = "changed name";
            test.Dispose();
            
            Console.WriteLine(test.name);
        }
    }

    public class Test : IDisposable
    {
        public string name;
        public void Dispose()
        {
            Console.WriteLine("disposed");
        }
    }
}