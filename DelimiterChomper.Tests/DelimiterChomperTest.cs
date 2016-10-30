using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelimiterChomper.Tests
{
    [TestFixture]
    public class DelimiterChomperTest
    {
        [Test]
        public void RemovesDelimitersFromLeftWithEmptyLine()
        {
            // Arrange
            string line = "";

            // Act
            string result = DelimiterChomper.CleanLineOfDelimiters(",", Direction.LEFT, 2, line);

            // Assert
            Assert.AreEqual("", result);
        }

        [Test]
        public void RemovesDelimitersFromRightWithEmptyLine()
        {
            // Arrange
            string line = "";

            // Act
            string result = DelimiterChomper.CleanLineOfDelimiters(",", Direction.RIGHT, 2, line);

            // Assert
            Assert.AreEqual("", result);
        }

        [Test]
        public void RemovesDelimitersFromLeftWithMoreThan2()
        {
            // Arrange
            string line = "1,2,3,4,5,6";

            // Act
            string result = DelimiterChomper.CleanLineOfDelimiters(",", Direction.LEFT, 2, line);

            // Assert
            Assert.AreEqual("1,2,3456", result);
        }

        [Test]
        public void RemovesDelimitersFromRightWithMoreThan2()
        {
            // Arrange
            string line = "1,2,3,4,5,6";

            // Act
            string result = DelimiterChomper.CleanLineOfDelimiters(",", Direction.RIGHT, 2, line);

            // Assert
            Assert.AreEqual("1234,5,6", result);
        }

        [Test]
        public void RemovesDelimitersFromLeftWithLessThan2()
        {
            // Arrange
            string line = "1,23456";

            // Act
            string result = DelimiterChomper.CleanLineOfDelimiters(",", Direction.LEFT, 2, line);

            // Assert
            Assert.AreEqual("1,23456", result);
        }

        [Test]
        public void RemovesDelimitersFromRightWithLessThan2()
        {
            // Arrange
            string line = "12345,6";

            // Act
            string result = DelimiterChomper.CleanLineOfDelimiters(",", Direction.RIGHT, 2, line);

            // Assert
            Assert.AreEqual("12345,6", result);
        }

        [Test]
        public void RemovesDelimitersFromLeftWithNoDelimiters()
        {
            // Arrange
            string line = "123456";

            // Act
            string result = DelimiterChomper.CleanLineOfDelimiters(",", Direction.LEFT, 2, line);

            // Assert
            Assert.AreEqual("123456", result);
        }

        [Test]
        public void RemovesDelimitersFromRightWithNoDelimiters()
        {
            // Arrange
            string line = "123456";

            // Act
            string result = DelimiterChomper.CleanLineOfDelimiters(",", Direction.RIGHT, 2, line);

            // Assert
            Assert.AreEqual("123456", result);
        }

        [Test]
        public void RemovesDelimitersFromLeftWithJustDelimiters()
        {
            // Arrange
            string line = ",,,,,,";

            // Act
            string result = DelimiterChomper.CleanLineOfDelimiters(",", Direction.LEFT, 2, line);

            // Assert
            Assert.AreEqual(",,", result);
        }

        [Test]
        public void RemovesDelimitersFromRightWithJustDelimiters()
        {
            // Arrange
            string line = ",,,,,,";

            // Act
            string result = DelimiterChomper.CleanLineOfDelimiters(",", Direction.RIGHT, 2, line);

            // Assert
            Assert.AreEqual(",,", result);
        }
    }
}
