namespace Calculator.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void NumberOperand_GetValue_ReturnsValue()
        {
            // Arrange
            const double number = 11.12;
            NumberOperand operand = new(number);

            // Act
            double resultValue = operand.GetValue();

            // Assert
            Assert.That(resultValue, Is.EqualTo(number));
        }

        [Test]
        [TestCaseSource(nameof(ComplexOperandSimpleCases))]
        [TestCaseSource(nameof(ComplexOperandComplexCases))]
        public void ComplexOperand_GetsExpression_ReturnsValue(string operandStr, double expectedResult)
        {
            // Arrange
            ComplexOperand operand = new(operandStr);

            // Act
            double resultValue = operand.GetValue();

            // Assert
            Assert.IsTrue(Math.Abs(expectedResult - resultValue) < 0.001);
        }

        public static List<TestCaseData> ComplexOperandSimpleCases = new()
        {
            new TestCaseData("11 + 0,12", 11.12),
            new TestCaseData("11,24 - 0,12", 11.12),
            new TestCaseData("5,56 * 2", 11.12),
            new TestCaseData("22,24 / 2", 11.12),
            new TestCaseData("4 ^ 2", 16)
        };

        public static List<TestCaseData> ComplexOperandComplexCases = new()
        {
            new TestCaseData("11 + 0,12 * 2 + 2^5", 43.24),
            new TestCaseData("28 - 2^6", -36),
            new TestCaseData("25 - 5^2 + 12,55", 12.55),
            new TestCaseData("22,24 / 2^2", 5.56),
            new TestCaseData("4 ^ 2 + 2,5", 18.5),
            new TestCaseData("5 / 0,5^2", 20),
            new TestCaseData("18,5 + 5*5^0", 23.5),
            new TestCaseData("1^2 + 2 - 3 * 4 / 5", 0.6),
        };
    }
}