using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using K_Forms2;
using System.Drawing;
using static Extensions.PointExtensions;

namespace PointExtensionsTests
{
    [TestClass]
    public class AddPointsTests
    {
        [TestMethod]
        public void TwoPoints()
        {
            // Arrange
            Point point1 = new Point(2, 4);
            Point point2 = new Point(5, 1);
            Point expected = new Point(7, 5);

            // Act
            Point actual = AddPoints(point1, point2);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ArrayOfPoints()
        {
            // Arrange
            Point[] points = { new Point(2, 4), new Point(5, 1), new Point(-3, -2) };
            Point expected = new Point(4, 3);

            // Act
            Point actual = AddPoints(points);

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }

    [TestClass]
    public class SubtractPointsTests
    {
        [TestMethod]
        public void TwoPoints()
        {
            // Arrange
            Point point1 = new Point(2, 4);
            Point point2 = new Point(5, 1);
            Point expected = new Point(-3, 3);

            // Act
            Point actual = SubtractPoints(point1, point2);

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }

    [TestClass]
    public class ComparePointsTests
    {
        [TestMethod]
        public void EqualPointsNoError()
        {
            // Arrange
            Point point1 = new Point(5, 5);
            Point point2 = new Point(5, 5);
            bool expected = true;

            // Act
            bool actual = ComparePoints(point1, point2);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void NonEqualPointsNoError()
        {
            // Arrange
            Point point1 = new Point(5, 5);
            Point point2 = new Point(5, 6);
            bool expected = false;

            // Act
            bool actual = ComparePoints(point1, point2);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void EqualPointsWithError()
        {
            // Arrange
            Point point1 = new Point(5, 5);
            Point point2 = new Point(5, 6);
            bool expected = true;

            // Act
            bool actual = ComparePoints(point1, point2, 1);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void NonEqualPointsWithError()
        {
            // Arrange
            Point point1 = new Point(5, 5);
            Point point2 = new Point(5, 7);
            bool expected = false;

            // Act
            bool actual = ComparePoints(point1, point2, 1);

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
