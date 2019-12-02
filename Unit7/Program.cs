using System;

namespace Unit7
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            Figure[] figures = {new Triangle(4f, 15.2f, 11.8f), new FourSquare(4.5), new Rhombus(8.2f, 50)};
            Drawing drawing = new Drawing(figures);

            try
            {
                foreach (Figure figure in drawing)
                {
                    Console.WriteLine("Perimeter of {0} is equals {1}", figure.FigureName, figure.Perimeter());
                }

                int i = 0;
                while (i < drawing.Count)
                {
                    Console.WriteLine("Square of {0} is equals {1}", drawing.figures[i].FigureName, drawing.figures[i].Square());
                    i++;
                }
                
            }
            catch (FigureCreationException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (NotImplementedException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}