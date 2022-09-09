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

    public ChessMatch(Player player1, Player player2, ChessBoard board)
    {
        Player1 = player1;
        Player2 = player2;
        Board = board;
        CurrentGameState = GameState.NotStarted;
    }

    public void GameLoop()
    {


        CurrentGameState = GameState.Running;

        do
        {
            bool hasWinner = Board.CheckWinner();

            if (hasWinner)
            {
                MatchWinner = Board.Winner;
                CurrentGameState = GameState.Ended;
            }

            continue;
        } while (CurrentGameState == GameState.Running);

        DisplayWinnerMessage(MatchWinner);
    }

    public void DisplayWinnerMessage(Player winner)
    {
        Console.WriteLine($"Congratulations {winner.Name}! You have won the SharpChess match!");
    }

    public void SetNewGameState(GameState newState)
    {
        CurrentGameState = newState;
    }
}
