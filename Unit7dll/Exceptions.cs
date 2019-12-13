using System;

namespace Unit7dll
{
    internal class FigureCreationException : Exception
    {
        public FigureCreationException(string message) : base(message)
        { }
    }
}