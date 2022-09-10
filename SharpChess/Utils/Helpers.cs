using SharpChess.Entities.Primitives.Enums;

namespace SharpChess.Utils;

public static class Helpers
{
    public static void DisplayAvailableColors()
    {
        string[] colors = Enum.GetNames<PieceColor>();

        foreach(var color in colors)
        {
            Console.WriteLine(color);
        }
    }
}
