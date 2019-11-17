using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using System.Linq;

public class OutputDisplay : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _outputRenderer, _positionRenderer;

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
        _resultIndex = 0;
        _results = CleanUpResults(results);

        RenderResults();
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
                        result[x, y] = " ";
                    }

                    // Remove the telemetry
                    if (result[x, y].Equals("X"))
                    {
                        result[x, y] = " ";
                    }

                    outputMsg += "[" + result[x, y] + "]";
                }
                outputMsg += '\n';
            }
            cleanedResults.Add(outputMsg);
        }

        // Remove duplicates
        cleanedResults = cleanedResults.Distinct().ToList();

        return cleanedResults;
    }

    private void RenderResults()
    {
        // Just in case there are no results
        if (_results.Count == 0)
        {
            _outputRenderer.text = NO_RESULT_MSG;
            _outputRenderer.alignment = TextAlignmentOptions.Center; // Message looks terrible flush!
            _positionRenderer.text = "";
            return;
        }
        else
        {
            _outputRenderer.alignment = TextAlignmentOptions.Flush;
        }

        _outputRenderer.text = _results[_resultIndex];

        // Render Position
        _positionRenderer.text = (_resultIndex + 1) + "/" + _results.Count;
    }
}
