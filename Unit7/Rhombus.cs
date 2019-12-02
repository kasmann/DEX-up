using System;

namespace Unit7
{
    public class Rhombus : FourSquare
    {
        private float _angle;
        public Rhombus(float a, float angle) : base(a)
        {
            if (Validated(angle))
            {
                _angle = angle;
                FigureName = "Rhombus";
            }
            else 
                throw new FigureCreationException("Error while creating rhombus.\nAngle should be less than 180 degrees.");
        }
        
        private bool Validated(double angle)
        {
            return (angle < 180);
        }

        public override double Square()
        {
            return _a * _a * Math.Sin(_angle * Math.PI / 180);
        }
        
        
    }
}