using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiftInstance : MonoBehaviour {

    public GameObject Lift;

	// Use this for initialization
	void Start () {
        InvokeRepeating("Instance", 2.0f, 2.0f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void Instance()
    {
        Instantiate(Lift,new Vector3(transform.position.x,transform.position.y,transform.position.z),Quaternion.identity);
    }
}
