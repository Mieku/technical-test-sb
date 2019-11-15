using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChessPieceCalculator : MonoBehaviour
{
    private int _horizontalCells, _verticalCells;
    private int _numKing, _numQueen, _numBishop, _numRook, _numKnight;
    private List<string> _results = new List<string>();

    public ChessPieceCalculator(int horCells, int vertCells, int numKing, int numQueen, int numBishop, int numRook, int numKnight)
    {
        _horizontalCells = horCells;
        _verticalCells = vertCells;
        _numKing = numKing;
        _numQueen = numQueen;
        _numBishop = numBishop;
        _numRook = numRook;
        _numKnight = numKnight;
    }

    public List<string> CalculateResults()
    {
        // TODO: Build the calculator

        return _results;
    }
}
