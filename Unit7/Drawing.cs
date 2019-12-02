using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace Unit7
{
    public class Drawing : IEnumerable<Figure>
    {
        public Figure[] figures { get;}
        public int Count { get; }

        public Drawing(Figure[] figures)
        {
            this.figures = figures;
            Count = figures.Length;
        }

        public IEnumerator<Figure> GetEnumerator()
        {
            return new FigureEnumerator(figures);
        }
        
        IEnumerator IEnumerable.GetEnumerator() => throw new NotImplementedException();
    }
}