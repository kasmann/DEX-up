using System;
using System.Text.RegularExpressions;

namespace Unit20
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            string textSample = 
                "Размеры у    китообразных наибольшие среди   млекопитающих: средняя длина тела синего кита 25 м, вес — 90—120 т. " + 
                "Самые маленькие китообразные   — белобрюхий дельфин и   дельфин Гектора, относящиеся к роду пёстрых дельфинов (Cephalorhynchus): " +
                "длина тела у них     не превышает 120 см, масса — 45 кг.";
            
            Console.WriteLine(textSample);
            var found = Regex.Matches(textSample, @"\d{1,}"); //десятичная цифра 1 или более раз подряд - число
            foreach (var match in found)
            {
                Console.WriteLine(match);
            }

            var found2 = Regex.Matches(@"http://ya.ru/api?r=1&x=23", @"\w*=\w*"); //параметры со значениями
            
            foreach (var match in found2)
            {
                Console.WriteLine(match);
            }
            
            var found3 = Regex.Replace(textSample, @"\s+", " "); //
            Console.WriteLine(found3);
            
            var pattern = @"(\+373|0 ?\(| *|)77[4-9](\) *| *|)(\d{5})$";
            Console.WriteLine(Regex.IsMatch(@"+373 77956789", pattern));
            Console.WriteLine(Regex.IsMatch(@"+373 779 56789", pattern));
            Console.WriteLine(Regex.IsMatch(@"+373 (779) 56789", pattern));
            Console.WriteLine(Regex.IsMatch(@"0 (779)  56789", pattern));
            Console.WriteLine(Regex.IsMatch(@"077956789", pattern));
            Console.WriteLine(Regex.IsMatch(@"77956789", pattern));
            Console.WriteLine(Regex.IsMatch(@"0 779 56789", pattern));
            Console.WriteLine(Regex.IsMatch(@"0(779)56789", pattern));
            Console.WriteLine(Regex.IsMatch(@"0(779)567899999999", pattern));
            Console.WriteLine(Regex.IsMatch(@"0(773)56789", pattern));
            
        }
    }
}