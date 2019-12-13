using System;
using System.IO;
using System.Reflection;

namespace Unit18
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Assembly asm = null;
            Type triangle = null;
            try
            {
                asm = Assembly.LoadFrom(@"D:/Аня/github/DexCourses/Unit9/bin/debug/Unit9.exe");
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine($"Файл сборки не найден.\n{e.Message}");
            }

            if (asm == null) return;
            
            try
            {
                triangle = asm.GetType("Unit9.Triangle", false, true);
                
            }
            catch (NullReferenceException e)
            {
                Console.WriteLine($"Указанный класс отсутствует в загруженной сборке.\n{e.Message}");
            }
                
            if (triangle == null) return;

            var newTriangle1 = Activator.CreateInstance(triangle, 4.2f, 5.1f, 6.4f);
            var newTriangle2 = Activator.CreateInstance(triangle, 9.8f, 10f, 0.5f);
            
            var triangleSquareMethod = triangle.GetMethod("Square");
            var square1 = triangleSquareMethod.Invoke(newTriangle1, null);
            var square2 = triangleSquareMethod.Invoke(newTriangle2, null);
            Console.WriteLine(square1);
            Console.WriteLine(square2);
            
            var triangleCompareToMethod = triangle.GetMethod("CompareTo");
            
            //1 - объект, на котором вызывается метод, больше передаваемого
            //0 - равны
            //-1 объект, на котором вызывается метод, меньше передаваемого
            var isTrianglesEqual = triangleCompareToMethod.Invoke(newTriangle1, new[] {newTriangle2});
        
            var result = ((int)isTrianglesEqual>-1)?((int)isTrianglesEqual == 0?"equal":"larger"):"smaller";
            Console.WriteLine($"newTriangle1 is {result} than newTriangle2\n");
           
            
            //информация о непубличных методах
            var privateMethods = triangle.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);
            foreach (MethodInfo mi in privateMethods)
            {
                Console.WriteLine(mi);
            }
            Console.WriteLine();
            
            //вызов приватного метода с параметрами
            var privateValidationMethod = triangle.GetMethod("Validated", BindingFlags.Instance | BindingFlags.NonPublic);
            var isValidated = privateValidationMethod.Invoke(newTriangle1, new object[] {1f, 1f, 5f});
            Console.WriteLine("Validated: " + isValidated);
        }
    }
}