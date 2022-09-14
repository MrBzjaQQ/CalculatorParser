namespace Calculator.BusinessLogic.Expressions;
public class CalcExpression : ICalcExpression
{
    private readonly ICalcOperand _first;

    private readonly ICalcOperand _second;

    private readonly OperatorSign _sign;

    public CalcExpression(ICalcOperand first, ICalcOperand second, OperatorSign sign)
    {
        _first = first;
        _second = second;
        _sign = sign;
    }

    public double Calculate()
    {
        return CalculateInternal(_first.GetValue(), _second.GetValue(), _sign);
    }

    private double CalculateInternal(double first, double second, OperatorSign sign)
    {
        switch (sign)
        {
            case OperatorSign.Plus:
                return first + second;
            case OperatorSign.Minus:
                return first - second;
            case OperatorSign.Multiply:
                return first * second;
            case OperatorSign.Divide:
                return first / second;
            case OperatorSign.Pow:
                return Math.Pow(first, second);
            default:
                throw new UnknownOperatorException();
        }
    }
}
