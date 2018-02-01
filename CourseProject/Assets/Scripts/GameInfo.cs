using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameInfo
{
    private static int score = 0;
    private static bool scanning = false;

    public static int Score
    {
        get { return score; }
        set { score = value; }
    }

    public static bool Scanning
    {
        get { return scanning; }
        set { scanning = value; }
    }


}
