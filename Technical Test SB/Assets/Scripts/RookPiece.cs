using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RookPiece : ChessPiece
{
    public override List<Vector2Int> DetermineAreaOfAttack(Vector2Int location)
    {
        List<Vector2Int> result = new List<Vector2Int>();

        // The Horizontal
        for(int x = 0; x < BoardSize.x; x++)
        {
            if(x != location.x)
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
        return "R";
    }
}
