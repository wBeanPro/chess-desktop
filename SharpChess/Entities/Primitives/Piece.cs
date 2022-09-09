using SharpChess.Entities.Board;
using SharpChess.Entities.Primitives.Enums;

namespace SharpChess.Entities.Primitives;

public abstract class Piece
{
    public PieceColor Color { get; init; }
    public Position? Position { get; set; }
    public int Moves { get; set; } = 0;
    public ChessBoard Board { get; init; }

    public Piece(PieceColor color, Position initialPosition, ChessBoard board)
    {
        Color = color;
        Position = initialPosition;
        Board = board;
    }

    public abstract void Move();
}
