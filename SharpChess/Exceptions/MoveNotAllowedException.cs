namespace SharpChess.Exceptions;

public sealed class MoveNotAllowedException : ApplicationException
{
    public MoveNotAllowedException(string message) : base(message) {}
}
