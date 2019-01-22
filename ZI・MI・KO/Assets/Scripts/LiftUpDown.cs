using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiftUpDown : MonoBehaviour {

    private Vector3 trans;

    public float up;

	// Use this for initialization
	void Start () {
        trans = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void FixedUpdate()
    {
        transform.position = new Vector3(transform.position.x, trans.y + Mathf.PingPong(Time.time, up), transform.position.z);
    }
}
