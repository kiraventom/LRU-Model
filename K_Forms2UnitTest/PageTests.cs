using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using K_Forms2;

namespace PageTests
{
    [TestClass]
    public class ConstructorTests
    {
        [TestMethod]
        public void CorrectNumber()
        {
            // Arrange
            uint number = 0;

            // Act
            var page = new Page(number);

            // Assert
            Assert.IsNotNull(page);
            Assert.AreEqual(page.Number, number);
        }
    }
}
