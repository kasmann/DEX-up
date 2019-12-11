using System;
using System.Linq;
using System.Reflection;

namespace Unit_DeepCloning
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            var student1 = new Student()
            {
                FullName = "Jane Smith", 
                Ages = 18,
                Gender = new Gender("female"), 
                FellowshipHolder = true,
            };
            Console.WriteLine($"{student1.FullName} \t {student1.Ages} \t {student1.Gender.Value} \t {student1.FellowshipHolder}");

            var student2 = student1.Clone() as Student;
            Console.WriteLine($"{student2.FullName} \t {student2.Ages} \t {student2.Gender.Value} \t {student2.FellowshipHolder}");
            student2.FullName = "John Smith";
            student2.Gender.Value = "male";
            Console.WriteLine($"{student2.FullName} \t {student2.Ages} \t {student2.Gender.Value} \t {student2.FellowshipHolder}");
        }
    }
}