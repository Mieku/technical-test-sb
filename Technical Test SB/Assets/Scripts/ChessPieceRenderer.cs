using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChessPieceRenderer : MonoBehaviour
{
    [SerializeField] Image _pieceRenderer, _tileRenderer;

    [SerializeField] Sprite _kingSpr, _queenSpr, _bishopSpr, _rookSpr, _knightSpr;
    [SerializeField] Color _lightTileColour, _darkTileColour;

    public void SetPieceDisplay(string pieceCode)
    {
        Sprite pieceSprite = DetermineSprite(pieceCode);
        if(pieceSprite == null)
        {
            _pieceRenderer.enabled = false;
        } else
        {
            _pieceRenderer.enabled = true;
            _pieceRenderer.sprite = pieceSprite;
        }
    }

    public void SetTileColour(bool isEven)
    {
        if(isEven)
        {
            _tileRenderer.color = _lightTileColour;
        } else
        {
            _tileRenderer.color = _darkTileColour;
        }
    }

    private Sprite DetermineSprite(string pieceCode)
    {
        switch(pieceCode)
        {
            case "K":
                return _kingSpr;
            case "Q":
                return _queenSpr;
            case "B":
                return _bishopSpr;
            case "R":
                return _rookSpr;
            case "Kn":
                return _knightSpr;
            default:
            case "X":
                return null;
        }
    }
    
}
