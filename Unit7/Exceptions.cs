using System;

namespace Unit7
{
    internal class FigureCreationException : Exception
    {
        public FigureCreationException(string message) 
            : base(message)
        { }
    }
}