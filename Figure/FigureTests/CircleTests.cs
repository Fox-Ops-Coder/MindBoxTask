using Figure.Figures;
using System;
using Xunit;

namespace FigureTests
{
    public class CircleTests
    {
        private const double tolerance = 0.00000001;

        [Fact]
        public static void CreateCircle_WhenRadiusBiggerThanZero_NoExeption()
        {
            Circle.Build(1.0);
        }

        [Fact]
        public static void CreateCircle_WhenRadiusLesserThanZero_WithExeption()
        {
            Assert.Throws<ArgumentException>(() => Circle.Build(-1.0));
        }

        [Fact]
        public static void Area_WhenRadiusIs1_EqualsPi()
        {
            Assert.Equal(Math.PI, Circle.Build(1.0).Area(), tolerance);
        }

        [Fact]
        public static void Area_WhenRadiusIs2_NotEqualsPi()
        {
            Assert.NotEqual(Math.PI, Circle.Build(2.0).Area());
        }

        [Fact]
        public static void CirclesEqual_WhenBothRadiusIs1_True()
        {
            Assert.True(Circle.Build(1.0).Equal(Circle.Build(1.0)));
        }

        [Fact]
        public static void CirclesEqual_WhenRadiusIs1And2_False()
        {
            Assert.False(Circle.Build(1.0).Equal(Circle.Build(2.0)));
        }

        [Fact]
        public static void CirclesEqual_WhenArgumentIsTriangle_False()
        {
            Assert.False(Circle.Build(Math.PI).Equal(Triangle.Build(Math.Sqrt(193.0), 12, 7)));
        }
    }
}