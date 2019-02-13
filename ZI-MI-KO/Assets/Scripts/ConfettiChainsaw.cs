using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfettiChainsaw : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void FixedUpdate()
    {
        this.transform.Rotate(0, 0, this.transform.rotation.z + 5);
        
    }
}
