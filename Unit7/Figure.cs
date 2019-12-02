namespace Unit7
{
    public abstract class Figure
    {
        public string FigureName { get; set; }
        public abstract double Square();

        public abstract double Perimeter();
    }
}