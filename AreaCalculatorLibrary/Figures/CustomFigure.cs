using System;
using System.Collections.Generic;
using System.Linq;
using AreaCalculatorLibrary.Core;

namespace AreaCalculatorLibrary.Figures
{
    /// <summary>
    /// A figure described by a set of its points.
    /// Allows to calculate the area without knowing the type. 
    /// </summary>
    public sealed class CustomFigure : Figure
    {
        private readonly IList<(double X, double Y)> _dots;

        public CustomFigure(IList<(double X, double Y)> dots)
        {
            _dots = dots;
        }

        public override double GetArea() {
            
            var area = 0d;

            for (int i = 0; i < _dots.Count() - 1; i++)
            {
                area += _dots[i].X * _dots[i + 1].Y 
                        - _dots[i].Y * _dots[i + 1].X;
            }

            area += _dots[^1].X * _dots[0].Y 
                    - _dots[^1].Y * _dots[0].X;

            return Math.Abs(area) / 2;
        }
    }
}