using System;
using System.Linq;
using System.Reflection;

namespace Unit_DeepCloning
{
//    internal static class Program
//    {
//        public static void Main(string[] args)
//        {
//            var student1 = new Student()
//            {
//                FullName = "Jane Smith", 
//                Ages = 18,
//                Gender = new Gender("female"), 
//                FellowshipHolder = true,
//            };
//            Console.WriteLine($"{student1.FullName} \t {student1.Ages} \t {student1.Gender.Value} \t {student1.FellowshipHolder}");
//
//            var student2 = student1.Clone() as Student;
//            Console.WriteLine($"{student2.FullName} \t {student2.Ages} \t {student2.Gender.Value} \t {student2.FellowshipHolder}");
//            student2.FullName = "John Smith";
//            student2.Gender.Value = "male";
//            Console.WriteLine($"{student2.FullName} \t {student2.Ages} \t {student2.Gender.Value} \t {student2.FellowshipHolder}");
//        }
//    }

    internal class My : IEquatable<My>
    {
        public readonly string A, B, C;
        private readonly string _d;
        private string E { get; set; }
        public int[] Ints { get; set; }
 
        public My(string a, string b, string c, string d, string e)
        {
            A = a;
            B = b;
            C = c;
            _d = d;
            E = e;
        }
 
        public bool Equals(My other)
        {
            return A == other.A && B == other.B && C == other.C && _d == other._d && E == other.E;
        }
 
        public override string ToString()
        {
            return string.Format("{0} {1} {2}", A, B, C);
        }
    }
 
    public class Program
    {
        private static void Main()
        {
            int[] ints = {1, 2, 3};
            My my = new My("ABC", "hello", "world", "wowow", "aba") {Ints = ints};
            Console.WriteLine(my + "\n\n");
 
            My another = my.Clone();
            Console.WriteLine(another);
 
            if (ReferenceEquals(my, another))
                Console.WriteLine("Same object");
            else
                Console.WriteLine("Another object");
            Console.WriteLine(my.Equals(another));
 
            Console.ReadKey();
        }
    }
}