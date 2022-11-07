using System;
using System.Linq;

namespace Figure.Figures
{
    public sealed class Triangle : IFigure
    {
        private readonly double[] sides;

        private Triangle(double[] sides) => this.sides = sides;

        public bool IsRectangular()
        {
            double squares = Math.Pow(sides[0], 2) + Math.Pow(sides[1], 2);
            double hypotenuseSquare = Math.Pow(sides[2], 2);

            return Math.Abs(hypotenuseSquare - squares) < Tolerance.tolerance;
        }

        public double Area()
        {
            double halfArea = (sides[0] + sides[1] + sides[2]) / 2.0;

            return Math.Sqrt(halfArea * ((halfArea - sides[0]) * (halfArea - sides[1]) * (halfArea - sides[2])));
        }

        public bool Equal(IFigure figure)
        {
            bool equal = false;

            if (figure is Triangle other)
            {
                equal = true;

                for (int i = 0; i < sides.Length && equal == true; ++i)
                    if (Math.Abs(sides[i] - other.sides[i]) > Tolerance.tolerance)
                        equal = false;
            }

            return equal;
        }

        private static bool Exists(double[] sides)
        {
            bool firstPair = sides[0] + sides[1] < sides[2];
            bool secondPair = sides[0] + sides[2] < sides[1];
            bool thirdPair = sides[1] + sides[2] < sides[0];

            return firstPair || secondPair || thirdPair;
        }

        public static Triangle Build(double firstSide, double secondSide, double thirdSide)
        {
            double[] sides = new double[3];
            sides[0] = firstSide;
            sides[1] = secondSide;
            sides[2] = thirdSide;

            if (sides.Any((side) => side < 0.0))
                throw new ArgumentException("The side of the triangle cannot be less than zero");
            else if (Exists(sides))
                throw new ArgumentException("A triangle with such sides does not exist");

            Array.Sort(sides);

            return new Triangle(sides);
        }
    }
}