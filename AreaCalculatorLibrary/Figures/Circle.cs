using System;
using AreaCalculatorLibrary.Core;

namespace AreaCalculatorLibrary.Figures
{
    public class Circle : Figure
    {
        private readonly (double X, double Y)? _center;
        private readonly double _radius;

        public Circle(
            double radius,
            (double x, double y)? center = null
        )
        {
            if (radius <= 0)
            {
                throw new ArgumentException("Circles radius length should be positive");
            }
            
            _radius = radius;
            _center = center;
        }

        public override double GetArea()
            => Math.PI * _radius * _radius;
    }
}