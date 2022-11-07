using System;

namespace Figure.Figures
{
    public sealed class Circle : IFigure
    {
        private readonly double radius;

        private Circle(double radius) => this.radius = radius;

        public double Area() => Math.PI * Math.Pow(radius, 2.0);

        public bool Equal(IFigure figure)
        {
            bool equal = false;

            if (figure is Circle other)
                equal = Math.Abs(radius - other.radius) < Tolerance.tolerance;

            return equal;
        }

        public static Circle Build(double radius)
        {
            if (radius < 0.0)
                throw new ArgumentException("The radius cannot be less than zero");

            return new Circle(radius);
        }
    }
}