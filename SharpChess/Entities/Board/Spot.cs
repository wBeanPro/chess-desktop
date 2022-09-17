using SharpChess.Entities.Primitives;

namespace SharpChess.Entities.Board;

public sealed class Spot
{
    public int Y { get; private init; }
    public int X { get; private init; }
    public Piece? Piece { get; private set; }

    public Spot(int y, int x)
    {
        Y = y;
        X = x;
        Piece = null;
    }

    public Spot(int y, int x, Piece piece)
    {
        Y = y;
        X = x;
        Piece = piece;
    }

    public void RemoveOldPiece()
    {
        Piece = null;
    }

    public void RemoveOldAndSetNewPiece(Piece newPiece)
    {
        Piece = newPiece;
    }
}
