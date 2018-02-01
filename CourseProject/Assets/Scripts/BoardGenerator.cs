using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardGenerator : MonoBehaviour {
    [SerializeField]
    private GameTile tilePrefab;
    [SerializeField]
    private int height = 9;
    [SerializeField]
    private int width = 9;
    [SerializeField]
    private int numberOfStarts = 8;

    private GameTile[] tiles;

    private void Awake()
    {
        tiles = new GameTile[height * width];

        // Large and possibly incorrect assignment which is supposed to move the board to be centred in the screen as it's made
        GetComponent<RectTransform>().anchoredPosition = new Vector2(
            -width * tilePrefab.GetComponent<RectTransform>().sizeDelta.x / 2 + 100,
            tilePrefab.GetComponent<RectTransform>().sizeDelta.y / 2);

        for (int i = 0, k = 0; i < height; i++)
        {
            for (int j = 0; j < width; j++)
            {
                CreateTile(j, i, k++);
            }
        }

        for(int i = 0; i < numberOfStarts; i++)
        {
            MakeMaxValue(Random.Range(0, tiles.Length));
        }

    }

    /// <summary>
    /// Creates a gameTile and adds it to tiles[]
    /// </summary>
    /// <param name="x">X placement of tile in board</param>
    /// <param name="y">Y placement of tile in board</param>
    /// <param name="i">Index of tile in tiles[]</param>
    private void CreateTile(int x, int y, int i)
    {
        GameTile tile = Instantiate(tilePrefab, transform);
        if (x > 0)
        {
            tile.SetNeighbor(Directions.west, tiles[i - 1]);

            if (y > 0)
            {
                tile.SetNeighbor(Directions.southwest, tiles[i - 1 - width]);
            }
        }
        if (y > 0)
        {
            tile.SetNeighbor(Directions.south, tiles[i - width]);

            if (x < width - 1)
            {
                tile.SetNeighbor(Directions.southeast, tiles[i + 1 - width]);
            }
        }

        Vector2 position = new Vector2(x * tile.rectTransform.sizeDelta.x, y * tile.rectTransform.sizeDelta.x);
        tile.rectTransform.anchoredPosition = position;

        tiles[i] = tile;

    }

    /// <summary>
    /// Really not optimized in any way, but makes the square surrounding
    /// a randomly chosen tile out of increased value tiles.
    /// </summary>
    /// <param name="index">Index of the randomly chosen centre tile in the flat tiles[]</param>
    private void MakeMaxValue(int index)
    {
        // Make 25 tiles centred on index into quarter power
        for (int i = -2; i <= 2; i++)
        {
            for (int j = -2; j <= 2; j++)
            {
                if (tiles.Length == 0)
                { return; }

                tiles[Mathf.Clamp(index + i + (j * width),
                    0,
                    tiles.Length-1)].Mode = TileMode.quarter;
            }
        }

        // Make 9 tiles centred on index into half power
        for (int i = -1; i <= 1; i++)
        {
            for (int j = -1; j <= 1; j++)
            {
                tiles[Mathf.Clamp(index + i + (j * width),
                    0,
                    tiles.Length-1)].Mode = TileMode.half;
            }
        }

        // Make tile at index into maximum power
        tiles[index].Mode = TileMode.maximum;

    }

    /// <summary>
    /// Changes the scanning boolean in the info class
    /// </summary>
    public void ToggleScanMode()
    {
        GameInfo.Scanning = !GameInfo.Scanning;
    }
}
