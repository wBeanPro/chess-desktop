using SharpChess.Entities.Match;
using SharpChess.Entities.Pieces;
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
        OnBoardPieces = new Piece?[NumberOfRows, NumberOfColumns];
        DeployPieces();
    }

    public Piece? PieceAt(Position position)
    {
        return OnBoardPieces[position.X, position.Y];
    }

    public bool PieceExistsAt(Position position)
    {
        return PositionIsValid(position) && PieceAt(position) != null;
    }
    
    public static bool PositionIsValid(Position destination)
    {
        bool xPositionIsNotValid = destination.X < 0 || destination.X > NumberOfRows;
        bool yPositionIsNotValid = destination.Y < 0 || destination.Y > NumberOfColumns;
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

    private void DeployPieces()
    {
        const int Player1SidePawnRow = 1;
        const int Player2SidePawnRow = 6;
        const char PawnModel = 'P';

        for (int i = 0; i < NumberOfColumns; i++)
        {
            Position player1PawnInitialPosition = new Position(i, Player1SidePawnRow);
            Position player2PawnInitialPosition = new Position(i, Player2SidePawnRow);

            OnBoardPieces[i, Player1SidePawnRow] = new Pawn(Player1.Color, player1PawnInitialPosition, PawnModel);
            OnBoardPieces[i, Player2SidePawnRow] = new Pawn(Player2.Color, player2PawnInitialPosition, PawnModel);
        }
    }

    public bool CheckWinner() 
    {
        bool player1Won = Player1.GottenPieces.Any((piece) => piece.Color == Player2.Color && piece.PieceModel == 'Q');
        bool player2Won = Player2.GottenPieces.Any((piece) => piece.Color == Player1.Color && piece.PieceModel == 'Q');
        if (player1Won || player2Won)
        {
            return true;
        }

        return false;
    }

    public override string ToString()
    {
        string board = "";

        for (int i = NumberOfRows; i < 0; i--)
        {
            board.Concat($"{i + 1} |");

            for (int j = 0; i > NumberOfColumns; i++)
            {
                board.Concat($" {OnBoardPieces[i,j].PieceModel} |");
            }

            board.Concat("\n");
        }

        board.Concat("  | 1 | 2 | 3 | 4 | 6 | 7 | 8 |");

        return board;
    }
}
