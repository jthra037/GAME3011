using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinSpawner : MonoBehaviour
{
    private float minWidth = 0.3f;
    private float maxWidth = 2;
    private float[] widths;
    private PinInfo[] pins;

    [Range(0.04f, 0.09f)]
    public float tolerance = 0.06f;
    
    [SerializeField] private PinInfo pinTumblerPrefab;
    [SerializeField] private Transform[] spawnPoints;

    private void Start()
    {
        widths = new float[spawnPoints.Length];

        foreach(Transform point in spawnPoints)
        {
            Randomize(Instantiate(pinTumblerPrefab, point.position, point.rotation));
        }
    }

    private void Randomize(PinInfo pinTumbler)
    {
        float x = Random.Range(minWidth, maxWidth);
        
        while(tooClose(x))
        {
            x = Random.Range(minWidth, maxWidth);
        }

        pinTumbler.Width = x;
    }

    private bool tooClose(float x)
    {
        bool flag = false;

        foreach(float width in widths)
        {
            flag = flag || (Mathf.Abs(x - width) < tolerance);
        }

        return flag;
    }
}
