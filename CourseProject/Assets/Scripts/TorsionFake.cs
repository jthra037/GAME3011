using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody), typeof(Collider))]
public class TorsionFake : MonoBehaviour {

    [SerializeField] private float movemementScale = 2;
    [SerializeField] private Slider sliderRef;
    private Rigidbody rb;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        rb.drag = 3;
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        rb.AddForce(transform.right * movemementScale * sliderRef.value);
	}
}
