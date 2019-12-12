using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Unit12
{
    public class UniqueCollection<T> : IEnumerable<T>
    {
        private readonly List<T> _values = new List<T>();
        
        public UniqueCollection(IEnumerable<T> values)
        {
            foreach (var value in values)
            {
                if (_values.Contains(value))
                {
                    throw new NonUniqueValue("Incoming collection contains nonunique elements.");
                }
                _values.Add(value);
            }
        }

        public void Add(T value)
        {
            if (_values.Contains(value))
            {
                throw new NonUniqueValue($"Collection already contains same value.");
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public IEnumerator<T> GetEnumerator()
        {
            return _values.GetEnumerator();
        }
    }
}