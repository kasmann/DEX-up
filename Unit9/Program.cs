using System;
using System.Data.SqlTypes;

namespace Unit9
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            //инициализация константами, чтобы каждая фигура прошла валидацию (основное свойство треугольника)
           Triangle[] triangles = new Triangle[]
           {
               new Triangle(18.2, 4.3, 16.23),
               new Triangle(66.58, 48.97, 27.11),
               new Triangle(3,4,5),
               new Triangle(10, 11, 12),
               new Triangle(4.44, 5.55, 6.66),
               new Triangle(75.3, 45.21, 49.65),
               new Triangle(7.12, 8.13, 9.14),
               new Triangle(33.3, 66.6, 88.8),
               new Triangle(4.92, 17.3, 15.11),
               new Triangle(5.23, 5.34, 5.45) 
           };
            
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Triangle{0}: {1:f4}", i, triangles[i].Square());
            }
            
            Array.Sort(triangles, new TriangleComparer());
            
            Console.WriteLine();
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Triangle{0}: {1:f4}", i, triangles[i].Square());
            }
        }
    }
}