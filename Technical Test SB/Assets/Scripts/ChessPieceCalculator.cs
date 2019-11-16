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

        DetermineResults(board, chessPieces);

        DisplayProcessingTime();
        return _results;
    }

    private void DetermineResults(string[,] possibleBoard, Stack<ChessPiece> remainingPieces)
    {
        /*
         * My Approach:
         * - Ensure their are pieces left to place, if not you have a correct output! Log it and leave!
         * - Else, Grab the next chess piece
         * - Determine all the locations it can safely be placed, keep track
         * - If there are no locations it can be placed, leave this iteration this specific board placement is impossible
         * - Else, for each of the possible locations recursively repeat this approach until all pieces are placed or they 
         *      discover no other pieces can safely be placed.
         */

        Stack<ChessPiece> curPieces = new Stack<ChessPiece>(remainingPieces);
        // Check if any pieces are left, if not store board
        if(curPieces.Count == 0)
        {
            _results.Add(possibleBoard);
            return;
        }
        // If there is a piece left, grab it
        ChessPiece piece = curPieces.Pop();
        // Try to place piece
        List<string[,]> allBoardsWherePlaced = GetAllBoardsWherePieceCanFit(possibleBoard, piece);
        // No luck, leave iteration
        if (allBoardsWherePlaced == null)
        {
            return;
        }
        
        // If places are found, recursively dig deeper into the possibilities
        foreach(var board in allBoardsWherePlaced)
        {
            DetermineResults(board, curPieces);
        }
    }

    private List<string[,]> GetAllBoardsWherePieceCanFit(string[,] board, ChessPiece piece)
    {
        List<string[,]> possibleBoards = new List<string[,]>();
        for(int x = 0; x < board.GetLength(0); x++)
        {
            for(int y = 0; y < board.GetLength(1); y++)
            {
                if(board[x,y] == null) // Empty spot
                {
                    // Checks its own telegraph of attack to ensure it doesnt hit others
                    if (!piece.CheckIfPieceDangersOthers(board, new Vector2Int(x,y))) 
                    {
                        // If all good, store this as a potential board to continue with
                        string[,] newBoard = piece.PlacePiece(board, new Vector2Int(x, y));
                        possibleBoards.Add(newBoard);
                    }
                }
            }
        }

        // If there are no possibilities, dump it!
        if (possibleBoards.Count == 0) return null;

        return possibleBoards;
    }

    private Stack<ChessPiece> GenerateChessPieces()
    {
        Stack<ChessPiece> result = new Stack<ChessPiece>();
        // King
        for(int i = 0; i < _numKing; i++)
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
        print("Processing time: " + processingTime.TotalMilliseconds + "ms");
    }
}
