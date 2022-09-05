namespace SharpChess.Exceptions;

public class OutOfBoundsException : ApplicationException
{
    public OutOfBoundsException(string message) : base(message) {}
}
