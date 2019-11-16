using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QueenPiece : ChessPiece
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

        // Trimming here because the hor and vert checks wont go out of bounds, trimming with less values for efficiency!
        result = RemoveOutOfBoundsAttacks(result);

        // The Horizontal
        for (int x = 0; x < BoardSize.x; x++)
        {
            if (x != location.x)
            {
                result.Add(new Vector2Int(x, location.y));
            }
        }

        // The Vertical
        for (int y = 0; y < BoardSize.y; y++)
        {
            if (y != location.y)
            {
                result.Add(new Vector2Int(location.x, y));
            }
        }

        return result;
    }

    public override string GetPieceSymbol()
    {
        return "Q";
    }
}
