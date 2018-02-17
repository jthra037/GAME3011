using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinInfo : MonoBehaviour {

    [SerializeField] private Transform pinContainer;
    [SerializeField] private BoxCollider tumblerCollider;

    public float Width
    {
        get { return tumblerCollider.size.x; }
        set { tumblerCollider.size = new Vector3(value, tumblerCollider.size.y, tumblerCollider.size.z); }
    }

	// Use this for initialization
	void Start ()
    {
        pinContainer.localScale = new Vector3(pinContainer.localScale.x, Random.Range(0.3f, 2), pinContainer.localScale.z);	
	}
}
