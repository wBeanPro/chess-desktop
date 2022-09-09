namespace SharpChess.Exceptions;

public class MoveNotAllowedException : ApplicationException
{
    public MoveNotAllowedException(string message) : base(message) {}
}
