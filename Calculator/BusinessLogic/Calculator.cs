namespace Calculator.BusinessLogic;

public class Calculator : ICalculator
{
    public double Calculate(string expression)
    {
        return CalcExpressionParser.Parse(expression).Calculate();
    }
}

