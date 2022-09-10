using SharpChess.Entities.Board;
using SharpChess.Entities.Match.Enums;

namespace SharpChess.Entities.Match;

public sealed class ChessMatch
{
    public ChessBoard Board { get; private init; }
    public GameState CurrentGameState { get; private set; }
    public Player Player1 { get; private init; }
    public Player Player2 { get; private init; }
    public Player? MatchWinner { get; private set; } = null;

    public ChessMatch(Player player1, Player player2)
    {
        Player1 = player1;
        Player2 = player2;
        Board = new ChessBoard(Player1, Player2);
        CurrentGameState = GameState.NotStarted;
    }

    public void GameLoop()
    {
        SetNewGameState(GameState.Running);

        int currentPlayer = 1;

        do
        {
            Console.WriteLine("Board:");
            Console.WriteLine(Board.ToString());

            Console.WriteLine($"Player {currentPlayer}, choose the piece location to move:");
            Console.Write("X: ");
            int xValue = int.Parse(Console.ReadLine());
            Console.Write("Y: ");
            int yValue = int.Parse(Console.ReadLine());

            Console.WriteLine($"Player {currentPlayer}, choose the destination:");
            Console.Write("X: ");
            int xDestination = int.Parse(Console.ReadLine());
            Console.Write("Y: ");
            int yDestinatioon = int.Parse(Console.ReadLine());

            Position piecePosition = new Position(xValue, yValue);
            Position destination = new Position(xDestination, yDestinatioon);

            try
            {
                Board.PutPieceAt(Board.PieceAt(piecePosition), destination);
            } 
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                continue;
            }

            Console.WriteLine("Board:");
            Console.WriteLine(Board.ToString());


            bool hasWinner = Board.CheckWinner();

            if (hasWinner)
            {
                MatchWinner = Board.Winner;
                DisplayWinnerMessage(MatchWinner);
                SetNewGameState(GameState.Ended);
            }

            currentPlayer = currentPlayer == 1 ? 2 : 1;

            continue;
        } while (CurrentGameState == GameState.Running);

        return;
    }

    private static void DisplayWinnerMessage(Player winner)
    {
        Console.WriteLine($"Congratulations {winner.Name}! You have won the SharpChess match!");
    }

    private void SetNewGameState(GameState newState)
    {
        CurrentGameState = newState;
    }
}
