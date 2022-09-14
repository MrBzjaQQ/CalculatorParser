namespace Calculator.BusinessLogic;
public static class CalcExpressionParser
{
    private static string _plusSign = "+";
    private static string _minusSign = "-";
    private static string _multiplySign = "*";
    private static string _divideSign = "/";
    private static string _powSign = "^";
    public static ICalcExpression Parse(string stringExpression)
    {
        var plusIndex = stringExpression.IndexOf(_plusSign);
        var minusIndex = stringExpression.IndexOf(_minusSign);
        if (plusIndex != -1 || minusIndex != -1)
        {
            if (minusIndex == -1)
                return GetExpression(stringExpression, plusIndex, OperatorSign.Plus);

            if (plusIndex == -1)
                return GetExpression(stringExpression, minusIndex, OperatorSign.Minus);

            if (plusIndex > minusIndex)
                return GetExpression(stringExpression, plusIndex, OperatorSign.Plus);
            else
                return GetExpression(stringExpression, minusIndex, OperatorSign.Minus);
        }

        var multiplyIndex = stringExpression.IndexOf(_multiplySign);
        var divideIndex = stringExpression.IndexOf(_divideSign);

        if (multiplyIndex != -1 || divideIndex != -1)
        {
            if (divideIndex == -1)
                return GetExpression(stringExpression, multiplyIndex, OperatorSign.Multiply);

            if (multiplyIndex == -1)
                return GetExpression(stringExpression, divideIndex, OperatorSign.Divide);

            if (multiplyIndex > divideIndex)
                return GetExpression(stringExpression, multiplyIndex, OperatorSign.Multiply);
            else
                return GetExpression(stringExpression, divideIndex, OperatorSign.Divide);
        }

        var powIndex = stringExpression.IndexOf(_powSign);
        if (powIndex != -1)
            return GetExpression(stringExpression, powIndex, OperatorSign.Pow);

        return new NumberExpression(stringExpression);
    }

    private static ICalcExpression GetExpression(string stringExpression, int signIndex, OperatorSign sign)
    {
        string firstExpression = stringExpression.Substring(0, signIndex).Trim();
        string secondExpression = stringExpression.Substring(signIndex + 1).Trim();

        ICalcOperand first;
        ICalcOperand second;

        if (double.TryParse(firstExpression, out double firstResult))
            first = new NumberOperand(firstResult);
        else
            first = new ComplexOperand(firstExpression);

        if (double.TryParse(secondExpression, out double secondResult))
            second = new NumberOperand(secondResult);
        else
            second = new ComplexOperand(secondExpression);

        return new CalcExpression(first, second, sign);
    }
}
