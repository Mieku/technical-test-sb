using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BishopPiece : ChessPiece
{
    public override List<Vector2Int> DetermineAreaOfAttack(Vector2Int location)
    {
        List<Vector2Int> result = new List<Vector2Int>();

        // The longest diagonal distance within a grid is the shortest of its sizes (minus the cell containing the piece)
        int longestLengthPossible = Mathf.Min(BoardSize.x, BoardSize.y) - 1;

        for (int i = 1; i <= longestLengthPossible; i++)
        {
            result.Add(new Vector2Int(location.x + i, location.y + i)); // SE
            result.Add(new Vector2Int(location.x - i, location.y - i)); // NW
            result.Add(new Vector2Int(location.x + i, location.y - i)); // NE
            result.Add(new Vector2Int(location.x - i, location.y + i)); // SW
        }

        // Trims out the out of bounds values that exit the grid
        result = RemoveOutOfBoundsAttacks(result);

        return result;
    }

    public override string GetPieceSymbol()
    {
        return "B";
    }
}
