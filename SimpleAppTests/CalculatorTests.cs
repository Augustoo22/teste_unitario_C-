using NUnit.Framework;
using SimpleApp;

namespace SimpleAppTests
{
    [TestFixture]
    public class CalculatorTests
    {
        [Test]
        public void Add_ShouldReturnSumOfTwoNumbers()
        {
            // Arrange
            var calculator = new Calculator();
            int a = 5;
            int b = 3;

            // Act
            var result = calculator.Somar(a, b);

            // Assert
            Assert.That(result, Is.EqualTo(8), "The Add method should return the sum of two numbers.");
            TestContext.WriteLine($"Add Test Passed: {a} + {b} = {result}");
        }

        [Test]
        public void Subtract_ShouldReturnDifferenceOfTwoNumbers()
        {
            var calculator = new Calculator();
            int a = 10, b = 4;

            var result = calculator.Subtract(a, b);

            Assert.That(result, Is.EqualTo(6));
            TestContext.WriteLine($"Subtract Test Passed: {a} - {b} = {result}");
        }

        [Test]
        public void Multiply_ShouldReturnProductOfTwoNumbers()
        {
            var calculator = new Calculator();
            int a = 6, b = 7;

            var result = calculator.Multiply(a, b);

            Assert.That(result, Is.EqualTo(42));
            TestContext.WriteLine($"Multiply Test Passed: {a} * {b} = {result}");
        }

        [Test]
        public void Divide_ShouldReturnQuotientOfTwoNumbers()
        {
            var calculator = new Calculator();
            int a = 20, b = 4;

            var result = calculator.Divide(a, b);

            Assert.That(result, Is.EqualTo(5.0));
            TestContext.WriteLine($"Divide Test Passed: {a} / {b} = {result}");
        }

        [Test]
        public void Divide_ByZero_ShouldThrowDivideByZeroException()
        {
            var calculator = new Calculator();
            int a = 10, b = 0;

            Assert.Throws<DivideByZeroException>(() => calculator.Divide(a, b));
            TestContext.WriteLine($"Divide By Zero Test Passed: {a} / {b} throws exception.");
        }
    }
}
