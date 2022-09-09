namespace SharpChess.Exceptions;

public class PositionNullOrNotFound : ApplicationException
{
    public PositionNullOrNotFound(string message) : base(message) {}
}
