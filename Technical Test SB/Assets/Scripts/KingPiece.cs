﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KingPiece : ChessPiece
{
    public override List<Vector2Int> DetermineAreaOfAttack(Vector2Int location)
    {
        List<Vector2Int> result = new List<Vector2Int>();

        result.Add(new Vector2Int(location.x, location.y - 1)); // North
        result.Add(new Vector2Int(location.x, location.y + 1)); // South
        result.Add(new Vector2Int(location.x - 1, location.y)); // East
        result.Add(new Vector2Int(location.x + 1, location.y)); // West
        result.Add(new Vector2Int(location.x - 1, location.y - 1)); // NW
        result.Add(new Vector2Int(location.x + 1, location.y + 1)); // SW
        result.Add(new Vector2Int(location.x - 1, location.y + 1)); // NE
        result.Add(new Vector2Int(location.x + 1, location.y - 1)); // SE

        // Trims out the out of bounds values that exit the grid
        result = RemoveOutOfBoundsAttacks(result);

        return result;
    }

    public override string GetPieceSymbol()
    {
        return "K";
    }
}
