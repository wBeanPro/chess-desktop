using SharpChess.Entities.Board;
using SharpChess.Entities.Primitives;
using SharpChess.Entities.Primitives.Enums;

namespace SharpChess.Entities.Pieces;

public sealed class Knight : Piece
{
    public Knight(PieceColor color, Position initialPosition, char pieceModel) : base(color, initialPosition, pieceModel) {}

    public override void DoEastMovement()
    {
        throw new NotImplementedException();
    }

    public override void DoNorthEastMovement()
    {
        throw new NotImplementedException();
    }

    public override void DoNorthMovement()
    {
        throw new NotImplementedException();
    }

    public override void DoNorthWestMovement()
    {
        throw new NotImplementedException();
    }

    public override void DoSouthEastMovement()
    {
        throw new NotImplementedException();
    }

    public override void DoSouthMovement()
    {
        throw new NotImplementedException();
    }

    public override void DoSouthWestMovement()
    {
        throw new NotImplementedException();
    }

    public override void DoWestMovement()
    {
        throw new NotImplementedException();
    }
}
