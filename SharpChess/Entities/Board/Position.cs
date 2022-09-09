namespace SharpChess.Entities.Board;

public sealed class Position
{
    public int X { get; private set; }
    public int Y { get; private set; }

    public Position(int x, int y)
    {
        X = x;
        Y = y;
    }

    public void SetAll(int x, int y)
    {
        X = x;
        Y = y;
    }

    public override string ToString()
    {
        return $"Coordinates: ({X}, {Y})";
    }
}
