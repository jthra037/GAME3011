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
                color = new Color(255, 70, 0); //orange
                break;
            case TileMode.quarter:
                value = 4;
                color = Color.red;
                break;
        }

    }
}

[RequireComponent(typeof(Image), typeof(Button))]
public class GameTile : MonoBehaviour {
    public bool isScanned = false;
    public TileInfo Info = new TileInfo();

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
    private GameTile[] neighbors = new GameTile[4];

    private void Start()
    {
        image = GetComponent<Image>();
        button = GetComponent<Button>();
    }

    public void TileActivation()
    {
        image.color = Info.color;
        GameInfo.Score += Info.value;

        Mode = TileMode.minimal;

        Debug.Log(GameInfo.Score);
    }
}
