using System;
using System.Linq;
using System.Reflection;

namespace Unit_DeepCloning
{
    public static class Program
    {
        private static void Main()
        {
            Student student1 = new Student("Jane Smith", 23, true, new Gender("female"));
            Console.WriteLine(student1);

            Student student2 = new Student();
            
            try
            {
                student2 = student1.Clone();
            }
            catch (NotSupportedException e)
            {
                Console.WriteLine(e.Message);
            }

            Console.WriteLine(student2);

            Console.WriteLine(ReferenceEquals(student1, student2) ? "Same object" : "Another object");
            Console.WriteLine(student1.Equals(student2));
        }
    }
}