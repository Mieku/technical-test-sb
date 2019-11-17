using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(GridLayoutGroup))]
public class GridCellResizer : MonoBehaviour
{
    private GridLayoutGroup _grid;
    private RectTransform _rect;
    private int _numCells, _numColumns;

    private void Awake()
    {
        _grid = GetComponent<GridLayoutGroup>();
        _rect = GetComponent<RectTransform>();
    }

    public void SetGrid(int numHorCells, int numVertCells)
    {
        _numColumns = numHorCells;
        _numCells = Mathf.Max(numHorCells, numVertCells); // Account for the greatest size, since board doesn't have to be square
        SizeCells();
    }

    private void SizeCells()
    {
        float cellSize = _rect.rect.width / _numCells;

        _grid.cellSize = new Vector2(cellSize - _grid.spacing.x, cellSize - _grid.spacing.y);
        _grid.constraintCount = _numColumns;
    }
}
