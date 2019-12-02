using System.Collections.Specialized;

namespace Unit8
{
    public class Student
    {
        public string ID { get; }
        public int Ages { get; }
        public int Year { get; }
        
        public int MissingsCount { get; }
        public float AverageMark { get; }
        public bool FellowshipHolder { get; }

        public Student(string id, int ages, int year, int missingsCount, float averageMark, bool fellowshipHolder)
        {
            ID = id;
            Ages = ages;
            Year = year;
            MissingsCount = missingsCount;
            AverageMark = averageMark;
            FellowshipHolder = fellowshipHolder;
        }
    }
}