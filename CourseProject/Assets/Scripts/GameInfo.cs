using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameInfo
{
    private static int score = 0;
    private static int scans = 6;
    private static bool scanning = true;

    public static int Score
    {
        get { return score; }
        set { score = value; }
    }

    public static int Scans
    {
        get { return scans; }
        set
        {
            scans = value;
            if (scans <= 0)
            {
                Scanning = false;
            }
        }
    }

    public static bool Scanning
    {
        get { return scanning; }
        set
        {
            scanning = scans > 0 ? value : false;
        }
    }
}
