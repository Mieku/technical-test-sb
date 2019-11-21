using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChessPieceCalculator : MonoBehaviour
{
    private Vector2Int _boardSize;
    private int _numKing, _numQueen, _numBishop, _numRook, _numKnight;
    private List<string[,]> _results = new List<string[,]>();

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

    public List<string[,]> CalculateResults()
    {
        _startTime = DateTime.Now;

        Stack<ChessPiece> chessPieces = GenerateChessPieces();
        string[,] board = new string[_boardSize.x, _boardSize.y];

        DetermineResults(board, chessPieces, new Vector2Int(0, 0));

        DisplayProcessingTime();
        return _results;
    }

    private void DetermineResults(string[,] board, Stack<ChessPiece> remainingPieces, Vector2Int location)
    {
        Stack<ChessPiece> curPieces = new Stack<ChessPiece>(remainingPieces);

        // Check if any pieces are left, if not store board
        if (remainingPieces.Count == 0)
        {
            _results.Add(board);

            return;
        }

        // Grab next piece
        ChessPiece piece = curPieces.Pop();

        // Run this until you hit the end of the board
        while (location.x != -1 || location.y != -1) // End Indicator
        {
            // If a piece can be placed here
            if (board[location.x, location.y] == null && !piece.CheckIfPieceDangersOthers(board, location))
            {
                // Place the piece on the board
                string[,] newBoard = piece.PlacePiece(board, location);

                // Continue on recursively
                DetermineResults(newBoard, curPieces, Vector2Int.zero);
            }

            // Carry on to the next location
            location = IncrementLocation(location);
        }

        return;
    }

    // This just allows for an easy way to increment to the next cell of the grid
    private Vector2Int IncrementLocation(Vector2Int location)
    {
        Vector2Int result;
        if (location.x + 1 < _boardSize.x)
        {
            result = new Vector2Int(location.x + 1, location.y);
        }
        else if (location.y + 1 < _boardSize.y)
        {
            result = new Vector2Int(0, location.y + 1);
        }
        else
        {
            result = new Vector2Int(-1, -1); // End Indicator
        }
        return result;
    }

    private Stack<ChessPiece> GenerateChessPieces()
    {
        Stack<ChessPiece> result = new Stack<ChessPiece>();
        // King
        for (int i = 0; i < _numKing; i++)
        {
            KingPiece newPiece = new KingPiece();
            newPiece.BoardSize = _boardSize;
            result.Push(newPiece);
        }
        // Queen
        for (int i = 0; i < _numQueen; i++)
        {
            QueenPiece newPiece = new QueenPiece();
            newPiece.BoardSize = _boardSize;
            result.Push(newPiece);
        }
        // Bishop
        for (int i = 0; i < _numBishop; i++)
        {
            BishopPiece newPiece = new BishopPiece();
            newPiece.BoardSize = _boardSize;
            result.Push(newPiece);
        }
        // Rook
        for (int i = 0; i < _numRook; i++)
        {
            RookPiece newPiece = new RookPiece();
            newPiece.BoardSize = _boardSize;
            result.Push(newPiece);
        }
        // Knight
        for (int i = 0; i < _numKnight; i++)
        {
            KnightPiece newPiece = new KnightPiece();
            newPiece.BoardSize = _boardSize;
            result.Push(newPiece);
        }

        return result;
    }

    private void DisplayProcessingTime()
    {
        TimeSpan processingTime = DateTime.Now - _startTime;
        print("Processing time: " + processingTime.TotalSeconds + "s");
    }
}
