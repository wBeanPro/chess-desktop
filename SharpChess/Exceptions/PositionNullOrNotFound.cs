namespace SharpChess.Exceptions;

public sealed class PositionNullOrNotFound : ApplicationException
{
    public PositionNullOrNotFound(string message) : base(message) {}
}
