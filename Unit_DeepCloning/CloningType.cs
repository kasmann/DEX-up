using System;

namespace Unit_DeepCloning
{
    public class Student : ICloneable
    {
        public string FullName;
        public int Ages;
        public bool FellowshipHolder;
        public Gender Gender;

        public object Clone()
        {
            var stud = MemberwiseClone() as Student;
            stud.Gender = this.Gender.Clone() as Gender;
            return stud;
        }
    }

    public class Gender : ICloneable
    {
        public string Value { get; set; }

        public Gender(string male)
        {
            Value = male;
        }
        
        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}