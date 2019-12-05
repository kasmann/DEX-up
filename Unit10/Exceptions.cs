using System;

namespace Unit10
{
    public class PersonCreationException : Exception
    {
        public PersonCreationException(string message) 
            : base(message)
        { }
    }
}