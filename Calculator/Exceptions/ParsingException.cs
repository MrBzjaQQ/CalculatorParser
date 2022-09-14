namespace Calculator.Exceptions;
public class ParsingException : Exception
{
    public ParsingException(string expression) : base($"Incorrect expression: {expression}")
    {

    }
}
