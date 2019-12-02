using System;

namespace Unit9
{
    internal class FigureCreationException : Exception
    {
        public FigureCreationException(string message) 
            : base(message)
        { }
    }
}