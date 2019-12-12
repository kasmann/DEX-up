using System;
using System.Data.SqlTypes;

namespace Unit10
{
    public class Person
    {
        public string FullName { get; }
        public DateTime DateOfBirth { get; }
        public string PlaceOfBirth { get; }
        public uint PassportID { get; }

        public Person(string fullName, DateTime dateOfBirth, string placeOfBirth, uint passportId)
        {
            if (String.IsNullOrEmpty(fullName))
            {
                throw new PersonCreationException("Person cannot be unnamed!");
            }
            FullName = fullName;

            if (dateOfBirth < DateTime.MinValue || dateOfBirth > DateTime.MaxValue)
            {
                throw new PersonCreationException("Incorrect value of date of birth");
            }
            DateOfBirth = dateOfBirth;
            
            if (String.IsNullOrEmpty(placeOfBirth))
            {
                throw new PersonCreationException("Place of birth cannot be empty");
            }
            PlaceOfBirth = placeOfBirth;
            
            if (passportId == 0)
            {
                throw new PersonCreationException("Passport ID cannot be empty");
            }
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

        public static bool operator ==(Person p1, Person p2)
        {
            return p1.Equals(p2);
        }
        
        public static bool operator !=(Person p1, Person p2)
        {
            return !(p1.Equals(p2));
        }
        public override int GetHashCode()
        {
            return (int) PassportID;
        }
    }
}