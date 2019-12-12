using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Configuration;
using System.Runtime.InteropServices;

namespace Unit14
{
    public class Analyzer
    {
        private List<double> _list;
        private readonly double _tolerance = 0;

        public delegate void BlunderFoundEventHandler(double value);
        public event BlunderFoundEventHandler BlunderFound;

        public Analyzer(double tolerance)
        {
            _list = new List<double>();
            _tolerance = tolerance;
        }

        public void Add(double value)
        {
            //в пустой список добавить значение безусловно
            //если добавляемое значение отличается от среднего арифметического, то вызвать событие и не добавлять число
            //иначе добавить
            if (_list.Count == 0)
                _list.Add(value);
            else
            {
                var average = Average();
                if ((value / average - 1) > _tolerance)
                {
                    BlunderFound?.Invoke(value);
                }
                else
                {
                    _list.Add(value);
                }
            }
        }

        public void Print()
        {
            foreach (var value in _list) 
            {
                Console.WriteLine($"{value:f4}");   
            }
            Console.WriteLine($"Average is {Average():f4}, tolerance is {_tolerance:f4}");
        }

        private double Average()
        {
            return (_list.Sum()/ _list.Count);
        }
    }
}