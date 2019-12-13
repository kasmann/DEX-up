using System;

namespace Unit19
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string message)
            : base(message) {}
    }
}