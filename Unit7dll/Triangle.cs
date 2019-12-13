using System;

namespace Unit7dll
{
    public class Triangle : Figure
    {
        private float _ab;
        private float _bc;
        private float _ac;
        
        public Triangle(float ab, float bc, float ac)
        {
            if (Validated(ab, bc, ac))
            {
                _ab = ab;
                _bc = bc;
                _ac = ac;
                FigureName = "Triangle";
            }
            else 
                throw new FigureCreationException("Error while creating triangle.\nWrong values of sides.");
        }

        private bool Validated(double ab, double bc, double ac)
        {
            return SumChecked(ab, bc, ac) && DifferenceChecked(ab, bc, ac);
        }

        private bool SumChecked(double side1, double side2, double side3)
        {
            return side1 < (side2 + side3);
        }
        
        private bool DifferenceChecked(double side1, double side2, double side3)
        {
            return side1 > (side2 - side3);
        }

        public override double Square()
        {
            var p = (_ab + _bc + _ac) / 2;
            return Math.Sqrt(p * (p - _ab) * (p - _bc) * (p - _ac));
        }

        public override double Perimeter()
        {
            return _ab + _bc + _ac;
        }
    }
}