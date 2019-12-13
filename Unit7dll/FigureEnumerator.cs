using System;
using System.Collections;
using System.Collections.Generic;

namespace Unit7dll
{
    public class FigureEnumerator : IEnumerator<Figure>
    {
        private int _position;
        private readonly Figure[] _figures;

        public FigureEnumerator(Figure[] figures)
        {
            _figures = figures;
            _position = -1;
        }

        public bool MoveNext()
        {
            if (_position >= _figures.Length - 1)
            {
                return false;
            }
            _position++;
            return true;
        }

        public Figure Current
        {
            get
            {
                if (_position <= -1 || _position >= _figures.Length)
                {
                    throw new IndexOutOfRangeException();
                }

                return _figures[_position];
            }
        }

        object IEnumerator.Current => Current;

        public void Reset()
        {
            _position = -1;
        }
        
        public void Dispose() {}
    }
}