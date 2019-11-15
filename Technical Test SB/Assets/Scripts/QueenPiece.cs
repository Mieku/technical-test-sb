using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QueenPiece : ChessPiece
{
    public override List<Vector2Int> DetermineAreaOfAttack()
    {
        List<Vector2Int> result = new List<Vector2Int>();

        // The longest diagonal distance within a grid is the shortest of its sizes (minus the cell containing the piece)
        int longestLengthPossible = Mathf.Min(BoardSize.x, BoardSize.y) - 1;

        for (int i = 1; i <= longestLengthPossible; i++)
        {
            result.Add(new Vector2Int(Location.x + i, Location.y + i)); // SE
            result.Add(new Vector2Int(Location.x - i, Location.y - i)); // NW
            result.Add(new Vector2Int(Location.x + i, Location.y - i)); // NE
            result.Add(new Vector2Int(Location.x - i, Location.y + i)); // SW
        }

        // Trimming here because the hor and vert checks wont go out of bounds, trimming with less values for efficiency!
        result = RemoveOutOfBoundsAttacks(result);

        // The Horizontal
        for (int x = 0; x < BoardSize.x; x++)
        {
            if (x != Location.x)
            {
                result.Add(new Vector2Int(x, Location.y));
            }
        }

        // The Vertical
        for (int y = 0; y < BoardSize.y; y++)
        {
            if (y != Location.y)
            {
                result.Add(new Vector2Int(Location.x, y));
            }
        }

        return result;
    }

    public override string GetPieceSymbol()
    {
        return "Q";
    }
}
