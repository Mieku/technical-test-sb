using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ChessPiece : MonoBehaviour
{
    public Vector2Int BoardSize { get; set; }

    public abstract List<Vector2Int> DetermineAreaOfAttack(Vector2Int location);
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

    public bool CheckIfPieceDangersOthers(string[,] board, Vector2Int location)
    {
        List<Vector2Int> areaOfAttack = DetermineAreaOfAttack(location);
        foreach(Vector2Int cellPos in areaOfAttack)
        {
            if(board[cellPos.x, cellPos.y] != null && !board[cellPos.x, cellPos.y].Equals("X"))
            {
                return true;
            }
        }

        return false;
    }

    // This places the piece on the board, and telegraphs the danger areas with an X
    public string[,] PlacePiece(string[,] curBoard, Vector2Int location)
    {
        string[,] result = (string[,])curBoard.Clone();
        
        // Placing Piece
        result[location.x, location.y] = GetPieceSymbol();

        // Telegraphing danger area
        List<Vector2Int> areaOfAttack = DetermineAreaOfAttack(location);
        foreach(Vector2Int dangerCell in areaOfAttack)
        {
            result[dangerCell.x, dangerCell.y] = "X";
        }

        return result;
    }
}
