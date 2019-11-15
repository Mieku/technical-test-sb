using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class SystemUI : MonoBehaviour
{
    [Header("Input Fields")]
    [SerializeField] TMP_InputField _horizontalCellInput;
    [SerializeField] TMP_InputField _verticalCellInput;
    [SerializeField] TMP_InputField _kingInput;
    [SerializeField] TMP_InputField _queenInput;
    [SerializeField] TMP_InputField _bishopInput;
    [SerializeField] TMP_InputField _rookInput;
    [SerializeField] TMP_InputField _knightInput;

    [Header("Output Fields")]
    [SerializeField] OutputDisplay _outputDisplay;
    [SerializeField] TextMeshProUGUI _errorRenderer;

    #region Button Inputs
    public void CalculateBtnPressed()
    {
        // TODO: Build Calculate Button
        throw new NotImplementedException();
    }
    #endregion

}
