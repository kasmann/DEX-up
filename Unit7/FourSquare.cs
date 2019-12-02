namespace Unit7
{
    public class FourSquare : Figure
    { 
        protected double _a;

        public FourSquare(double a)
        {
            if (Validated(a))
            {
                _a = a;
                FigureName = "Foursquare";
            }
            else 
                throw new FigureCreationException("Error while creating square.\nSide should be above 0.");
        }

        private bool Validated(double a)
        {
            return a > 0;
        }

        public override double Square()
        {
            return _a * _a;
        }

        public override double Perimeter()
        {
            return 4 * _a;
        }
    }
}