using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(GardenCell))]
public class GardenCellDrawer : MonoBehaviour
{
    [SerializeField]
    private GardenGrid _grid;

    [SerializeField]
    private Color _color = Color.cyan;

    [SerializeField]
    private Material _material;

    private void Start()
    {
        _grid = GetComponent<GardenCell>().Grid;

        Draw();
    }

    private void Draw()
    {
        var cellLineRenderer = new GameObject();
        cellLineRenderer.transform.name = "Garden Cell Contoure";
        cellLineRenderer.transform.parent = transform;

        var lineRenderer = cellLineRenderer.AddComponent<LineRenderer>();

        var cellSize = _grid.GetCellSize();
        Vector2 position = transform.position;

        var left = new Vector2(-cellSize.x / 2, 0) + position;
        var up = new Vector2(0, cellSize.y / 2) + position;
        var right = new Vector2(cellSize.x / 2, 0) + position;
        var down = new Vector2(0, -cellSize.y / 2) + position;

        var positions = new Vector3[5]
        {
            left, up, right, down, left
        };

        lineRenderer.startColor = _color;
        lineRenderer.endColor = _color;

        lineRenderer.startWidth = 0.05f;
        lineRenderer.endWidth = 0.05f;

        lineRenderer.material = _material;

        lineRenderer.positionCount = positions.Length;

        lineRenderer.SetPositions(positions);
    }
}