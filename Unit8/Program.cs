using System;
using System.Linq;

namespace Unit8
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Student[] students = new Student[100];
            GenerateStudents(ref students);
            
            //студенты возрастом от 18 до 20 лет
            var studentsElder20 = students.Where(t => t.Ages <= 20 && t.Ages >= 18).OrderBy(t => t.ID);
            Console.WriteLine("\nStudents between 18 and 20 ages");
            foreach (var student in studentsElder20)
            {
                Console.WriteLine("ID {0}, ages {1}", student.ID, student.Ages);
            }
            
            //третьекурсники с ID на букву G
            var gStudentsOf3Year = students.Where(t => t.ID.StartsWith("G") && t.Year == 3).OrderBy(t => t.ID);
            Console.WriteLine("\nStudents of 3rd year with ID starts with G");
            foreach (var student in gStudentsOf3Year)
            {
                Console.WriteLine("ID {0}", student.ID);
            }
            
            //стипендиаты с группировкой по курсу
            var fellowshipHoldersByYear =
                students.Where(t => t.FellowshipHolder).OrderBy(t => t.Year).GroupBy(t => t.Year);
            Console.WriteLine("\nFellowshipholders grouping by year");
            foreach (IGrouping<int, Student> g in fellowshipHoldersByYear)
            {
                Console.WriteLine("\nYear: {0}", g.Key);
                foreach (var student in g)
                {
                    Console.WriteLine("ID: {0}", student.ID);
                }
            }
            
            //число 18-летних студентов 2 курса
            var numberOfStudents2Year18Ages = students.Count(t => t.Ages == 18 && t.Year == 2);
            Console.WriteLine("\n2nd year students 18 ages: {0}", numberOfStudents2Year18Ages);

            //минимальный средний балл среди стипендиатов
            var minAverageMarkOfFellowshipHolders = students.Where(t => t.FellowshipHolder).Min(t => t.AverageMark);
            Console.WriteLine("\nMin average mark of fellowship holders: {0:f2}\n", minAverageMarkOfFellowshipHolders);
            
            //максимальный средний балл на каждом курсе
            for (int year = 1; year <= 4; year++)
            {
                var maxAverageMark = students.Where(t => t.Year == year).Max(t => t.AverageMark);
                Console.WriteLine("Max average mark in year {0} is {1:f2}", year, maxAverageMark);
            }

            var missingsOfStudents1Year = students.Where(t => t.Year == 1).Sum(t => t.MissingsCount);
            Console.WriteLine("\nSum of missings of 1st year student: {0}", missingsOfStudents1Year);

            //есть в списке студентов ID = "G43"?
            var isAnyIDG43 = students.Any(t => t.ID == "G43");
            if (isAnyIDG43)
            {
                Console.WriteLine("\nID \"G43\" exists.");
            }
            else
            {
                Console.WriteLine("\nID \"G43\" doesn't exist.");
            }
            
            //все ли третьекурсники совершеннолетние?
            var isAll3YearStudentsAdults = students.Where(t => t.Year == 3).All(t => t.Ages >= 21);
            if (isAll3YearStudentsAdults)
            {
                Console.WriteLine("\nAll of 3rd year students are adult.");
            }
            else
            {
                Console.WriteLine("\nNot all of 3rd year students are adult.");
            }
        }

        static void GenerateStudents(ref Student[] students)
        {
            var rand = new Random();
            
            //ID студента вида "N63" - буква + 2 цифры
            string id;
            int ages;
            int year;
            int missingsCount;
            float averageMark;
            bool fellowshipHolder;
            
            for (int i = 0; i < students.Length; i++)
            {
                id = ((char) rand.Next('A', 'Z' + 1)).ToString() + rand.Next(10, 100);
                ages = rand.Next(18, 25);
                year = rand.Next(1, 5);
                averageMark = (float) (rand.NextDouble() + rand.Next(0, 5));
                fellowshipHolder = rand.Next(0, 2) > 0;
                missingsCount = rand.Next(0, 15);
                students[i] = new Student(id, ages, year, missingsCount, averageMark, fellowshipHolder);
            }
        }
    }
}