using System;

namespace Unit9
{
    public class Triangle : IComparable<Triangle>
    {
        private double _ab;
        private double _bc;
        private double _ac;
        public string FigureName { get; }
        
        public Triangle(double ab, double bc, double ac)
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
            return (side1 < (side2 + side3) && side2 <(side1 + side3) && side3 < (side1 + side2));
        }
        
        private bool DifferenceChecked(double side1, double side2, double side3)
        {
            return (side1 > Math.Abs(side2 - side3) && side2 > Math.Abs(side1 - side3) && side3 > Math.Abs(side2 - side1));
        }

        public double Square()
        {
            var p = (_ab + _bc + _ac) / 2;
            return Math.Sqrt(p * (p - _ab) * (p - _bc) * (p - _ac));
        }

        public int CompareTo(Triangle other)
        {
            if (other == null)
            {
                throw new ArgumentNullException("Comparable object cannot be null.");
            }
            var difference = this.Square() - other.Square();

            if (difference > 0)
            {
                return 1;
            }

            if (difference < 0)
            {
                return -1;
            }
            
            return 0;
        }
    }
}