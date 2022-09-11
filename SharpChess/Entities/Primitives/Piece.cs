using SharpChess.Entities.Board;
using SharpChess.Entities.Primitives.Enums;
using SharpChess.Exceptions;

namespace SharpChess.Entities.Primitives;

public abstract class Piece
{
    public PieceColor Color { get; init; }
    public Position? Position { get; set; }
    public int Moves { get; set; } = 0;
    public char PieceModel { get; init; }

    public Piece(PieceColor color, Position initialPosition, char pieceModel)
    {
        Color = color;
        Position = initialPosition;
        PieceModel = pieceModel;
    }

    public void Move(Direction direction) 
    {
        switch (direction)
        {
            case Direction.North:
                DoNorthMovement();
                break;
            case Direction.South:
                DoSouthMovement();
                break;
            case Direction.West:
                DoWestMovement();
                break;
            case Direction.East:
                DoEastMovement();
                break;
            case Direction.SouthEast:
                DoSouthEastMovement();
                break;
            case Direction.SouthWest:
                DoSouthWestMovement();
                break;
            case Direction.NorthWest:
                DoNorthWestMovement();
                break;
            case Direction.NorthEast:
                DoNorthEastMovement();
                break;
            default:
                throw new MoveNotAllowedException("Movement Direction does not exists!");
        }
    }

    public abstract void DoNorthMovement();
    public abstract void DoSouthMovement();
    public abstract void DoEastMovement();
    public abstract void DoWestMovement();
    public abstract void DoSouthEastMovement();
    public abstract void DoSouthWestMovement();
    public abstract void DoNorthWestMovement();
    public abstract void DoNorthEastMovement();
}
