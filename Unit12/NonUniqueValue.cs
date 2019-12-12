using System;

namespace Unit12
{
    public class NonUniqueValue : Exception
    {
        public NonUniqueValue(string message) : base(message)
        { }
    }
}