namespace Calculator.BusinessLogic.Operands;
public class NumberOperand : ICalcOperand
{
    private readonly double _number;

    public NumberOperand(double number)
    {
        _number = number;
    }

    public double GetValue()
    {
        return _number;
    }
}
