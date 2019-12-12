using System;
using System.Collections.Generic;

namespace Unit11
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Dictionary<Person, string> catalog = new Dictionary<Person, string>
            {
                {new Person("John Smith", Convert.ToDateTime("01.01.1990"), "New York", 195), "New York Times"},
                {new Person("Jane Smith", Convert.ToDateTime("02.02.1992"), "Los Angeles", 207), "Lotte New York Palace"},
                {new Person("Adam Walker", Convert.ToDateTime("05.05.1985"), "Louisville", 114), "New York Times"},
                {new Person("Ann Clark", Convert.ToDateTime("11.11.1991"), "Washington", 196), "New York Stock Exchange"},
                {new Person("Eric Carter", Convert.ToDateTime("06.03.1970"), "Long-Beach", 81), "RG Bicycles"},
                {new Person("John Smith", Convert.ToDateTime("09.09.1999"), "Miami", 260), "Metropolitan Opera"}
            };
            
            //цикл с выходом по нажатию Escape
            do
            {
                Console.WriteLine("Enter  person's fullname:");
                string fullname = Console.ReadLine();
                
                Console.WriteLine("Enter  person's date of birth:");//             
                DateTime.TryParse(Console.ReadLine(), out DateTime dateOfBirth);

                Console.WriteLine("Enter  person's place of birth:");
                string placeOfBirth = Console.ReadLine();
                
                Console.WriteLine("Enter  person's passport ID:");
                uint.TryParse(Console.ReadLine(), result: out uint passportID);

                Person lookingFor = new Person(fullname, dateOfBirth, placeOfBirth, passportID);

                if (catalog.ContainsKey(lookingFor))
                {
                    Console.WriteLine($"Place of work is {catalog[lookingFor]}.\n\n" +
                                      "Press Enter to repeat search, press Escape to exit...");
                }
                else
                {
                    Console.WriteLine("The catalog does not contain information about this person.\n\n" +
                                      "Press Enter to repeat search, press Escape to exit...");
                }
                
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }
    }
}