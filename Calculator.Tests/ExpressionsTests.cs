namespace Calculator.Tests
{
    public class ExpressionsTests
    {
        [Test]
        [TestCaseSource(nameof(CalculateTestCases))]
        public void Calculate_OperandsAndSignProvided_ReturnsValue(double firstValue, double secondValue, OperatorSign sign, double expectedResult)
        {
            // Arrange
            Mock<ICalcOperand> firstOperand = new Mock<ICalcOperand>();
            Mock<ICalcOperand> secondOperand = new Mock<ICalcOperand>();
            firstOperand.Setup(x => x.GetValue()).Returns(firstValue);
            secondOperand.Setup(x => x.GetValue()).Returns(secondValue);
            CalcExpression expression = new CalcExpression(firstOperand.Object, secondOperand.Object, sign);

            // Act
            var resultValue = expression.Calculate();

            // Assert
            Assert.That(resultValue, Is.EqualTo(expectedResult));
            firstOperand.Verify(x => x.GetValue(), Times.Once);
            secondOperand.Verify(x => x.GetValue(), Times.Once);
        }

        public static List<TestCaseData> CalculateTestCases => new()
        {
            new(3.5, 2.5, OperatorSign.Plus, 6),
            new(3.5, 2.5, OperatorSign.Minus, 1),
            new(3.5, 2, OperatorSign.Multiply, 7),
            new(5, 2, OperatorSign.Divide, 2.5),
            new(2, 2, OperatorSign.Pow, 4)
        };
    }
}
