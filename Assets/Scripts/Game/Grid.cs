using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid
{
    public struct Cell
    {
        public bool isPlatform;
        public float lightIntensity;
    }

    private int width;
    private int height;
    private float cellSize;

    private Cell[,] gridArray;

    public Grid(int width, int height, float cellSize)
    {
        this.width = width;
        this.height = height;
        this.cellSize = cellSize;

        gridArray = new Cell[width, height];

        for (int x = 0; x < gridArray.GetLength(0); x++)
        {
            for (int y = 0; y < gridArray.GetLength(1); y++)
            {
                gridArray[x, y].isPlatform = false;
                gridArray[x, y].lightIntensity = 0f;

                Debug.DrawLine(GetWorldPosition(x, y), GetWorldPosition(x, y + 1), Color.white, 100f);
                Debug.DrawLine(GetWorldPosition(x, y), GetWorldPosition(x + 1, y), Color.white, 100f);
            }
        }
    }

    private Vector3 GetWorldPosition(int x, int y)
    {
        return new Vector3(x, y) * cellSize;
    }
}
