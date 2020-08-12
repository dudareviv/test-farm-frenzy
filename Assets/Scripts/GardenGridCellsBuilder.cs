using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(GardenGrid))]
public class GardenGridCellsBuilder : MonoBehaviour
{
    [SerializeField]
    private GameObject _cellPrefab;

    private GardenGrid _grid;

    private void Awake()
    {
        _grid = GetComponent<GardenGrid>();

        BuildCells();
    }

    private void BuildCells()
    {
        var cellSize = _grid.GetCellSize();
        var gridWidth = _grid.GetWidth();
        var gridHeight = _grid.GetHeight();

        for (var y = 0; y < gridHeight; y++)
        {
            for (var x = 0; x < gridWidth; x++)
            {
                BuildCell(cellSize, x, y);
            }
        }
    }

    private void BuildCell(Vector2 cellSize, int x, int y)
    {
        var cell = Instantiate(_cellPrefab, _grid.transform);

        cell.transform.name = $"Garden Cell ({x};{y})";
        cell.transform.position = _grid.GetGlobalCellPosition(x, y);

        var gardenCell = cell.GetComponent<GardenCell>();
        gardenCell.Grid = _grid;
        
        cell.SetActive(true);
    }
}