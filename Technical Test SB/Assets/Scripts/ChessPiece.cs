using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ChessPiece : MonoBehaviour
{
    public Vector2Int Location { get; set; }
    public Vector2Int BoardSize { get; set; }

    public abstract List<Vector2Int> DetermineAreaOfAttack();
    public abstract string GetPieceSymbol();

    // This trims out cells that are outside of the grid
    protected List<Vector2Int> RemoveOutOfBoundsAttacks(List<Vector2Int> untrimmedAttacks)
    {
        List<Vector2Int> trimmedAttacks = new List<Vector2Int>();
        foreach(Vector2Int cell in untrimmedAttacks)
        {
            // Horizontal Check
            if(cell.x < 0 || cell.x >= BoardSize.x) { continue; }

            // Vertical Check
            if(cell.y < 0 || cell.y >= BoardSize.y) { continue; }

            trimmedAttacks.Add(cell);
        }

        return trimmedAttacks;
    }
}
