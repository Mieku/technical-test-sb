using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

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
    [SerializeField] Button _calculateButton;

    [Header("Output Fields")]
    [SerializeField] OutputDisplay _outputDisplay;
    [SerializeField] TextMeshProUGUI _errorRenderer;

    private const string NEG_INPUT_ERROR_MSG = "You can not have negative pieces";
    private const string CELL_INPUT_ERROR_MSG = "Your cell values must be greater than 0";
    private const string CELL_INPUT_LARGE_WARNING = "Large cell values can result in long calculation times";

    private bool _inputIsSafe;

    #region Button and Field Inputs
    public void CalculateBtnPressed()
    {
        CalculateConfigurations();
    }

    public void InputCheckInitiated()
    {
        CheckForInputErrors();
    }
    #endregion

    #region Input Error Checking
    private void CheckForInputErrors()
    {
        /* 
         * Note: Input is already blocked to be int only.
         * - Ensure Piece amounts are not negative
         * - Ensure Cell input is greater than 0
         * 
         * Display an error message if there is an error
        */
        _errorRenderer.text = ""; // Resetting error msg
        _inputIsSafe = true;

        // Ensuring all piece amounts are not negative
        NoNegativeCheck(_kingInput);
        NoNegativeCheck(_queenInput);
        NoNegativeCheck(_bishopInput);
        NoNegativeCheck(_rookInput);
        NoNegativeCheck(_knightInput);

        // Ensuring all cell inputs are greater than 0
        CellInputCheck(_horizontalCellInput);
        CellInputCheck(_verticalCellInput);

        _calculateButton.interactable = _inputIsSafe; // Don't allow the button to be pressed when input has issues
    }

    private void NoNegativeCheck(TMP_InputField inputField)
    {
        int.TryParse(inputField.text, out int inputValue);
        if (inputValue < 0)
        {
            _errorRenderer.text = NEG_INPUT_ERROR_MSG;
            _inputIsSafe = false;
        }
    }

    private void CellInputCheck(TMP_InputField inputField)
    {
        int.TryParse(inputField.text, out int inputValue);
        if (inputValue < 1)
        {
            _errorRenderer.text = CELL_INPUT_ERROR_MSG;
            _inputIsSafe = false;
        } else if(inputValue > 6)
        {
            _errorRenderer.text = CELL_INPUT_LARGE_WARNING;
        }

    }
    #endregion

    private void CalculateConfigurations()
    {
        // Converting the string values to ints, using tryparse to ensure that empty is 0
        int.TryParse(_horizontalCellInput.text, out int horCells);
        int.TryParse(_verticalCellInput.text, out int vertCells);
        int.TryParse(_kingInput.text, out int numKing);
        int.TryParse(_queenInput.text, out int numQueen);
        int.TryParse(_bishopInput.text, out int numBishop);
        int.TryParse(_rookInput.text, out int numRook);
        int.TryParse(_knightInput.text, out int numKnight);

        Vector2Int boardSize = new Vector2Int(horCells, vertCells);

        ChessPieceCalculator calculator = new ChessPieceCalculator(
            boardSize,
            numKing,
            numQueen,
            numBishop,
            numRook,
            numKnight);

        _outputDisplay.DisplayResults(calculator.CalculateResults());
    }
}
