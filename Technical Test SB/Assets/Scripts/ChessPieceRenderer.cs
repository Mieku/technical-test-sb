using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChessPieceRenderer : MonoBehaviour
{
    [SerializeField] Image _pieceRenderer;

    [SerializeField] Sprite _kingSpr, _queenSpr, _bishopSpr, _rookSpr, _knightSpr;

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
