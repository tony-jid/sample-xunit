using System;
using Xunit;
using app_lib;

namespace app_test
{
    public class CalculatorTest
    {
        public Calculator Calculator { get; set; }

        public CalculatorTest()
        {
            Calculator = new Calculator();
        }

        [Fact]
        public void Plus_ShouldReturnCorrectResult()
        {
            // Arrange
            int num1 = 5;
            int num2 = 3;

            // Act
            int result = Calculator.Plus(num1, num2);

            // Assert
            Assert.Equal(8, result);
        }

        [Theory]
        [InlineData(5, 3, 8)]
        [InlineData(1, 3, 4)]
        [InlineData(10, 5, 15)]
        public void Plus_ShouldReturnCorrectResults(int num1, int num2, int exptectedResult)
        {
            // Arrange

            // Act
            int actualResult = Calculator.Plus(num1, num2);

            // Assert
            Assert.Equal(exptectedResult, actualResult);
        }
    }
}
