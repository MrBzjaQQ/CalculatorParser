namespace Calculator.BusinessLogic.Operands;
public class ComplexOperand : ICalcOperand
{
    private readonly string _expression;

    public ComplexOperand(string stringExpression)
    {
        _expression = stringExpression;
    }

    public double GetValue()
    {
        return CalcExpressionParser.Parse(_expression).Calculate();
    }
}
