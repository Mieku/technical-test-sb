using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using System.Linq;
using UnityEngine.UI;

public class OutputDisplay : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _positionRenderer;
    [SerializeField] GridCellResizer _gridResizer;
    [SerializeField] GameObject _pieceGOPrefab;
    [SerializeField] Transform _outputGridHandle;
    [SerializeField] Button _prevBtn, _nextBtn;

    private List<GameObject> _displayedPieces = new List<GameObject>();
    private List<string> _results = new List<string>();
    private int _resultIndex;
    private const string NO_RESULT_MSG = "There are no possible configurations for this!";

    #region Button Inputs
    public void NextBtnPressed()
    {
        _resultIndex++;
        if(_resultIndex >= _results.Count)
        {
            _resultIndex = 0;
        }

        RenderResults();
    }

    public void PreviousBtnPressed()
    {
        _resultIndex--;
        if (_resultIndex < 0)
        {
            _resultIndex = _results.Count - 1;
        }

        RenderResults();
    }
    #endregion

    public void DisplayResults(List<string[,]> results)
    {
        if(results.Count == 0)
        {
            DisplayNoResults();
            return;
        }

        int width = results.First().GetLength(0);
        int height = results.First().GetLength(1);
        _gridResizer.SetGrid(width, height);
        _resultIndex = 0;
        _results = CleanUpResults(results);

        RenderResults();
    }

    private void DisplayNoResults()
    {
        _positionRenderer.text = NO_RESULT_MSG;
        _nextBtn.interactable = false;
        _prevBtn.interactable = false;
        _displayedPieces.ForEach(Destroy);
    }

    // Removes telemetry, handles empty cells, removes duplicates
    private List<string> CleanUpResults(List<string[,]> results)
    {
        List<string> cleanedResults = new List<string>();

        foreach (var result in results)
        {
            string outputMsg = "";
            for (int y = 0; y < result.GetLength(1); y++)
            {
                for (int x = 0; x < result.GetLength(0); x++)
                {
                    // Replace the nulls
                    if (result[x, y] == null)
                    {
                        result[x, y] = "X";
                    }

                    outputMsg += result[x, y] + "|";
                }
            }
            outputMsg = outputMsg.Substring(0, outputMsg.Length - 1); // Trim off the final split indicator "|"
            cleanedResults.Add(outputMsg);
        }

        // Remove duplicates
        cleanedResults = cleanedResults.Distinct().ToList();

        return cleanedResults;
    }

    private void RenderResults()
    {
        _positionRenderer.text = "";

        string[] splitOutput = _results[_resultIndex].Split('|');
        SpawnPiecesBasedOnPieceCodes(splitOutput);

        // Render Position
        _positionRenderer.text = (_resultIndex + 1) + "/" + _results.Count;

        // Make the next and prev buttons available if there is more than 1 output
        _nextBtn.interactable = _results.Count > 1;
        _prevBtn.interactable = _results.Count > 1;

    }

    private void SpawnPiecesBasedOnPieceCodes(string[] pieceCodes)
    {
        // Clear currently displayed pieces
        _displayedPieces.ForEach(Destroy);
        int alternatingIndex = 0;

        foreach(var pieceCode in pieceCodes)
        {
            alternatingIndex++;
            GameObject piece = Instantiate(_pieceGOPrefab, _outputGridHandle);
            ChessPieceRenderer pieceScript = piece.GetComponent<ChessPieceRenderer>();
            pieceScript.SetPieceDisplay(pieceCode);
            _displayedPieces.Add(piece);

            // I'd like the tiles to alternate in colour, so using modulus to quickly do this
            pieceScript.SetTileColour(alternatingIndex % 2 == 0);
        }
    } 
}
