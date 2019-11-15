﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightPiece : ChessPiece
{
    public override List<Vector2Int> DetermineAreaOfAttack()
    {
        List<Vector2Int> result = new List<Vector2Int>();

        result.Add(new Vector2Int(Location.x + 1, Location.y + 2)); // NNE
        result.Add(new Vector2Int(Location.x + 2, Location.y + 1)); // NEE
        result.Add(new Vector2Int(Location.x - 1, Location.y + 2)); // NNW
        result.Add(new Vector2Int(Location.x - 2, Location.y + 1)); // NWW
        result.Add(new Vector2Int(Location.x + 1, Location.y - 2)); // SSE
        result.Add(new Vector2Int(Location.x + 2, Location.y - 1)); // SEE
        result.Add(new Vector2Int(Location.x - 1, Location.y - 2)); // SSW
        result.Add(new Vector2Int(Location.x - 2, Location.y - 1)); // SWW

        // Trims out the out of bounds values that exit the grid
        result = RemoveOutOfBoundsAttacks(result);

        return result;
    }

    public override string GetPieceSymbol()
    {
        return "Kn";
    }
}
