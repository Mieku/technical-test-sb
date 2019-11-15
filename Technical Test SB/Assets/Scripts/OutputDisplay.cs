using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class OutputDisplay : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _outputRenderer, _positionRenderer;

    private List<string> _results = new List<string>();

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

    public void DisplayResults(List<string> results)
    {
        // TODO Build result display
    }
}
