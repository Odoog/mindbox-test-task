using System;
using System.Linq;
using AreaCalculatorLibrary.Core;
using AreaCalculatorLibrary.Figures;
using AutoFixture;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AreaCalculatorUnitTests
{
    [TestClass]
    public class AreaCalculatorTests
    {
        private readonly Fixture _fixture = new();
        
        [TestMethod]
        [DataRow(3, 4, 5, 6)] // Right triangle.
        [DataRow(1, 1, 0.518, 0.250162)] // Isosceles triangle with both sides equals 1 and angle 30° between them. 
        public void TriangleCalculateArea_ShouldBeCorrect(
            double side1,
            double side2,
            double side3,
            double area)
        {
            // arrange
            var triangle = new Triangle(side1, side2, side3);
            // act
            var receivedArea = triangle.GetArea();
            // assert
            receivedArea.Should().BeInRange(area - Figure.Epsilon, area + Figure.Epsilon);
        }
        
        [TestMethod]
        public void TriangleCalculateArea_SideLengthIsNegative_ShouldBeException()
        {
            // arrange
            Action creation = () =>
                new Triangle(
                    _fixture.Create<uint>(),
                    _fixture.Create<uint>(),
                    -_fixture.Create<uint>());
            
            // assert
            creation.Should().Throw<ArgumentException>().WithMessage("Triangle sides length should be positive");
        }
        
        [TestMethod]
        [DataRow(1, Math.PI)]
        [DataRow(10, Math.PI * 100)]
        public void CircleCalculateArea_ShouldBeCorrect(
            double radius,
            double area)
        {
            // arrange
            var circle = new Circle(radius);
            // act
            var receivedArea = circle.GetArea();
            // assert
            receivedArea.Should().BeInRange(area - Figure.Epsilon, area + Figure.Epsilon);
        }
        
        [TestMethod]
        [DataRow(1, 
            new double[]{0, 0}, 
            new double[]{0, 1}, 
            new double[]{1, 1}, 
            new double[]{1, 0})] // Square.
        [DataRow(0.5, 
            new double[]{0, 0}, 
            new double[]{0, 1}, 
            new double[]{1, 0})] // Triangle - half of the square.
        public void CustomFigureCalculateArea_ShouldBeCorrect(double area, params double[][] dots)
        {
            // arrange
            var circle = new CustomFigure(dots.Select(dot => (dot[0], dot[1])).ToList());
            // act
            var receivedArea = circle.GetArea();
            // assert
            receivedArea.Should().BeInRange(area - Figure.Epsilon, area + Figure.Epsilon);
        }
    }
}