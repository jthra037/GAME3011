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

        GetComponent<RectTransform>().anchoredPosition = new Vector2(
            -width * tilePrefab.GetComponent<RectTransform>().sizeDelta.x / 2,
            tilePrefab.GetComponent<RectTransform>().sizeDelta.y / 2);

        for (int i = 0, k = 0; i < height; i++)
        {
            for (int j = 0; j < width; j++)
            {
                CreateTile(i, j, k++);
            }
        }

        for(int i = 0; i < numberOfStarts; i++)
        {
            MakeMaxValue(Random.Range(0, tiles.Length));
        }

    }

    private void CreateTile(int x, int y, int count)
    {
        GameTile tile = Instantiate(tilePrefab, transform);
        if (x > 0)
        {
            tile.SetNeighbor(Directions.west, tiles[count - 1]);
        }
        Vector2 position = new Vector2(x * tile.rectTransform.sizeDelta.x, y * tile.rectTransform.sizeDelta.x);
        tile.rectTransform.anchoredPosition = position;

        tiles[count] = tile;

    }

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

    public void ToggleScanMode()
    {
        GameInfo.Scanning = !GameInfo.Scanning;
    }
}
