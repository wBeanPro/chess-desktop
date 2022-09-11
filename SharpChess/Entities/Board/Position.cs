namespace SharpChess.Entities.Board;

public sealed class Position
{
    public int Y { get; private set; }
    public int X { get; private set; }

    public Position(int y, int x)
    {
        Y = y;
        X = x;
    }

    public void SetAll(int y, int x)
    {
        Y = y;
        X = x;
    }

    public override string ToString()
    {
        return $"Coordinates: (Row {Y}, Column {X})";
    }
}
