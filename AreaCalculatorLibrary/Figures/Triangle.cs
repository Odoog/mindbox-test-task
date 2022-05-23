using System;
using System.Collections.Generic;
using System.Linq;
using AreaCalculatorLibrary.Core;

namespace AreaCalculatorLibrary.Figures
{
    public class Triangle : Figure
    {
        private readonly List<double> _orderedSides;
        private double Perimeter => _orderedSides.Sum();

        public Triangle(
            double side1,
            double side2,
            double side3) : this(new List<double>() { side1, side2, side3 })
        {
        }

        public Triangle(List<double> sides)
        {
            if (sides.Count != 3)
            {
                throw new ArgumentException("Triangle sides length should be positive");
            }

            if (sides.Any(side => side <= 0))
            {
                throw new ArgumentException("Triangle sides length should be positive");
            }

            _orderedSides = sides
                    .OrderByDescending(side => side)
                    .ToList();
        }

        public override double GetArea()
        {
            if (IsRightTriangle)
                return _orderedSides[1] * _orderedSides[2] / 2;
            
            var halfPerimeter = Perimeter / 2;
            return Math.Sqrt(halfPerimeter
                             * (halfPerimeter - _orderedSides[0]) 
                             * (halfPerimeter - _orderedSides[1]) 
                             * (halfPerimeter - _orderedSides[2]));
        }

        private bool IsRightTriangle
            => Math.Abs(
                _orderedSides[0] * _orderedSides[0] 
                - _orderedSides[1] * _orderedSides[1] 
                - _orderedSides[2] * _orderedSides[2]
                ) < Epsilon;
    }
}