namespace SharpChess.Exceptions;

public sealed class OutOfBoundsException : ApplicationException
{
    public OutOfBoundsException(string message) : base(message) {}
}
