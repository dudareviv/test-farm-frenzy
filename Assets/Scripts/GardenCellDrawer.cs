using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(GardenCell))]
public class GardenCellDrawer : MonoBehaviour
{
    [SerializeField]
    private GardenGrid _grid;

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

        var positions = new Vector3[4]
        {
            left, up, right, down
        };

        lineRenderer.startWidth = 0.05f;
        lineRenderer.endWidth = 0.05f;
        lineRenderer.positionCount = 4;
        lineRenderer.loop = true;
        lineRenderer.SetPositions(positions);
    }
}