using System;

namespace Unit10
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Person p1 = new Person("Иванов Иван Иванович", Convert.ToDateTime("10.01.1990"), "Молдова, г. Тирасполь", 195);
            Person p2 = new Person("Петров Петр Петрович", Convert.ToDateTime("15.05.1985"), "Молдова, г. Тирасполь", 197);
            Person p3 = new Person("Иванов Иван Иванович", Convert.ToDateTime("10.01.1990"), "Молдова, г. Тирасполь", 195);
           
            Console.WriteLine(p1.GetHashCode());
            Console.WriteLine(p2.GetHashCode());
            Console.WriteLine(p3.GetHashCode());
            
            Console.WriteLine(p1.Equals(p2));
            Console.WriteLine(p1.Equals(p3));
            Console.WriteLine(p2.Equals(p3));
        }
    }
}