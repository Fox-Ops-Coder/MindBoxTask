using Figure.Figures;
using System;
using Xunit;

namespace FigureTests
{
    public class TriangleTests
    {
        private const double tolerance = 0.00000001;

        [Fact]
        public static void CreateTriangle_WhenSidesBiggerThanZeroAndCorrect_NoExeption()
        {
            Triangle.Build(1.0, 2.0, 3.0);
        }

        [Fact]
        public static void CreateTriangle_WhenOneSideLesserThanZero_WithExeption()
        {
            Assert.Throws<ArgumentException>(() => Triangle.Build(-1.0, 2.0, 3.0));
        }

        [Fact]
        public static void CreateTriangle_WhenSidesAreIncorrentLenght_WithExeption()
        {
            Assert.Throws<ArgumentException>(() => Triangle.Build(999.0, 1.0, 1.0));
        }

        [Fact]
        public static void IsRectangular_WhenRightTriangle_True()
        {
            Assert.True(Triangle.Build(Math.Sqrt(193.0), 12, 7).IsRectangular());
        }

        [Fact]
        public static void IsRectangular_WhenNotRightTriangle_True()
        {
            Assert.False(Triangle.Build(42, 37, 20).IsRectangular());
        }

        [Fact]
        public static void Area_WhenAreaIsEqual42_True()
        {
            Assert.Equal(42.0, Triangle.Build(Math.Sqrt(193.0), 12, 7).Area(), tolerance);
        }

        [Fact]
        public static void TrianglesEqual_WhenSidesAreEqual_True()
        {
            Assert.True(Triangle.Build(Math.Sqrt(193.0), 12, 7).Equal(Triangle.Build(Math.Sqrt(193.0), 12, 7)));
        }

        [Fact]
        public static void TrianglesEqual_WhenSidesAreNotEqual_True()
        {
            Assert.False(Triangle.Build(Math.Sqrt(193.0), 12, 7).Equal(Triangle.Build(42, 37, 20)));
        }

        [Fact]
        public static void TrianglesEqual_WhenSidesAreEqualButDifferntOrder_True()
        {
            Assert.True(Triangle.Build(Math.Sqrt(193.0), 12, 7).Equal(Triangle.Build(7, 12, Math.Sqrt(193.0))));
        }

        [Fact]
        public static void TrianglesEqual_WhenArgumentIsCircle_False()
        {
            Assert.False(Triangle.Build(Math.Sqrt(193.0), 12, 7).Equal(Circle.Build(Math.PI)));
        }
    }
}