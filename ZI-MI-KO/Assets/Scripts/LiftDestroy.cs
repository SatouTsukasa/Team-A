using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiftDestroy : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D col)
    {
        
        Debug.Log("ngfdjghodjg");
        Debug.Log(col.gameObject.tag);
        Destroy(col.gameObject);
    }
}
