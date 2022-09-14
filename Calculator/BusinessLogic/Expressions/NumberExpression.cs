namespace Calculator.BusinessLogic.Expressions;
internal class NumberExpression : ICalcExpression
{
    private readonly string _expression;

    public NumberExpression(string expression)
    {
        _expression = expression;
    }

    public double Calculate()
    {
        if (double.TryParse(_expression, out double result))
            return result;

        throw new ParsingException(_expression);
    }
}
