using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum Directions
{
    north,
    east,
    south,
    west
}

public static class DirectionExtensions
{
    public static Directions Opposite(this Directions direction)
    {
        return (int)direction < 2 ? (direction + 2) : (direction - 2);
    }
}

public enum TileMode
{
    minimal,
    quarter,
    half,
    maximum
}

public class TileInfo
{
    public Color color = Color.gray;
    public int value = 1;

    public TileInfo(TileMode mode = TileMode.minimal)
    {
        switch(mode) 
        {
            case TileMode.maximum:
                value = 16;
                color = Color.yellow;
                break;
            case TileMode.half:
                value = 8;
                color = new Color(1, 0.4f, 0); //orange
                //color = Color.blue;
                break;
            case TileMode.quarter:
                value = 4;
                color = Color.red;
                break;
        }
    }
}

[RequireComponent(typeof(Image), typeof(Button), typeof(RectTransform))]
public class GameTile : MonoBehaviour {
    public bool isScanned = false;
    public TileInfo Info = new TileInfo();
    public RectTransform rectTransform;


    public TileMode Mode
    {
        get { return mode; }
        set
        {
            mode = value;
            Info = new TileInfo(mode);
        }
    }


    private TileMode mode;
    private Image image;
    private Button button;
    [SerializeField]
    private GameTile[] neighbors = new GameTile[4];

    private void Awake()
    {
        image = GetComponent<Image>();
        button = GetComponent<Button>();
        rectTransform = GetComponent<RectTransform>();
    }

    private void Start()
    {
        image.color = Info.color;
    }

    public void TileActivation()
    {

        if (GameInfo.Scanning)
        {

        } 
        else
        {
            image.color = Info.color;
            GameInfo.Score += Info.value;

            Mode = TileMode.minimal;

            Debug.Log(GameInfo.Score);
        }
    }

    public void SetNeighbor(Directions direction, GameTile tile)
    {
        neighbors[(int)direction] = tile;
        tile.neighbors[(int)direction.Opposite()] = this;
    }

    public GameTile GetNeighbor(Directions direction)
    {
        return neighbors[(int)direction];
    }
}
