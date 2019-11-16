using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class OutputDisplay : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _outputRenderer, _positionRenderer;

    private List<string[][]> _results = new List<string[][]>();

    #region Button Inputs
    public void NextBtnPressed()
    {
        // TODO: Build Next Button
        throw new NotImplementedException();
    }

    public void PreviousBtnPressed()
    {
        // TODO: Build Prev Button
        throw new NotImplementedException();
    }
    #endregion

    public void DisplayResults(List<string[,]> results)
    {
        // TODO Build result display
        foreach(string[,] board in results)
        {
            string msg = "";
            for (int x = 0; x < board.GetLength(0); x++)
            {
                for(int y = 0; y < board.GetLength(1); y++)
                {
                    string result = board[x, y];
                    if (result == null) result = "";
                    msg += "[" + board[x, y] + "]";
                }
                msg += '\n';
            }
            print(msg);
        }
    }
}
