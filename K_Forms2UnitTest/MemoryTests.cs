using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using K_Forms2;

namespace MemoryTests
{
    [TestClass]
    public class ConstructorTests
    {
        [TestMethod]
        public void CorrectSize()
        {
            // Arrange
            uint size = 10;

            // Act
            var memory = new Memory(size);

            // Assert
            Assert.IsNotNull(memory);
            Assert.AreEqual((uint)memory.PageAgePairs.Count, size);
        }

        [TestMethod]
        public void IncorrectSize()
        {
            // Arrange
            uint size = 0;

            // Act
            void action() => new Memory(size);

            // Assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(action);
        }
    }

    [TestClass]
    public class RequestPageTests
    {
        [TestMethod]
        public void WithoutPageFault()
        {
            // Arrange
            var memory = new Memory(1);
            bool expected = false;

            // Act
            bool actual = memory.RequestPage(0, out _);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void WithPageFault()
        {
            // Arrange
            var memory = new Memory(1);
            bool expected = true;
            uint expectedPageNumber = 0;

            // Act
            bool actual = memory.RequestPage(10, out Page removedPage);

            // Assert
            Assert.AreEqual(expected, actual);
            Assert.AreEqual(expectedPageNumber, removedPage.Number);
        }
    }
}
