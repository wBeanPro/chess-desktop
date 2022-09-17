﻿using SharpChess.Entities.Primitives;
using SharpChess.Entities.Primitives.Enums;

namespace SharpChess.Entities.Match;

public sealed class Player
{
    public PieceColor Color { get; private init; }
    public string Name { get; private init; } = string.Empty;
    public List<Piece> GottenPieces { get; private init; } = new List<Piece>();

    public Player(string name, PieceColor color)
    {
        Color = color;
        Name = name;
    }
}
