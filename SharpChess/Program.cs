using SharpChess.Utils;
using SharpChess.Entities.Match;
using SharpChess.Entities.Primitives.Enums;

Console.Write("Enter Player 1 name: ");
string player1Name = Console.ReadLine()!;

Console.Write("Enter Player 2 name: ");
string player2Name = Console.ReadLine()!;

Console.WriteLine();
Console.WriteLine("Available Colors:");
Helpers.DisplayAvailableColors();
Console.WriteLine();

Console.Write("Player 1, choose your color: ");
PieceColor player1Color = Enum.Parse<PieceColor>(Console.ReadLine()!);

Console.Write("Player 2, choose your color: ");
PieceColor player2Color = Enum.Parse<PieceColor>(Console.ReadLine()!);

if (player1Color == player2Color)
{
    throw new ApplicationException("Colors cannot be the same. Shutting down...");
}

Player player1 = new Player(player1Name, player1Color);
Player player2 = new Player(player2Name, player2Color);

ChessMatch newMatch = new ChessMatch(player1, player2);

Console.WriteLine("Match starting...");
Console.WriteLine();

newMatch.GameLoop();

Console.WriteLine("That's all! Thanks for playing SharpChess :D");


