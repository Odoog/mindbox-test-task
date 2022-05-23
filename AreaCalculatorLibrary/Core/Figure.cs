namespace AreaCalculatorLibrary.Core
{
    public abstract class Figure : IFigure
    {
        public const double Epsilon = 0.000001;
        public abstract double GetArea();
    }
}