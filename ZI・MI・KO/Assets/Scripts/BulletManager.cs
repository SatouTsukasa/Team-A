using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour {

    public float Speed;
    public float time = 0;

	// Use this for initialization
	void Start () {
        Destroy(gameObject, 3.0f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void FixedUpdate()
    {
        transform.position -= transform.right * Time.deltaTime * Speed;
    }
}
