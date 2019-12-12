using System;

namespace Unit13
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Predicate<int> isPositive = delegate (int x) { return x > 0; };
 
            Console.WriteLine(isPositive(20));
            Console.WriteLine(isPositive(-20));
        }
    }
}