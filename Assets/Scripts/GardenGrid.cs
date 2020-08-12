using System.Collections;
using System.Collections.Generic;
using Packages.Rider.Editor.Util;
using UnityEditor;
using UnityEngine;
using UnityEngine.Diagnostics;

public class GardenGrid : MonoBehaviour
{
    [SerializeField]
    private Vector2 _cellSize = new Vector2(1f, 1f);

    [SerializeField, Range(1, 10)]
    private int _width = 1;

    [SerializeField, Range(1, 10)]
    private int _height = 1;

    public Vector2 GetCellSize()
    {
        return _cellSize;
    }

    public int GetWidth()
    {
        return _width;
    }

    public int GetHeight()
    {
        return _height;
    }

    public Vector2 GetGlobalCellPosition(int x, int y)
    {
        Vector2 position = transform.position;

        var offset = new Vector2
        {
            x = ((_width - 1) * _cellSize.x + (_height - 1) * _cellSize.x) / 2f,
        };

        position = position - offset / 2f + GetLocalCellPosition(x, y);

        return position;
    }

    public Vector2 GetLocalCellPosition(int x, int y)
    {
        return new Vector2
        {
            x = _cellSize.x * x - _cellSize.x / 2 * x + _cellSize.x / 2 * y,
            y = _cellSize.y * y - _cellSize.y / 2 * x - _cellSize.y / 2 * y
        };
    }

    private void OnDrawGizmos()
    {
        for (var y = 0; y < _height; y++)
        {
            for (var x = 0; x < _width; x++)
            {
                DrawCellGizmo(x, y);
            }
        }
    }

    private void DrawCellGizmo(int x, int y)
    {
        var position = GetGlobalCellPosition(x, y);

        var left = new Vector2(-_cellSize.x / 2, 0) + position;
        var up = new Vector2(0, _cellSize.y / 2) + position;
        var right = new Vector2(_cellSize.x / 2, 0) + position;
        var down = new Vector2(0, -_cellSize.y / 2) + position;

        Debug.DrawLine(left, up);
        Debug.DrawLine(up, right);
        Debug.DrawLine(right, down);
        Debug.DrawLine(down, left);
    }
}