using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PickController : MonoBehaviour {

    [SerializeField] private float vertForce = 15;
    [SerializeField] private float horzVelocity = 5;
    private Rigidbody rb;

	// Use this for initialization
	void Start ()
    {
        rb = GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        Debug.Log(Input.GetAxis("Vertical"));

        rb.velocity = new Vector3(rb.velocity.x, 
            rb.velocity.y, 
            horzVelocity * Input.GetAxis("Horizontal"));

        rb.AddForce(transform.up * vertForce * Input.GetAxis("Vertical"));
	}
}
