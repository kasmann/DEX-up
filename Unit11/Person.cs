using System;
using System.Data.SqlTypes;

namespace Unit11
{
    public class Person
    {
        public string FullName { get; }
        public DateTime DateOfBirth { get; }
        public string PlaceOfBirth { get; }
        public uint PassportID { get; }

        public Person(string fullName, DateTime dateOfBirth, string placeOfBirth, uint passportId)
        {
            FullName = fullName;
            DateOfBirth = dateOfBirth;
            PlaceOfBirth = placeOfBirth;
            PassportID = passportId;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Person))
            {
                return false;
            }

            var tmp = (Person) obj;
            if (!tmp.FullName.Equals(FullName))
            {
                return false;
            }

            if (tmp.DateOfBirth != DateOfBirth)
            {
                return false;
            }

            if (!tmp.PlaceOfBirth.Equals(PlaceOfBirth))
            {
                return false;
            }

            if (tmp.PassportID != PassportID)
            {
                return false;
            }
            
            return true;
        }

        public override int GetHashCode()
        {
            return (int) PassportID;
        }
    }
}