using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChessPieceCalculator : MonoBehaviour
{
    private Vector2Int _boardSize;
    private int _numKing, _numQueen, _numBishop, _numRook, _numKnight;
    private List<string[][]> _results = new List<string[][]>();

    private DateTime _startTime;

    public ChessPieceCalculator(Vector2Int boardSize, int numKing, int numQueen, int numBishop, int numRook, int numKnight)
    {
        _boardSize = boardSize;
        _numKing = numKing;
        _numQueen = numQueen;
        _numBishop = numBishop;
        _numRook = numRook;
        _numKnight = numKnight;
    }

    /*
     * My Approach:
     * - Foreach of the cells in the grid
     *      * Create a new grid with that piece placed
     *      * Have that piece indicate its dangerzones
     *      - Foreach of the non-danger and not taken cells
     *          * Check if the current piece's dangerzone overlaps a piece, if so abort.
     *          * Create a grid with the piece placed
     *      [Repeat until all pieces are placed, then store the board]
     */
    public List<string[][]> CalculateResults()
    {
        _startTime = DateTime.Now;

        // TODO: Build the calculator
        List<ChessPiece> chessPieces = GenerateChessPieces();




        DisplayProcessingTime();
        return _results;
    }

    private List<ChessPiece> GenerateChessPieces()
    {
        List<ChessPiece> result = new List<ChessPiece>();
        // King
        for(int i = 0; i < _numKing; i++)
        {
            KingPiece newPiece = new KingPiece();
            newPiece.BoardSize = _boardSize;
            result.Add(newPiece);
        }
        // Queen
        for (int i = 0; i < _numKing; i++)
        {
            QueenPiece newPiece = new QueenPiece();
            newPiece.BoardSize = _boardSize;
            result.Add(newPiece);
        }
        // Bishop
        for (int i = 0; i < _numKing; i++)
        {
            BishopPiece newPiece = new BishopPiece();
            newPiece.BoardSize = _boardSize;
            result.Add(newPiece);
        }
        // Rook
        for (int i = 0; i < _numKing; i++)
        {
            RookPiece newPiece = new RookPiece();
            newPiece.BoardSize = _boardSize;
            result.Add(newPiece);
        }
        // Knight
        for (int i = 0; i < _numKing; i++)
        {
            KnightPiece newPiece = new KnightPiece();
            newPiece.BoardSize = _boardSize;
            result.Add(newPiece);
        }

        return result;
    }

    private void DisplayProcessingTime()
    {
        TimeSpan processingTime = DateTime.Now - _startTime;
        print("Processing time: " + processingTime.TotalMilliseconds + "ms");
    }
}
