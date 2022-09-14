namespace Calculator.Exceptions;
internal class UnknownOperatorException : Exception
{
    public UnknownOperatorException()
        : base("Operator in unknown")
    {

    }
}
