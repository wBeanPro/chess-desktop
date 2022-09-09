using SharpChess.Entities.Match;
using SharpChess.Entities.Primitives;
using SharpChess.Exceptions;

namespace SharpChess.Entities.Board;

public class ChessBoard
{
    private const int NumberOfRows = 8;
    private const int NumberOfColumns = 8;

    private readonly Piece?[,] OnBoardPieces;
    
    private Player Player1 { get; init; }
    private Player Player2 { get; init; }
    public Player? Winner { get; private set; } = null;

    public ChessBoard(Player player1, Player player2)
    {
        Player1 = player1;
        Player2 = player2;
        OnBoardPieces = new Piece[NumberOfRows, NumberOfColumns];
    }

    public Piece? PieceAt(Position position)
    {
        return OnBoardPieces[position.X, position.Y];
    }

    public bool PieceExistsAt(Position position)
    {
        return PositionIsValid(position) && PieceAt(position) != null;
    }
    
    public static bool PositionIsValid(Position position)
    {
        if (position is null)
        {
            return false;
        }

        bool xPositionIsNotValid = position.X < 0 || position.X > NumberOfRows;
        bool yPositionIsNotValid = position.Y < 0 || position.Y > NumberOfColumns;
        if (xPositionIsNotValid || yPositionIsNotValid)
        {
            return false;
        }

        return true;
    }

    public void PutPieceAt(Piece piece, Position position)
    {
        if (PieceExistsAt(position))
        {
            throw new MoveNotAllowedException($"There already is a piece at position ({position.X}, {position.Y})!");
        }

        OnBoardPieces[position.X, position.Y] = piece;
        piece.Position = position;
    }

    public Piece? RemovePieceFrom(Position position)
    {
        Piece? piece = PieceAt(position);

        if (piece == null)
        {
            return null;
        }

        piece.Position = null;

        OnBoardPieces[position.X, position.Y] = null;

        return piece;
    }

    public bool CheckWinner() 
    {
        return true;
    }
}
