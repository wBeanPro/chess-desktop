using SharpChess.Exceptions;
using SharpChess.Entities.Match;
using SharpChess.Entities.Pieces;
using SharpChess.Entities.Primitives;
using SharpChess.Entities.Primitives.Constants;

namespace SharpChess.Entities.Board;

public sealed class ChessBoard
{
    private const int NumberOfRows = 8;
    private const int NumberOfColumns = 8;

    private const int Player1SideOtherUnitsRow = 0;
    private const int Player1SidePawnRow = 1;
    private const int Player2SidePawnRow = 6;
    private const int Player2SideOtherUnitsRow = 7;

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
        return OnBoardPieces[position.Y, position.X];
    }

    public bool PieceExistsAt(Position position)
    {
        return PositionIsValid(position) && PieceAt(position) != null;
    }
    
    public static bool PositionIsValid(Position destination)
    {
        bool xPositionIsOutOfBounds = destination.X < 0 || destination.X > NumberOfRows;
        bool yPositionIsOutOfBounds = destination.Y < 0 || destination.Y > NumberOfColumns;
        if (xPositionIsOutOfBounds || yPositionIsOutOfBounds)
        {
            return false;
        }

        return true;
    }

    public void PutPieceAt(Piece piece, Position destination)
    {
        // Check if there is an enemy piece at destination
        if (PieceExistsAt(destination))
        {
            
        }

        RemovePieceFrom(piece.Position);

        piece.Position = destination;
        OnBoardPieces[destination.Y, destination.X] = piece;
    }

    public Piece? RemovePieceFrom(Position position)
    {
        Piece? piece = PieceAt(position);

        if (piece == null)
        {
            return null;
        }

        piece.Position = null;

        OnBoardPieces[position.Y, position.X] = null;

        return piece;
    }

    private void DeployPieces()
    {
        // Deploying Pawns
        for (int i = 0; i < NumberOfColumns; i++)
        {
            Position player1PawnInitialPosition = new Position(Player1SidePawnRow, i);
            Position player2PawnInitialPosition = new Position(Player2SidePawnRow, i);

            OnBoardPieces[Player1SidePawnRow, i] = new Pawn(Player1.Color, player1PawnInitialPosition, PieceModels.PawnModel);
            OnBoardPieces[Player2SidePawnRow, i] = new Pawn(Player2.Color, player2PawnInitialPosition, PieceModels.PawnModel);
        }

        // Deploying Rooks (Towers)
        OnBoardPieces[Player1SideOtherUnitsRow, 0] = new Rook(Player1.Color, new Position(0, Player1SideOtherUnitsRow), PieceModels.RookModel);
        OnBoardPieces[Player1SideOtherUnitsRow, NumberOfColumns - 1] = new Rook(Player1.Color, new Position(0, Player1SideOtherUnitsRow), PieceModels.RookModel);

        OnBoardPieces[Player2SideOtherUnitsRow, 0] = new Rook(Player2.Color, new Position(0, Player2SideOtherUnitsRow), PieceModels.RookModel);
        OnBoardPieces[Player2SideOtherUnitsRow, NumberOfColumns - 1] = new Rook(Player2.Color, new Position(0, Player2SideOtherUnitsRow), PieceModels.RookModel);

        // Deploying Knights (Horses)
        OnBoardPieces[Player1SideOtherUnitsRow, 1] = new Knight(Player1.Color, new Position(1, Player1SideOtherUnitsRow), PieceModels.KnightModel);
        OnBoardPieces[Player1SideOtherUnitsRow, NumberOfColumns - 2] = new Knight(Player1.Color, new Position(OnBoardPieces.Length - 2, Player1SideOtherUnitsRow), PieceModels.KnightModel);

        OnBoardPieces[Player2SideOtherUnitsRow, 1] = new Knight(Player2.Color, new Position(1, Player2SideOtherUnitsRow), PieceModels.KnightModel);
        OnBoardPieces[Player2SideOtherUnitsRow, NumberOfColumns - 2] = new Knight(Player2.Color, new Position(Player2SideOtherUnitsRow, NumberOfColumns - 2), PieceModels.KnightModel);

        // Deploying Bishops
        OnBoardPieces[Player1SideOtherUnitsRow, 2] = new Bishop(Player1.Color, new Position(Player1SideOtherUnitsRow, 2), PieceModels.BishopModel);
        OnBoardPieces[Player1SideOtherUnitsRow, NumberOfColumns - 3] = new Bishop(Player1.Color, new Position(Player1SideOtherUnitsRow, NumberOfColumns - 3), PieceModels.BishopModel);

        OnBoardPieces[Player2SideOtherUnitsRow, 2] = new Bishop(Player2.Color, new Position(Player2SideOtherUnitsRow, 2), PieceModels.BishopModel);
        OnBoardPieces[Player2SideOtherUnitsRow, NumberOfColumns - 3] = new Bishop(Player2.Color, new Position(Player2SideOtherUnitsRow, NumberOfColumns - 3), PieceModels.BishopModel);

        // Deploying Kings
        OnBoardPieces[Player1SideOtherUnitsRow, 3] = new King(Player1.Color, new Position(Player1SideOtherUnitsRow, 3), PieceModels.KingModel);
        OnBoardPieces[Player2SideOtherUnitsRow, 3] = new King(Player2.Color, new Position(Player2SideOtherUnitsRow, 3), PieceModels.KingModel);

        // Deploying Queens
        OnBoardPieces[Player1SideOtherUnitsRow, 4] = new Queen(Player1.Color, new Position(Player1SideOtherUnitsRow, 4), PieceModels.QueenModel);
        OnBoardPieces[Player2SideOtherUnitsRow, 4] = new Queen(Player2.Color, new Position(Player2SideOtherUnitsRow, 4), PieceModels.QueenModel);
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
        string chessBoard = "";

        for (int i = NumberOfRows - 1; i >= 0; i--)
        {
            chessBoard += $"{i + 1} |";

            for (int j = 0; j < NumberOfColumns; j++)
            {
                if (OnBoardPieces[i, j] == null)
                {
                    chessBoard += " - |";
                    continue;
                }

                chessBoard += $" {OnBoardPieces[i, j].PieceModel} |";
            }

            chessBoard += "\n";
        }

        chessBoard += "  | 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 |";

        return chessBoard;
    }
}
